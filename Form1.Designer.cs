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
            button2 = new Button();
            button1 = new Button();
            label8 = new Label();
            tbLink = new TextBox();
            label7 = new Label();
            btnCopy = new Button();
            tbCompLoc = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnCompDir = new Button();
            btnGoldDir = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            label11 = new Label();
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
            btnFetch.Location = new Point(416, 130);
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
            cbEnv.Location = new Point(127, 88);
            cbEnv.Name = "cbEnv";
            cbEnv.Size = new Size(283, 23);
            cbEnv.TabIndex = 18;
            // 
            // cbHttps
            // 
            cbHttps.AutoSize = true;
            cbHttps.CheckAlign = ContentAlignment.MiddleRight;
            cbHttps.Checked = true;
            cbHttps.CheckState = CheckState.Checked;
            cbHttps.Location = new Point(416, 90);
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
            label9.Location = new Point(7, 30);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 17;
            label9.Text = "Golden Location";
            label9.Click += label9_Click;
            // 
            // tbGoldenLoc
            // 
            tbGoldenLoc.Location = new Point(127, 27);
            tbGoldenLoc.Name = "tbGoldenLoc";
            tbGoldenLoc.Size = new Size(260, 23);
            tbGoldenLoc.TabIndex = 16;
            tbGoldenLoc.Text = "c:\\repos\\GoldenReports";
            // 
            // button2
            // 
            button2.Location = new Point(416, 61);
            button2.Name = "button2";
            button2.Size = new Size(144, 23);
            button2.TabIndex = 15;
            button2.Text = "Compare to Golden";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(416, 27);
            button1.Name = "button1";
            button1.Size = new Size(144, 23);
            button1.TabIndex = 14;
            button1.Text = "Create Golden";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            tbCompLoc.Location = new Point(127, 62);
            tbCompLoc.Name = "tbCompLoc";
            tbCompLoc.Size = new Size(260, 23);
            tbCompLoc.TabIndex = 19;
            tbCompLoc.Text = "c:\\repos\\GoldenReports";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 65);
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
            groupBox1.Location = new Point(12, 464);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(574, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Power BI";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(btnCompDir);
            groupBox2.Controls.Add(btnGoldDir);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(tbCompLoc);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(tbGoldenLoc);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(12, 346);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(570, 100);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "QA Golden Compare";
            // 
            // btnCompDir
            // 
            btnCompDir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCompDir.Location = new Point(382, 61);
            btnCompDir.Name = "btnCompDir";
            btnCompDir.Size = new Size(18, 25);
            btnCompDir.TabIndex = 21;
            btnCompDir.UseVisualStyleBackColor = true;
            btnCompDir.Click += btnCompDir_Click;
            // 
            // btnGoldDir
            // 
            btnGoldDir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoldDir.Location = new Point(382, 26);
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
            groupBox3.Controls.Add(cbProjects);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(cbModels);
            groupBox3.Controls.Add(cbReports);
            groupBox3.Controls.Add(btnFetch);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cbPackage);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 155);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(570, 177);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Run Single Report";
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
            groupBox4.Size = new Size(570, 128);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Settings";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 93);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 19;
            label11.Text = "Environment";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 579);
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
        private Button button2;
        private Button button1;
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
    }
}
