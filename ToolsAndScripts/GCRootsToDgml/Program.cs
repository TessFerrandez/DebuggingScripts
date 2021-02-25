using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace GCRootsToDgml
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) 
            {
                PrintUsage();
                return;
            }
            string input = args[0];
            string output = args[1];

            ConvertGCRootsToDgml(input, output);
        }

        static void PrintUsage()
        {
            Console.WriteLine("GCRootsToDgml input output.dgml");
            Console.WriteLine("Converts GCRoot input to a DGML graph");
        }
        
        static QualifiedName addressName = QualifiedName.Get("Address", typeof(string));
        static QualifiedName typeName = QualifiedName.Get("Name", typeof(string));
        static QualifiedName assemblyName = QualifiedName.Get("AssemblyName", typeof(string));
        static QualifiedName arrayName = QualifiedName.Get("A", typeof(int));

        static void ConvertGCRootsToDgml(string input, string output)
        {

            Graph g = new Graph();
            Node previous = null;
            char[] ws = new char[] { ' ', '\t' };
           
            using (StreamReader sr = new StreamReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    line = line.Trim();
                    if (!string.IsNullOrEmpty(line) && !line.StartsWith("Scan Thread"))
                    {                        
                        if (line.Contains(":Root:")){
                            int index = line.IndexOf(":Root:");
                            line = line.Substring(index + ":Root:".Length).TrimStart(ws);
                            Debug.Assert(previous == null, "Expecting previous to be null");
                        }

                        string label = null;
                        QualifiedIdentifier id = ParseLine(line, out label);
                        if (id != null) 
                        {
                            Node n = g.Nodes.GetOrCreate(id, label);
                            if (previous != null)
                            {
                                g.Links.GetOrCreate(previous, n);
                            }
                            previous = n;
                        }

                        if (!line.EndsWith("->"))
                        {
                            // then this was the end of a chain.
                            previous = null;
                        }
                    }

                    line = sr.ReadLine();
                }
            }

            g.Save(output);
        }

        /// <summary>
        /// Parse SOS GCRoot output in the format and return valid QualifiedIdentifier
        /// "// 179763ec(MS.Utility.SingleItemList`1[[System.Windows.RoutedEventHandlerInfo, PresentationCore]])->"
        /// </summary>
        static QualifiedIdentifier ParseLine(string line, out string label) 
        {
            QualifiedIdentifier address = null;
            QualifiedIdentifier name = null;
            label = null;
            int start = 0;
            for (int i = 0, n = line.Length; i < n; i++)
            {
                char c = line[i];
                if (c == '(')
                {
                    address = QualifiedIdentifier.GetPartial(addressName, line.Substring(0, i));
                    start = i+1;
                }
                else if (c == '[')
                {
                    if (i > start)
                    {
                        name = ParseTypeName(line, start, i, out label);
                    }
                    // array or generics parameters
                    QualifiedIdentifier parameters = ParseParameters(line, ref i, false);
                    name = QualifiedIdentifier.GetNested(name, parameters);
                    start = i;
                }
                else if (c == ')')
                {                    
                    if (i > start)
                    {
                        if (name != null)
                        {
                            Console.WriteLine("ERROR");
                        }
                        name = ParseTypeName(line, start, i, out label);
                    }
                    // end
                    break;
                }
            }
            if (address == null) return null;
            return QualifiedIdentifier.GetNested(address, name);                          
        }

        static QualifiedIdentifier ParseTypeName(string line, int start, int i, out string label)
        {
            string fullName = line.Substring(start, i - start).Trim();
            int dot = fullName.LastIndexOf('.');
            if (dot > 0)
            {
                label = fullName.Substring(dot + 1);
            }
            else
            {
                label = fullName;
            }
            return QualifiedIdentifier.GetPartial(typeName, fullName);
        }

        static QualifiedIdentifier ParseParameters(string line, ref int i, bool nested)
        {
            List<QualifiedIdentifier> result = new List<QualifiedIdentifier>();
            int dimensions = 0;
            for (int n = line.Length; i < n; i++)
            {
                char c = line[i];
                if (c == '[' && i+1<n && line[i+1] != ']')
                {
                    int start = i+1;
                    if (line[start] == '[')// expected
                    { 
                        start++;
                    }
                    QualifiedIdentifier type = null;
                    QualifiedIdentifier assembly = null;
                    // then we have a type name
                    for (int j = start; j < n; j++)
                    {
                        c = line[j];
                        if (c == ',')
                        {
                            type = QualifiedIdentifier.GetPartial(typeName, line.Substring(start, j - start).Trim());
                            start = j + 1;
                        }
                        else if (c == ']')
                        {
                            assembly = QualifiedIdentifier.GetPartial(assemblyName, line.Substring(start, j - start).Trim());
                            i = j+1; 
                            break;
                        }
                        else if (c == '[')
                        {
                            type = QualifiedIdentifier.GetPartial(typeName, line.Substring(start, j - start).Trim());
                            QualifiedIdentifier inner = ParseParameters(line, ref j, true);
                            type = QualifiedIdentifier.GetNested(type, inner);
                            start = j;
                        }
                    }

                    result.Add(QualifiedIdentifier.GetNested(type, assembly));
                }
                else if (c == ',')
                {
                    if (nested)
                    {
                        i++;
                        break;
                    }
                    // skip, we have another type coming.
                    dimensions++;
                }
                else if (c == ']')
                {
                    // then it was an empty array []                    
                    i++;
                    break; // done!
                }
            }
            if (result.Count == 0)
            {
                result.Add(QualifiedIdentifier.GetArray(arrayName, dimensions));
            }

            if (result.Count == 1)
            {
                return result[0];
            }
            return QualifiedIdentifier.GetNested(result.ToArray());
        }
    }
}
