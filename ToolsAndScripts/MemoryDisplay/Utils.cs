using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MemoryDisplay
{
    public class Utils
    {
        public static List<string> ReadLines(Stream s)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(s))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    if (line != string.Empty)
                        lines.Add(line);
            }
            return lines;
        }

        public static Image GenerateImage(List<MemoryRegion> regions)
        {
            Bitmap bmp = new Bitmap(2048, 512);

            foreach (var region in regions)
            {
                int x = (int)((region.Address / 4096) / 512);
                int y = (int)((region.Address / 4096) % 512);
                Color color = region.GetColor();

                if (region.Size >= 4096)
                {
                    long calcSize = region.Size / 4096;

                    for (int pos = 0; pos < calcSize; pos++)
                    {
                        if (y == 512)
                        {
                            y = 0;
                            x++;
                        }
                        bmp.SetPixel(x, y, color);
                        y++;
                    }
                }
            }
            return bmp;
        }
    }
}
