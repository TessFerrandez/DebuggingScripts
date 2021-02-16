using System;
using System.Collections.Generic;

namespace MemoryDisplay
{
    public class EEHeapParser
    {
        public List<MemoryRegion> Regions = new List<MemoryRegion>();

        public EEHeapParser(List<string> lines)
        {
            ParseEEHeapOutput(lines);
        }

        private void ParseEEHeapOutput(List<string> lines)
        {
            int numLines = lines.Count;
            int currentLine = 0;

            //parse the lines, finding 
            /*
            segment    begin allocated     size
            02d90000 02d90038  06d83540 0x03ff3508(67056904)
            16fd0000 16fd0038  1a894fb4 0x038c4f7c(59527036)
            1efd0000 1efd0038  22a1d074 0x03a4d03c(61132860)
            Large object heap starts at 0x0ad90038
             segment    begin allocated     size
            0ad90000 0ad90038  0ada2b68 0x00012b30(76592)
            Heap Size  0xb317ff0(187793392)
             */

            //go until we are out of lines or reach the "GC Heap Size" line
            while (!lines[currentLine].Contains("GC Heap Size") && (currentLine < numLines))
            {
                //look for segment    begin allocated     size
                if (lines[currentLine].Contains("allocated"))
                {
                    currentLine++;
                    //get the small object heaps
                    while (!lines[currentLine].Contains("Large"))
                    {
                        string size = lines[currentLine].Substring(lines[currentLine].IndexOf("(") + 1, lines[currentLine].IndexOf(")") - lines[currentLine].IndexOf("(") - 1);

                        MemoryRegion region = new MemoryRegion
                        {
                            //  Address = Int64.Parse(lines[currentLine].Substring(0, 8), System.Globalization.NumberStyles.HexNumber),
                            Address = Int64.Parse(lines[currentLine].Split(' ')[0], System.Globalization.NumberStyles.HexNumber),
                            Size = Int64.Parse(size),
                            Usage = Usage.GCHeap,
                            State = State.Commit
                        };

                        Regions.Add(region);
                        currentLine++;
                    }
                    //jump forward two steps
                    currentLine += 2;

                    //get large object heaps
                    while (!lines[currentLine].Contains("Heap"))
                    {
                        string size = lines[currentLine].Substring(lines[currentLine].IndexOf("(") + 1, lines[currentLine].IndexOf(")") - lines[currentLine].IndexOf("(") - 1);

                        MemoryRegion region = new MemoryRegion
                        {
                            Address = Int64.Parse(lines[currentLine].Substring(0, 8), System.Globalization.NumberStyles.HexNumber),
                            Size = Int64.Parse(size),
                            Usage = Usage.GCHeap,
                            State = State.Commit
                        };

                        Regions.Add(region);
                        currentLine++;
                    }
                }
                currentLine++;
            }
        }
    }
}
