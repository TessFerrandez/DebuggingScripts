using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MemoryDisplay
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnLoadAddress_Click(object sender, EventArgs e)
        {
            OpenFileDialog addressDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (addressDialog.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    Stream addressStream;
                    if ((addressStream = addressDialog.OpenFile()) != null)
                    {
                        List<string> lines;
                        using (addressStream)
                        {
                            lines = Utils.ReadLines(addressStream);
                        }
                        AddressParser parser = new AddressParser(lines);
                        pbVirtualMemory.Image = Utils.GenerateImage(parser.Regions);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: could not read file. Original Error: " + ex.Message);
                }
            }
        }

        private void btnLoadEEheap_Click(object sender, EventArgs e)
        {
            OpenFileDialog eeheapDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (eeheapDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream eeheapStream;
                    if ((eeheapStream = eeheapDialog.OpenFile()) != null)
                    {
                        List<string> lines;
                        using (eeheapStream)
                        {
                            lines = Utils.ReadLines(eeheapStream);
                        }
                        EEHeapParser parser = new EEHeapParser(lines);
                        pbEEHeap.Image = Utils.GenerateImage(parser.Regions);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: could not read file. Original Error: " + ex.Message);
                }
            }
        }
    }
}
