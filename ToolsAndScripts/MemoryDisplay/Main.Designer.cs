
namespace MemoryDisplay
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbVirtualMemory = new System.Windows.Forms.PictureBox();
            this.btnLoadAddress = new System.Windows.Forms.Button();
            this.pbEEHeap = new System.Windows.Forms.PictureBox();
            this.btnLoadEEHeap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbVirtualMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEEHeap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(12, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Undefined";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "FREE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(12, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 2;
            // 
            // pbVirtualMemory
            // 
            this.pbVirtualMemory.BackColor = System.Drawing.Color.White;
            this.pbVirtualMemory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbVirtualMemory.Location = new System.Drawing.Point(11, 35);
            this.pbVirtualMemory.Name = "pbVirtualMemory";
            this.pbVirtualMemory.Size = new System.Drawing.Size(1024, 256);
            this.pbVirtualMemory.TabIndex = 4;
            this.pbVirtualMemory.TabStop = false;
            // 
            // btnLoadAddress
            // 
            this.btnLoadAddress.Location = new System.Drawing.Point(12, 6);
            this.btnLoadAddress.Name = "btnLoadAddress";
            this.btnLoadAddress.Size = new System.Drawing.Size(153, 23);
            this.btnLoadAddress.TabIndex = 5;
            this.btnLoadAddress.Text = "Load !address";
            this.btnLoadAddress.UseVisualStyleBackColor = true;
            this.btnLoadAddress.Click += new System.EventHandler(this.btnLoadAddress_Click);
            // 
            // pbEEHeap
            // 
            this.pbEEHeap.BackColor = System.Drawing.Color.White;
            this.pbEEHeap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbEEHeap.Location = new System.Drawing.Point(12, 398);
            this.pbEEHeap.Name = "pbEEHeap";
            this.pbEEHeap.Size = new System.Drawing.Size(1024, 256);
            this.pbEEHeap.TabIndex = 6;
            this.pbEEHeap.TabStop = false;
            // 
            // btnLoadEEHeap
            // 
            this.btnLoadEEHeap.Location = new System.Drawing.Point(11, 369);
            this.btnLoadEEHeap.Name = "btnLoadEEHeap";
            this.btnLoadEEHeap.Size = new System.Drawing.Size(153, 23);
            this.btnLoadEEHeap.TabIndex = 7;
            this.btnLoadEEHeap.Text = "Load !eeheap -gc";
            this.btnLoadEEHeap.UseVisualStyleBackColor = true;
            this.btnLoadEEHeap.Click += new System.EventHandler(this.btnLoadEEheap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Heap Alloc (Reserved)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Cyan;
            this.panel3.Location = new System.Drawing.Point(117, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Heap Alloc";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.Location = new System.Drawing.Point(117, 297);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Virtual Alloc (Reserved)";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lime;
            this.panel5.Location = new System.Drawing.Point(288, 323);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 20);
            this.panel5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Virtual Alloc";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Green;
            this.panel6.Location = new System.Drawing.Point(288, 297);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 20);
            this.panel6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Image (Reserved)";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Location = new System.Drawing.Point(452, 323);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(20, 20);
            this.panel7.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Image - dll + exe";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Maroon;
            this.panel8.Location = new System.Drawing.Point(452, 297);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(20, 20);
            this.panel8.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(626, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "TEB, PEB, Stack (Reserved)";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel9.Location = new System.Drawing.Point(599, 323);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(20, 20);
            this.panel9.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(626, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "TEB, PEB, Stack";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Purple;
            this.panel10.Location = new System.Drawing.Point(599, 297);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(20, 20);
            this.panel10.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(808, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Page Heap (Reserved)";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Teal;
            this.panel11.Location = new System.Drawing.Point(781, 323);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(20, 20);
            this.panel11.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(808, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Page Heap";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Black;
            this.panel12.Location = new System.Drawing.Point(781, 297);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(20, 20);
            this.panel12.TabIndex = 16;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 667);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.btnLoadEEHeap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pbEEHeap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoadAddress);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pbVirtualMemory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Memory Display (32bit)";
            ((System.ComponentModel.ISupportInitialize)(this.pbVirtualMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEEHeap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbVirtualMemory;
        private System.Windows.Forms.Button btnLoadAddress;
        private System.Windows.Forms.PictureBox pbEEHeap;
        private System.Windows.Forms.Button btnLoadEEHeap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel12;
    }
}

