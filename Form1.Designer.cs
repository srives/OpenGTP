namespace OpenGTP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cbReports = new ComboBox();
            label1 = new Label();
            apiKey = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnOpenAPI = new Button();
            cbProjects = new ComboBox();
            cbModels = new ComboBox();
            cbPackage = new ComboBox();
            btnFetch = new Button();
            label6 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            tbLink = new TextBox();
            label7 = new Label();
            btnCopy = new Button();
            cbHttps = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // cbReports
            // 
            cbReports.FormattingEnabled = true;
            cbReports.Location = new Point(107, 15);
            cbReports.Name = "cbReports";
            cbReports.Size = new Size(250, 23);
            cbReports.TabIndex = 2;
            cbReports.SelectedIndexChanged += OnReportChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 23);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Report";
            // 
            // apiKey
            // 
            apiKey.Location = new Point(105, 35);
            apiKey.Name = "apiKey";
            apiKey.Size = new Size(250, 23);
            apiKey.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 3;
            label2.Text = "Open API Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 169);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Pacakge";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 72);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 5;
            label4.Text = "Project";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 118);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 6;
            label5.Text = "Model";
            // 
            // btnOpenAPI
            // 
            btnOpenAPI.Location = new Point(374, 35);
            btnOpenAPI.Name = "btnOpenAPI";
            btnOpenAPI.Size = new Size(119, 23);
            btnOpenAPI.TabIndex = 1;
            btnOpenAPI.Text = "Apply Key";
            btnOpenAPI.UseVisualStyleBackColor = true;
            btnOpenAPI.Click += btnOpenAPI_Click;
            // 
            // cbProjects
            // 
            cbProjects.FormattingEnabled = true;
            cbProjects.Location = new Point(107, 64);
            cbProjects.Name = "cbProjects";
            cbProjects.Size = new Size(248, 23);
            cbProjects.TabIndex = 3;
            cbProjects.SelectedIndexChanged += OnProjectChange;
            // 
            // cbModels
            // 
            cbModels.FormattingEnabled = true;
            cbModels.Location = new Point(107, 115);
            cbModels.Name = "cbModels";
            cbModels.Size = new Size(248, 23);
            cbModels.TabIndex = 4;
            cbModels.SelectedIndexChanged += OnModelChanged;
            // 
            // cbPackage
            // 
            cbPackage.FormattingEnabled = true;
            cbPackage.Location = new Point(107, 166);
            cbPackage.Name = "cbPackage";
            cbPackage.Size = new Size(248, 23);
            cbPackage.TabIndex = 5;
            // 
            // btnFetch
            // 
            btnFetch.Enabled = false;
            btnFetch.Location = new Point(376, 15);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(119, 23);
            btnFetch.TabIndex = 12;
            btnFetch.Text = "Dashboard Report";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += OnReportFetch;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(105, 17);
            label6.Name = "label6";
            label6.Size = new Size(239, 15);
            label6.TabIndex = 13;
            label6.Text = "Get OpenAPI key from STRATUS->Company";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cbHttps);
            panel1.Controls.Add(cbProjects);
            panel1.Controls.Add(cbReports);
            panel1.Controls.Add(btnFetch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbPackage);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbModels);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(503, 209);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(apiKey);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnOpenAPI);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(503, 93);
            panel2.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(105, 61);
            label8.Name = "label8";
            label8.Size = new Size(162, 15);
            label8.TabIndex = 4;
            label8.Text = "Add to Power BI as \"app-key\"";
            // 
            // tbLink
            // 
            tbLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLink.Location = new Point(12, 379);
            tbLink.Name = "tbLink";
            tbLink.Size = new Size(500, 23);
            tbLink.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(12, 361);
            label7.Name = "label7";
            label7.Size = new Size(352, 15);
            label7.TabIndex = 3;
            label7.Text = "Paste this URL into Power BI under the \"Get data\" ->  Web option:";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.BackgroundImage = (Image)resources.GetObject("btnCopy.BackgroundImage");
            btnCopy.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopy.Location = new Point(483, 407);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(30, 28);
            btnCopy.TabIndex = 4;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // cbHttps
            // 
            cbHttps.AutoSize = true;
            cbHttps.CheckAlign = ContentAlignment.MiddleRight;
            cbHttps.Checked = true;
            cbHttps.CheckState = CheckState.Checked;
            cbHttps.Location = new Point(440, 170);
            cbHttps.Name = "cbHttps";
            cbHttps.Size = new Size(53, 19);
            cbHttps.TabIndex = 13;
            cbHttps.Text = "https";
            cbHttps.TextAlign = ContentAlignment.MiddleRight;
            cbHttps.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 445);
            Controls.Add(btnCopy);
            Controls.Add(label7);
            Controls.Add(tbLink);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "STRATUS Dashboard Reports";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbReports;
        private Label label1;
        private TextBox apiKey;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnOpenAPI;
        private ComboBox cbProjects;
        private ComboBox cbModels;
        private ComboBox cbPackage;
        private Button btnFetch;
        private Label label6;
        private Panel panel1;
        private Panel panel2;
        private TextBox tbLink;
        private Label label7;
        private Label label8;
        private Button btnCopy;
        private CheckBox cbHttps;
    }
}
