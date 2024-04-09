namespace OpenGTP
{
    partial class CheckBoxListToggle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWhat = new Label();
            cbHideUnused = new CheckBox();
            btnToggleAllOn = new Button();
            btnToggleAllOff = new Button();
            btnToggleReportSelection = new Button();
            cbList = new CheckedListBox();
            SuspendLayout();
            // 
            // lblWhat
            // 
            lblWhat.AutoSize = true;
            lblWhat.BackColor = Color.Black;
            lblWhat.ForeColor = Color.LawnGreen;
            lblWhat.Location = new Point(3, 10);
            lblWhat.Name = "lblWhat";
            lblWhat.Size = new Size(83, 15);
            lblWhat.TabIndex = 2;
            lblWhat.Text = "Reports to Use";
            // 
            // cbHideUnused
            // 
            cbHideUnused.AutoSize = true;
            cbHideUnused.ForeColor = Color.LawnGreen;
            cbHideUnused.Location = new Point(301, 10);
            cbHideUnused.Name = "cbHideUnused";
            cbHideUnused.Size = new Size(94, 19);
            cbHideUnused.TabIndex = 38;
            cbHideUnused.Text = "Hide Unused";
            cbHideUnused.UseVisualStyleBackColor = true;
            cbHideUnused.CheckedChanged += cbHideUnused_CheckedChanged;
            // 
            // btnToggleAllOn
            // 
            btnToggleAllOn.FlatStyle = FlatStyle.Flat;
            btnToggleAllOn.ForeColor = Color.LawnGreen;
            btnToggleAllOn.Location = new Point(127, 4);
            btnToggleAllOn.Name = "btnToggleAllOn";
            btnToggleAllOn.Size = new Size(34, 28);
            btnToggleAllOn.TabIndex = 37;
            btnToggleAllOn.Text = "All";
            btnToggleAllOn.UseVisualStyleBackColor = true;
            btnToggleAllOn.Click += btnToggleAllOn_Click;
            // 
            // btnToggleAllOff
            // 
            btnToggleAllOff.FlatStyle = FlatStyle.Flat;
            btnToggleAllOff.ForeColor = Color.LawnGreen;
            btnToggleAllOff.Location = new Point(167, 4);
            btnToggleAllOff.Name = "btnToggleAllOff";
            btnToggleAllOff.Size = new Size(51, 28);
            btnToggleAllOff.TabIndex = 36;
            btnToggleAllOff.Text = "None";
            btnToggleAllOff.UseVisualStyleBackColor = true;
            btnToggleAllOff.Click += btnToggleAllOff_Click;
            // 
            // btnToggleReportSelection
            // 
            btnToggleReportSelection.FlatStyle = FlatStyle.Flat;
            btnToggleReportSelection.ForeColor = Color.LawnGreen;
            btnToggleReportSelection.Location = new Point(224, 4);
            btnToggleReportSelection.Name = "btnToggleReportSelection";
            btnToggleReportSelection.Size = new Size(54, 28);
            btnToggleReportSelection.TabIndex = 35;
            btnToggleReportSelection.Text = "Toggle";
            btnToggleReportSelection.UseVisualStyleBackColor = true;
            btnToggleReportSelection.Click += btnToggleSelection_Click;
            // 
            // cbListReports
            // 
            cbList.BackColor = Color.Black;
            cbList.BorderStyle = BorderStyle.None;
            cbList.ForeColor = Color.LawnGreen;
            cbList.FormattingEnabled = true;
            cbList.Location = new Point(3, 38);
            cbList.Name = "cbListReports";
            cbList.RightToLeft = RightToLeft.No;
            cbList.Size = new Size(405, 648);
            cbList.TabIndex = 39;
            cbList.ItemCheck += cbList_ItemCheck;
            // 
            // CheckBoxListToggle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(cbList);
            Controls.Add(cbHideUnused);
            Controls.Add(btnToggleAllOn);
            Controls.Add(btnToggleAllOff);
            Controls.Add(btnToggleReportSelection);
            Controls.Add(lblWhat);
            Name = "CheckBoxListToggle";
            Size = new Size(409, 702);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWhat;
        private CheckBox cbHideUnused;
        private Button btnToggleAllOn;
        private Button btnToggleAllOff;
        private Button btnToggleReportSelection;
        private CheckedListBox cbList;
    }
}
