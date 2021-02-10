using System;
using System.Windows.Forms;
using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client.Win32;

namespace CurrentRequestsUI
{
    internal class RequestPage : ModulePage
    {
        private Button btnRefresh;
        private DataGridView dgRequests;
        private DataGridViewTextBoxColumn ProcessID;
        private DataGridViewTextBoxColumn URL;
        private DataGridViewTextBoxColumn ClientIP;
        private DataGridViewTextBoxColumn TimeElapsed;
        Microsoft.Web.Administration.ServerManager manager = new ServerManager();

        public RequestPage()
        {
            InitializeComponent();
            LoadAppPoolInfo();
        }

        private void LoadAppPoolInfo()
        {
            UpdateUI();
        }

        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgRequests = new System.Windows.Forms.DataGridView();
            this.ProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeElapsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(630, 368);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgRequests
            // 
            this.dgRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessID,
            this.URL,
            this.ClientIP,
            this.TimeElapsed});
            this.dgRequests.Location = new System.Drawing.Point(12, 12);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.Size = new System.Drawing.Size(693, 341);
            this.dgRequests.TabIndex = 3;
            // 
            // ProcessID
            // 
            this.ProcessID.HeaderText = "Process ID";
            this.ProcessID.Name = "ProcessID";
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.Width = 300;
            // 
            // ClientIP
            // 
            this.ClientIP.HeaderText = "Client IP";
            this.ClientIP.Name = "ClientIP";
            // 
            // TimeElapsed
            // 
            this.TimeElapsed.HeaderText = "TimeElapsed (ms)";
            this.TimeElapsed.Name = "TimeElapsed";
            this.TimeElapsed.Width = 150;
            // 
            // RequestPage
            // 
            this.ClientSize = new System.Drawing.Size(726, 400);
            this.Controls.Add(this.dgRequests);
            this.Controls.Add(this.btnRefresh);
            this.Name = "RequestPage";
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            dgRequests.Rows.Clear();

            foreach (WorkerProcess w3wp in manager.WorkerProcesses)
            {
                string ProcID = w3wp.ProcessId.ToString();

                foreach (Request request in w3wp.GetRequests(0))
                {
                    string[] row0 = { ProcID, request.Url, request.ClientIPAddr, request.TimeElapsed.ToString() };
                    dgRequests.Rows.Add(row0);
                }
            }
        }
    }
}
