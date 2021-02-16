using System;
using System.Collections.Generic;
using System.Drawing;

namespace MemoryDisplay
{
    public class AddressParser
    {
        public List<MemoryRegion> Regions = new List<MemoryRegion>();
        public AddressParser(List<string> lines)
        {
            ParseAddressOutput(lines);
        }

        private void ParseAddressOutput(List<string> lines)
        {         
            int numLines = lines.Count;
            int currentLine = 0;

            //parse the lines, finding 
            // 1.  fffde000 : fffde000 - 00001000  or 7efe9000 - 000f7000
            // 2.  State    00002000 MEM_RESERVE
            // 3.  Usage    RegionUsageIsVAD

            //if this fails, return null

            //go until we are out of lines or reach the "-------------------- Usage SUMMARY --------------------------" line
            while (!lines[currentLine].Contains("Usage SUMMARY") && (currentLine < numLines))
            {
                //look for fffde000 : fffde000 - 00001000  or 7efe9000 - 000f7000
                int dashPosition = lines[currentLine].IndexOf("-");
                if ((dashPosition != -1) && !lines[currentLine].Contains("FullPath"))
                {
                    //create a new block and read all the lines until we reach the next address line
                    //if we have reached the FullPath line we are also done so we can just look for the next - line
                    string address = lines[currentLine].Substring(dashPosition - 9, 8);
                    string size = lines[currentLine].Substring(dashPosition + 2, 8);

                    currentLine++;

                    List<string> block = new List<string>();
                    while (!lines[currentLine].Contains("-") && !lines[currentLine].Contains("Usage SUMMARY") && (currentLine < numLines))
                    {
                        block.Add(lines[currentLine]);
                        currentLine++;
                    }

                    //Create the memory object
                    MemoryRegion region = new MemoryRegion
                    {
                        Address = Int64.Parse(address, System.Globalization.NumberStyles.HexNumber),
                        Size = Int64.Parse(size, System.Globalization.NumberStyles.HexNumber),
                        Usage = GetUsage(block),
                        State = GetState(block)
                    };

                    Regions.Add(region);

                    //return to the last line
                    currentLine--;
                }
                currentLine++;
            }
        }

        private State GetState(List<string> block)
        {
            State state = State.Undefined;

            foreach (string line in block)
            {
                if (line.Contains("State"))
                {
                    if (line.Contains("MEM_COMMIT"))
                        state = State.Commit;
                    else if (line.Contains("MEM_FREE"))
                        state = State.Free;
                    else if (line.Contains("MEM_RESERVE"))
                        state = State.Reserve;

                    break;
                }
            }

            return state;
        }

        private Usage GetUsage(List<string> block)
        {
            Usage u = Usage.Undefined;

            foreach (string line in block)
            {
                if (line.Contains("Usage"))
                {
                    if (line.Contains("RegionUsageIsVAD"))
                        u = Usage.VirtualAlloc;
                    else if (line.Contains("RegionUsageFree"))
                        u = Usage.Free;
                    else if (line.Contains("RegionUsageImage"))
                        u = Usage.Image;
                    else if (line.Contains("RegionUsageStack"))
                        u = Usage.Stack;
                    else if (line.Contains("RegionUsageTeb"))
                        u = Usage.TEB;
                    else if (line.Contains("RegionUsageHeap"))
                        u = Usage.Heap;
                    else if (line.Contains("RegionUsagePageHeap"))
                        u = Usage.PageHeap;
                    else if (line.Contains("RegionUsagePeb"))
                        u = Usage.PEB;
                    else if (line.Contains("RegionUsageProcessParametrs"))
                        u = Usage.ProcessParameters;
                    else if (line.Contains("RegionUsageEnvironmentBlock"))
                        u = Usage.EnvironmentBlock;

                    break;
                }
            }

            return u;
        }
    }
}
