namespace WindowsFormsApp1
{
    partial class FormDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITAPPLICATIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUKUToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tRANSAKSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pEMINJAMANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pENGEMBALIANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dETAILTRANSAKSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.sdToolStripMenuItem,
            this.bUKUToolStripMenuItem,
            this.tRANSAKSIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1098, 82);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSERToolStripMenuItem,
            this.eXITAPPLICATIONToolStripMenuItem});
            this.fILEToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.equalizersoutline_114523;
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(34, 78);
            this.fILEToolStripMenuItem.Click += new System.EventHandler(this.fILEToolStripMenuItem_Click);
            // 
            // uSERToolStripMenuItem
            // 
            this.uSERToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.log_out_icon_icons_com_50106;
            this.uSERToolStripMenuItem.Name = "uSERToolStripMenuItem";
            this.uSERToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uSERToolStripMenuItem.Text = "SIGN OUT";
            this.uSERToolStripMenuItem.Click += new System.EventHandler(this.uSERToolStripMenuItem_Click);
            // 
            // eXITAPPLICATIONToolStripMenuItem
            // 
            this.eXITAPPLICATIONToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.exit_closethesession_close_6317;
            this.eXITAPPLICATIONToolStripMenuItem.Name = "eXITAPPLICATIONToolStripMenuItem";
            this.eXITAPPLICATIONToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eXITAPPLICATIONToolStripMenuItem.Text = "EXIT ";
            this.eXITAPPLICATIONToolStripMenuItem.Click += new System.EventHandler(this.eXITAPPLICATIONToolStripMenuItem_Click);
            // 
            // sdToolStripMenuItem
            // 
            this.sdToolStripMenuItem.Name = "sdToolStripMenuItem";
            this.sdToolStripMenuItem.Size = new System.Drawing.Size(14, 78);
            // 
            // bUKUToolStripMenuItem
            // 
            this.bUKUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSERSToolStripMenuItem,
            this.bUKUToolStripMenuItem1});
            this.bUKUToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.graph_analytics_analysis_chart_statistics_icon_143359;
            this.bUKUToolStripMenuItem.Name = "bUKUToolStripMenuItem";
            this.bUKUToolStripMenuItem.Size = new System.Drawing.Size(94, 78);
            this.bUKUToolStripMenuItem.Text = "KELOLA";
            this.bUKUToolStripMenuItem.Click += new System.EventHandler(this.bUKUToolStripMenuItem_Click);
            // 
            // uSERSToolStripMenuItem
            // 
            this.uSERSToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.find_users_applications_search_2908;
            this.uSERSToolStripMenuItem.Name = "uSERSToolStripMenuItem";
            this.uSERSToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uSERSToolStripMenuItem.Text = "DATA USERS";
            this.uSERSToolStripMenuItem.Click += new System.EventHandler(this.uSERSToolStripMenuItem_Click);
            // 
            // bUKUToolStripMenuItem1
            // 
            this.bUKUToolStripMenuItem1.Image = global::PerpustakaanEsemka.Properties.Resources.read_book_study_icon_icons_com_51077;
            this.bUKUToolStripMenuItem1.Name = "bUKUToolStripMenuItem1";
            this.bUKUToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.bUKUToolStripMenuItem1.Text = "DATA BUKU";
            this.bUKUToolStripMenuItem1.Click += new System.EventHandler(this.bUKUToolStripMenuItem1_Click);
            // 
            // tRANSAKSIToolStripMenuItem
            // 
            this.tRANSAKSIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pEMINJAMANToolStripMenuItem,
            this.pENGEMBALIANToolStripMenuItem,
            this.dETAILTRANSAKSIToolStripMenuItem});
            this.tRANSAKSIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tRANSAKSIToolStripMenuItem.Image")));
            this.tRANSAKSIToolStripMenuItem.Name = "tRANSAKSIToolStripMenuItem";
            this.tRANSAKSIToolStripMenuItem.Size = new System.Drawing.Size(162, 78);
            this.tRANSAKSIToolStripMenuItem.Text = "TRANSAKSI BUKU";
            this.tRANSAKSIToolStripMenuItem.Click += new System.EventHandler(this.tRANSAKSIToolStripMenuItem_Click);
            // 
            // pEMINJAMANToolStripMenuItem
            // 
            this.pEMINJAMANToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.transaction_minus_icon_244826;
            this.pEMINJAMANToolStripMenuItem.Name = "pEMINJAMANToolStripMenuItem";
            this.pEMINJAMANToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.pEMINJAMANToolStripMenuItem.Text = "PEMINJAMAN";
            this.pEMINJAMANToolStripMenuItem.Click += new System.EventHandler(this.pEMINJAMANToolStripMenuItem_Click);
            // 
            // pENGEMBALIANToolStripMenuItem
            // 
            this.pENGEMBALIANToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.transaction_minus_icon_244826;
            this.pENGEMBALIANToolStripMenuItem.Name = "pENGEMBALIANToolStripMenuItem";
            this.pENGEMBALIANToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.pENGEMBALIANToolStripMenuItem.Text = "PENGEMBALIAN";
            this.pENGEMBALIANToolStripMenuItem.Click += new System.EventHandler(this.pENGEMBALIANToolStripMenuItem_Click);
            // 
            // dETAILTRANSAKSIToolStripMenuItem
            // 
            this.dETAILTRANSAKSIToolStripMenuItem.Image = global::PerpustakaanEsemka.Properties.Resources.detail_icon_215012;
            this.dETAILTRANSAKSIToolStripMenuItem.Name = "dETAILTRANSAKSIToolStripMenuItem";
            this.dETAILTRANSAKSIToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.dETAILTRANSAKSIToolStripMenuItem.Text = "DETAIL TRANSAKSI";
            this.dETAILTRANSAKSIToolStripMenuItem.Click += new System.EventHandler(this.dETAILTRANSAKSIToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1098, 28);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(57, 22);
            this.labelStatus.Text = "status";
            this.labelStatus.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "DASHBOARD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Laporan Peminjaman";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(114, 227);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.SystemColors.ActiveCaption;
            series1.Legend = "Legend1";
            series1.Name = "Data Transaksi /bln";
            series1.ShadowColor = System.Drawing.Color.Gray;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(889, 307);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1098, 645);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 20);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDashboard";
            this.Text = "Perpustakaan Esemka - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormDashboard_Activated);
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUKUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRANSAKSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITAPPLICATIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUKUToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripMenuItem pEMINJAMANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pENGEMBALIANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dETAILTRANSAKSIToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}