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
            openFileDialog1 = new OpenFileDialog();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            lblNumPackages = new Label();
            lblNumModels = new Label();
            lblNumPorjects = new Label();
            lblNumReports = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            numReports = new Label();
            cbProjects = new ComboBox();
            label1 = new Label();
            label4 = new Label();
            cbModels = new ComboBox();
            cbReports = new ComboBox();
            btnFetch = new Button();
            label5 = new Label();
            cbPackage = new ComboBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            label11 = new Label();
            cbEnv = new ComboBox();
            cbHttps = new CheckBox();
            btnOpenAPI = new Button();
            label2 = new Label();
            label6 = new Label();
            apiKey = new TextBox();
            groupBox1 = new GroupBox();
            btnCopy = new Button();
            tbLink = new TextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox2 = new GroupBox();
            pbProgressBar = new ProgressBar();
            button1 = new Button();
            btnStop = new Button();
            cbZeroBytes = new CheckBox();
            cbRunEveryPackage = new CheckBox();
            lblTotalTime = new Label();
            lblStartTime = new Label();
            lblProgress = new Label();
            btnCompDir = new Button();
            btnGoldDir = new Button();
            btnCreateCompFiles = new Button();
            tbCompLoc = new TextBox();
            btnCreateGolden = new Button();
            label9 = new Label();
            tbGoldenLoc = new TextBox();
            label10 = new Label();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-6, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1024, 751);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1016, 723);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Reports";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom;
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
            groupBox3.Location = new Point(27, 143);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(570, 212);
            groupBox3.TabIndex = 12;
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
            // cbProjects
            // 
            cbProjects.FormattingEnabled = true;
            cbProjects.Location = new Point(127, 64);
            cbProjects.Name = "cbProjects";
            cbProjects.Size = new Size(283, 23);
            cbProjects.TabIndex = 3;
            cbProjects.SelectedIndexChanged += OnProjectChange;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 67);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 5;
            label4.Text = "Project";
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
            // cbReports
            // 
            cbReports.FormattingEnabled = true;
            cbReports.Location = new Point(127, 30);
            cbReports.Name = "cbReports";
            cbReports.Size = new Size(283, 23);
            cbReports.TabIndex = 2;
            cbReports.SelectedIndexChanged += OnReportChanged;
            // 
            // btnFetch
            // 
            btnFetch.Enabled = false;
            btnFetch.Location = new Point(416, 172);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(64, 23);
            btnFetch.TabIndex = 12;
            btnFetch.Text = "Run One";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += OnRunOneReport;
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
            // cbPackage
            // 
            cbPackage.FormattingEnabled = true;
            cbPackage.Location = new Point(127, 131);
            cbPackage.Name = "cbPackage";
            cbPackage.Size = new Size(283, 23);
            cbPackage.TabIndex = 5;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(cbEnv);
            groupBox4.Controls.Add(cbHttps);
            groupBox4.Controls.Add(btnOpenAPI);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(apiKey);
            groupBox4.Location = new Point(27, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(570, 119);
            groupBox4.TabIndex = 11;
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
            // cbEnv
            // 
            cbEnv.FormattingEnabled = true;
            cbEnv.Items.AddRange(new object[] { "QA", "PROD", "CI", "RC", "Staging", "local" });
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
            // btnOpenAPI
            // 
            btnOpenAPI.Location = new Point(416, 37);
            btnOpenAPI.Name = "btnOpenAPI";
            btnOpenAPI.Size = new Size(64, 23);
            btnOpenAPI.TabIndex = 1;
            btnOpenAPI.Text = "Use Key";
            btnOpenAPI.UseVisualStyleBackColor = true;
            btnOpenAPI.Click += btnOpenAPI_Click;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(125, 19);
            label6.Name = "label6";
            label6.Size = new Size(239, 15);
            label6.TabIndex = 13;
            label6.Text = "Get OpenAPI key from STRATUS->Company";
            // 
            // apiKey
            // 
            apiKey.Location = new Point(127, 37);
            apiKey.Name = "apiKey";
            apiKey.Size = new Size(283, 23);
            apiKey.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(btnCopy);
            groupBox1.Controls.Add(tbLink);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(27, 617);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(570, 87);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Power BI";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.BackgroundImage = (Image)resources.GetObject("btnCopy.BackgroundImage");
            btnCopy.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopy.Font = new Font("Segoe UI", 11.25F);
            btnCopy.Location = new Point(528, 45);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(30, 28);
            btnCopy.TabIndex = 4;
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // tbLink
            // 
            tbLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLink.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbLink.Location = new Point(11, 48);
            tbLink.Name = "tbLink";
            tbLink.Size = new Size(517, 23);
            tbLink.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Location = new Point(9, 30);
            label7.Name = "label7";
            label7.Size = new Size(349, 15);
            label7.TabIndex = 3;
            label7.Text = "Paste this URL into Power BI under the \"Get data\" -> Web option:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Consolas", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(315, 13);
            label8.Name = "label8";
            label8.Size = new Size(247, 13);
            label8.TabIndex = 4;
            label8.Text = "Add OpenAPI key to Power BI as \"app-key\"";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom;
            groupBox2.Controls.Add(pbProgressBar);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnStop);
            groupBox2.Controls.Add(cbZeroBytes);
            groupBox2.Controls.Add(cbRunEveryPackage);
            groupBox2.Controls.Add(lblTotalTime);
            groupBox2.Controls.Add(lblStartTime);
            groupBox2.Controls.Add(lblProgress);
            groupBox2.Controls.Add(btnCompDir);
            groupBox2.Controls.Add(btnGoldDir);
            groupBox2.Controls.Add(btnCreateCompFiles);
            groupBox2.Controls.Add(tbCompLoc);
            groupBox2.Controls.Add(btnCreateGolden);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(tbGoldenLoc);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(27, 371);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(570, 227);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "QA Golden Compare";
            // 
            // pbProgressBar
            // 
            pbProgressBar.Location = new Point(0, 217);
            pbProgressBar.Name = "pbProgressBar";
            pbProgressBar.Size = new Size(569, 10);
            pbProgressBar.TabIndex = 30;
            pbProgressBar.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(416, 166);
            button1.Name = "button1";
            button1.Size = new Size(64, 23);
            button1.TabIndex = 29;
            button1.Text = "Compare";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(416, 21);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(64, 23);
            btnStop.TabIndex = 28;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // cbZeroBytes
            // 
            cbZeroBytes.AutoSize = true;
            cbZeroBytes.Checked = true;
            cbZeroBytes.CheckState = CheckState.Checked;
            cbZeroBytes.Location = new Point(125, 148);
            cbZeroBytes.Name = "cbZeroBytes";
            cbZeroBytes.Size = new Size(143, 19);
            cbZeroBytes.TabIndex = 27;
            cbZeroBytes.Text = "Save zero-byte reports";
            cbZeroBytes.UseVisualStyleBackColor = true;
            // 
            // cbRunEveryPackage
            // 
            cbRunEveryPackage.AutoSize = true;
            cbRunEveryPackage.Location = new Point(125, 123);
            cbRunEveryPackage.Name = "cbRunEveryPackage";
            cbRunEveryPackage.Size = new Size(234, 19);
            cbRunEveryPackage.TabIndex = 25;
            cbRunEveryPackage.Text = "Run Every Package as a Separate Report";
            cbRunEveryPackage.UseVisualStyleBackColor = true;
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(121, 174);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(59, 15);
            lblTotalTime.TabIndex = 24;
            lblTotalTime.Text = "Total time";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(11, 174);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(60, 15);
            lblStartTime.TabIndex = 23;
            lblStartTime.Text = "Start Time";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(11, 25);
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
            // btnCreateCompFiles
            // 
            btnCreateCompFiles.Enabled = false;
            btnCreateCompFiles.Location = new Point(416, 91);
            btnCreateCompFiles.Name = "btnCreateCompFiles";
            btnCreateCompFiles.Size = new Size(64, 23);
            btnCreateCompFiles.TabIndex = 15;
            btnCreateCompFiles.Text = "Get";
            btnCreateCompFiles.UseVisualStyleBackColor = true;
            btnCreateCompFiles.Click += btnCreateCompFiles_Click;
            // 
            // tbCompLoc
            // 
            tbCompLoc.Location = new Point(127, 92);
            tbCompLoc.Name = "tbCompLoc";
            tbCompLoc.Size = new Size(260, 23);
            tbCompLoc.TabIndex = 19;
            tbCompLoc.Text = "c:\\repos\\GoldenReports";
            // 
            // btnCreateGolden
            // 
            btnCreateGolden.Enabled = false;
            btnCreateGolden.Location = new Point(416, 57);
            btnCreateGolden.Name = "btnCreateGolden";
            btnCreateGolden.Size = new Size(64, 23);
            btnCreateGolden.TabIndex = 14;
            btnCreateGolden.Text = "Get";
            btnCreateGolden.UseVisualStyleBackColor = true;
            btnCreateGolden.Click += button_CreateGolden;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 95);
            label10.Name = "label10";
            label10.Size = new Size(105, 15);
            label10.TabIndex = 18;
            label10.Text = "Compare Location";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1016, 723);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Permissions";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 746);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "STRATUS Report Generation and Testing";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private Label lblNumPackages;
        private Label lblNumModels;
        private Label lblNumPorjects;
        private Label lblNumReports;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label numReports;
        private ComboBox cbProjects;
        private Label label1;
        private Label label4;
        private ComboBox cbModels;
        private ComboBox cbReports;
        private Button btnFetch;
        private Label label5;
        private ComboBox cbPackage;
        private Label label3;
        private GroupBox groupBox4;
        private Label label11;
        private ComboBox cbEnv;
        private CheckBox cbHttps;
        private Button btnOpenAPI;
        private Label label2;
        private Label label6;
        private TextBox apiKey;
        private GroupBox groupBox1;
        private Button btnCopy;
        private TextBox tbLink;
        private Label label7;
        private Label label8;
        private GroupBox groupBox2;
        private Button button1;
        private Button btnStop;
        private CheckBox cbZeroBytes;
        private CheckBox cbRunEveryPackage;
        private Label lblTotalTime;
        private Label lblStartTime;
        private Label lblProgress;
        private Button btnCompDir;
        private Button btnGoldDir;
        private Button btnCreateCompFiles;
        private TextBox tbCompLoc;
        private Button btnCreateGolden;
        private Label label9;
        private TextBox tbGoldenLoc;
        private Label label10;
        private TabPage tabPage2;
        private ProgressBar pbProgressBar;
    }
}
