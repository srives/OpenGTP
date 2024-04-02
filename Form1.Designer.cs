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
            cbEnv = new ComboBox();
            cbHttps = new CheckBox();
            label9 = new Label();
            tbGoldenLoc = new TextBox();
            btnCompareToGolden = new Button();
            btnCreateGolden = new Button();
            label8 = new Label();
            tbLink = new TextBox();
            label7 = new Label();
            btnCopy = new Button();
            tbCompLoc = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label12 = new Label();
            cbRunEveryPackage = new CheckBox();
            lblTotalTime = new Label();
            lblStartTime = new Label();
            lblProgress = new Label();
            btnCompDir = new Button();
            btnGoldDir = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox3 = new GroupBox();
            lblNumPackages = new Label();
            lblNumModels = new Label();
            lblNumPorjects = new Label();
            lblNumReports = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            numReports = new Label();
            groupBox4 = new GroupBox();
            label11 = new Label();
            cbZeroBytes = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // cbReports
            // 
            cbReports.FormattingEnabled = true;
            cbReports.Location = new Point(127, 30);
            cbReports.Name = "cbReports";
            cbReports.Size = new Size(283, 23);
            cbReports.TabIndex = 2;
            cbReports.SelectedIndexChanged += OnReportChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 33);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Report";
            // 
            // apiKey
            // 
            apiKey.Location = new Point(127, 37);
            apiKey.Name = "apiKey";
            apiKey.Size = new Size(283, 23);
            apiKey.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 40);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 3;
            label2.Text = "Open API Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 131);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Pacakge";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 67);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 5;
            label4.Text = "Project";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 99);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 6;
            label5.Text = "Model";
            // 
            // btnOpenAPI
            // 
            btnOpenAPI.Location = new Point(416, 37);
            btnOpenAPI.Name = "btnOpenAPI";
            btnOpenAPI.Size = new Size(144, 23);
            btnOpenAPI.TabIndex = 1;
            btnOpenAPI.Text = "Apply Key";
            btnOpenAPI.UseVisualStyleBackColor = true;
            btnOpenAPI.Click += btnOpenAPI_Click;
            // 
            // cbProjects
            // 
            cbProjects.FormattingEnabled = true;
            cbProjects.Location = new Point(127, 64);
            cbProjects.Name = "cbProjects";
            cbProjects.Size = new Size(283, 23);
            cbProjects.TabIndex = 3;
            cbProjects.SelectedIndexChanged += OnProjectChange;
            // 
            // cbModels
            // 
            cbModels.FormattingEnabled = true;
            cbModels.Location = new Point(127, 96);
            cbModels.Name = "cbModels";
            cbModels.Size = new Size(283, 23);
            cbModels.TabIndex = 4;
            cbModels.SelectedIndexChanged += OnModelChanged;
            // 
            // cbPackage
            // 
            cbPackage.FormattingEnabled = true;
            cbPackage.Location = new Point(127, 131);
            cbPackage.Name = "cbPackage";
            cbPackage.Size = new Size(283, 23);
            cbPackage.TabIndex = 5;
            // 
            // btnFetch
            // 
            btnFetch.Enabled = false;
            btnFetch.Location = new Point(416, 172);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(144, 23);
            btnFetch.TabIndex = 12;
            btnFetch.Text = "Dashboard Report";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += OnReportFetch;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(125, 19);
            label6.Name = "label6";
            label6.Size = new Size(239, 15);
            label6.TabIndex = 13;
            label6.Text = "Get OpenAPI key from STRATUS->Company";
            // 
            // cbEnv
            // 
            cbEnv.FormattingEnabled = true;
            cbEnv.Items.AddRange(new object[] { "QA", "PROD", "CI", "RC", "local" });
            cbEnv.Location = new Point(127, 78);
            cbEnv.Name = "cbEnv";
            cbEnv.Size = new Size(283, 23);
            cbEnv.TabIndex = 18;
            cbEnv.SelectedIndexChanged += OnEnvChanged;
            // 
            // cbHttps
            // 
            cbHttps.AutoSize = true;
            cbHttps.CheckAlign = ContentAlignment.MiddleRight;
            cbHttps.Checked = true;
            cbHttps.CheckState = CheckState.Checked;
            cbHttps.Location = new Point(416, 80);
            cbHttps.Name = "cbHttps";
            cbHttps.Size = new Size(53, 19);
            cbHttps.TabIndex = 13;
            cbHttps.Text = "https";
            cbHttps.TextAlign = ContentAlignment.MiddleRight;
            cbHttps.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 60);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 17;
            label9.Text = "Golden Location";
            // 
            // tbGoldenLoc
            // 
            tbGoldenLoc.Location = new Point(127, 57);
            tbGoldenLoc.Name = "tbGoldenLoc";
            tbGoldenLoc.Size = new Size(260, 23);
            tbGoldenLoc.TabIndex = 16;
            tbGoldenLoc.Text = "c:\\repos\\GoldenReports";
            // 
            // btnCompareToGolden
            // 
            btnCompareToGolden.Enabled = false;
            btnCompareToGolden.Location = new Point(416, 91);
            btnCompareToGolden.Name = "btnCompareToGolden";
            btnCompareToGolden.Size = new Size(144, 23);
            btnCompareToGolden.TabIndex = 15;
            btnCompareToGolden.Text = "Compare to Golden";
            btnCompareToGolden.UseVisualStyleBackColor = true;
            btnCompareToGolden.Click += btnCompareToGolden_Click;
            // 
            // btnCreateGolden
            // 
            btnCreateGolden.Enabled = false;
            btnCreateGolden.Location = new Point(416, 57);
            btnCreateGolden.Name = "btnCreateGolden";
            btnCreateGolden.Size = new Size(144, 23);
            btnCreateGolden.TabIndex = 14;
            btnCreateGolden.Text = "Create Golden";
            btnCreateGolden.UseVisualStyleBackColor = true;
            btnCreateGolden.Click += button_CreateGolden;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Consolas", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(321, 15);
            label8.Name = "label8";
            label8.Size = new Size(247, 13);
            label8.TabIndex = 4;
            label8.Text = "Add OpenAPI key to Power BI as \"app-key\"";
            // 
            // tbLink
            // 
            tbLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLink.Location = new Point(11, 61);
            tbLink.Name = "tbLink";
            tbLink.Size = new Size(521, 23);
            tbLink.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(11, 36);
            label7.Name = "label7";
            label7.Size = new Size(349, 15);
            label7.TabIndex = 3;
            label7.Text = "Paste this URL into Power BI under the \"Get data\" -> Web option:";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.BackgroundImage = (Image)resources.GetObject("btnCopy.BackgroundImage");
            btnCopy.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopy.Location = new Point(538, 57);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(30, 28);
            btnCopy.TabIndex = 4;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // tbCompLoc
            // 
            tbCompLoc.Location = new Point(127, 92);
            tbCompLoc.Name = "tbCompLoc";
            tbCompLoc.Size = new Size(260, 23);
            tbCompLoc.TabIndex = 19;
            tbCompLoc.Text = "c:\\repos\\GoldenReports";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 95);
            label10.Name = "label10";
            label10.Size = new Size(105, 15);
            label10.TabIndex = 18;
            label10.Text = "Compare Location";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(btnCopy);
            groupBox1.Controls.Add(tbLink);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 576);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(574, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Power BI";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(cbZeroBytes);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cbRunEveryPackage);
            groupBox2.Controls.Add(lblTotalTime);
            groupBox2.Controls.Add(lblStartTime);
            groupBox2.Controls.Add(lblProgress);
            groupBox2.Controls.Add(btnCompDir);
            groupBox2.Controls.Add(btnGoldDir);
            groupBox2.Controls.Add(btnCompareToGolden);
            groupBox2.Controls.Add(tbCompLoc);
            groupBox2.Controls.Add(btnCreateGolden);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(tbGoldenLoc);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(12, 368);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(570, 184);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "QA Golden Compare";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 127);
            label12.Name = "label12";
            label12.Size = new Size(59, 15);
            label12.TabIndex = 26;
            label12.Text = "Packages:";
            // 
            // cbRunEveryPackage
            // 
            cbRunEveryPackage.AutoSize = true;
            cbRunEveryPackage.Location = new Point(128, 127);
            cbRunEveryPackage.Name = "cbRunEveryPackage";
            cbRunEveryPackage.Size = new Size(234, 19);
            cbRunEveryPackage.TabIndex = 25;
            cbRunEveryPackage.Text = "Run Every Package as a Separate Report";
            cbRunEveryPackage.UseVisualStyleBackColor = true;
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(473, 152);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(59, 15);
            lblTotalTime.TabIndex = 24;
            lblTotalTime.Text = "Total time";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(382, 152);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(60, 15);
            lblStartTime.TabIndex = 23;
            lblStartTime.Text = "Start Time";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(127, 29);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(55, 15);
            lblProgress.TabIndex = 22;
            lblProgress.Text = "Progress:";
            // 
            // btnCompDir
            // 
            btnCompDir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCompDir.Location = new Point(382, 91);
            btnCompDir.Name = "btnCompDir";
            btnCompDir.Size = new Size(18, 25);
            btnCompDir.TabIndex = 21;
            btnCompDir.UseVisualStyleBackColor = true;
            btnCompDir.Click += btnCompDir_Click;
            // 
            // btnGoldDir
            // 
            btnGoldDir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoldDir.Location = new Point(382, 56);
            btnGoldDir.Name = "btnGoldDir";
            btnGoldDir.Size = new Size(18, 25);
            btnGoldDir.TabIndex = 20;
            btnGoldDir.UseVisualStyleBackColor = true;
            btnGoldDir.Click += btnGoldDir_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox3.Controls.Add(lblNumPackages);
            groupBox3.Controls.Add(lblNumModels);
            groupBox3.Controls.Add(lblNumPorjects);
            groupBox3.Controls.Add(lblNumReports);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(numReports);
            groupBox3.Controls.Add(cbProjects);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(cbModels);
            groupBox3.Controls.Add(cbReports);
            groupBox3.Controls.Add(btnFetch);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cbPackage);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 141);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(570, 212);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Run Single Report";
            // 
            // lblNumPackages
            // 
            lblNumPackages.AutoSize = true;
            lblNumPackages.Location = new Point(509, 132);
            lblNumPackages.Name = "lblNumPackages";
            lblNumPackages.Size = new Size(13, 15);
            lblNumPackages.TabIndex = 20;
            lblNumPackages.Text = "0";
            // 
            // lblNumModels
            // 
            lblNumModels.AutoSize = true;
            lblNumModels.Location = new Point(509, 99);
            lblNumModels.Name = "lblNumModels";
            lblNumModels.Size = new Size(13, 15);
            lblNumModels.TabIndex = 19;
            lblNumModels.Text = "0";
            // 
            // lblNumPorjects
            // 
            lblNumPorjects.AutoSize = true;
            lblNumPorjects.Location = new Point(509, 67);
            lblNumPorjects.Name = "lblNumPorjects";
            lblNumPorjects.Size = new Size(13, 15);
            lblNumPorjects.TabIndex = 18;
            lblNumPorjects.Text = "0";
            // 
            // lblNumReports
            // 
            lblNumReports.AutoSize = true;
            lblNumReports.Location = new Point(509, 35);
            lblNumReports.Name = "lblNumReports";
            lblNumReports.Size = new Size(13, 15);
            lblNumReports.TabIndex = 17;
            lblNumReports.Text = "0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(418, 132);
            label15.Name = "label15";
            label15.Size = new Size(90, 15);
            label15.TabIndex = 16;
            label15.Text = "Package Count:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(418, 99);
            label14.Name = "label14";
            label14.Size = new Size(80, 15);
            label14.TabIndex = 15;
            label14.Text = "Model Count:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(418, 67);
            label13.Name = "label13";
            label13.Size = new Size(83, 15);
            label13.TabIndex = 14;
            label13.Text = "Project Count:";
            // 
            // numReports
            // 
            numReports.AutoSize = true;
            numReports.Location = new Point(418, 35);
            numReports.Name = "numReports";
            numReports.Size = new Size(81, 15);
            numReports.TabIndex = 13;
            numReports.Text = "Report Count:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(cbEnv);
            groupBox4.Controls.Add(cbHttps);
            groupBox4.Controls.Add(btnOpenAPI);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(apiKey);
            groupBox4.Location = new Point(12, 10);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(570, 119);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Settings";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 83);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 19;
            label11.Text = "Environment";
            // 
            // cbZeroBytes
            // 
            cbZeroBytes.AutoSize = true;
            cbZeroBytes.Checked = true;
            cbZeroBytes.CheckState = CheckState.Checked;
            cbZeroBytes.Location = new Point(127, 152);
            cbZeroBytes.Name = "cbZeroBytes";
            cbZeroBytes.Size = new Size(143, 19);
            cbZeroBytes.TabIndex = 27;
            cbZeroBytes.Text = "Save zero-byte reports";
            cbZeroBytes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 691);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "STRATUS Report Generation and Testing";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
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
        private TextBox tbLink;
        private Label label7;
        private Label label8;
        private Button btnCopy;
        private CheckBox cbHttps;
        private Button btnCompareToGolden;
        private Button btnCreateGolden;
        private Label label9;
        private TextBox tbGoldenLoc;
        private ComboBox cbEnv;
        private TextBox tbCompLoc;
        private Label label10;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label11;
        private Button btnGoldDir;
        private Button btnCompDir;
        private Label label13;
        private Label numReports;
        private Label label15;
        private Label label14;
        private Label lblNumPackages;
        private Label lblNumModels;
        private Label lblNumPorjects;
        private Label lblNumReports;
        private Label lblProgress;
        private Label lblStartTime;
        private Label lblTotalTime;
        private Label label12;
        private CheckBox cbRunEveryPackage;
        private CheckBox cbZeroBytes;
    }
}
