using OpenGTP.Properties;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Button when they apply the App Key
        /// </summary>
        private void btnOpenAPI_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (string.IsNullOrEmpty(apiKey.Text))
            {
                MessageBox.Show("You must specify an OpenAPI Key.", "STRATUS AppKey");
                return;
            }
            Settings.Default["AppKey"] = apiKey.Text;
            Settings.Default.Save();
            var curr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            cbReports.Items.Clear();
            if (GetProjects(true) && GetReportsList(true))
            {
                success = true;
            }
            btnRunOneReport.Visible = success;
            btnCreateCompFiles.Visible = success;
            btnCreateGolden.Visible = success;
            Cursor.Current = curr;
        }

        private void OnProjectChange(object sender, EventArgs e)
        {
            var selected = (string?)cbProjects?.SelectedItem;
            var project = _projects.Where(x => x.name == selected).FirstOrDefault();
            SetReportURL();
            if (project != null)
            {
                var curr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                GetModels(project.id, true);
                Cursor.Current = curr;
                Refresh();
            }
        }

        private void OnModelChanged(object sender, EventArgs e)
        {
            var selected = (string?)cbModels.SelectedItem;
            var model = _models.Where(x => x.name == selected).FirstOrDefault();
            SetReportURL();
            if (model != null)
            {
                var curr = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                GetPackages(model.id, true);
                Cursor.Current = curr;
                Refresh();
            }
        }

        private void OnReportChanged(object sender, EventArgs e)
        {
            SetReportURL();
        }

        private void OnEnvChanged(object sender, EventArgs e)
        {
            var success = false;
            if (cbEnv.Text != (string?)Settings.Default["Env"])
            {
                Settings.Default["Env"] = cbEnv.Text;
                Properties.Settings.Default.Save();
                lblNumReports.Text = "0";
                lblNumModels.Text = "0";
                lblNumPackages.Text = "0";
                lblNumPorjects.Text = "0";
                cbReports.Items.Clear();
                if (GetProjects(false) && GetReportsList(false))
                {
                    success = true;
                }
                btnCreateGolden.Visible = success;
                btnCreateCompFiles.Visible = success;
                btnRunOneReport.Visible = success;
            }
        }

        private void OnRunOneReport(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(apiKey.Text))
            {
                MessageBox.Show("You must specify an OpenAPI Key.", "STRATUS AppKey");
                return;
            }
            RunOneReport(true);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbLink.Text);
        }

        private void btnGoldDir_Click(object sender, EventArgs e)
        {
            // Open file dialog to get the Gold Directory
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Select the directory location of the Golden files";
            dialog.ShowNewFolderButton = false;
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.SelectedPath = @"C:\";
            if (!string.IsNullOrEmpty((string)Settings.Default["GoldenLoc"]))
            {
                dialog.SelectedPath = (string)Settings.Default["GoldenLoc"];
            }
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbGoldenLoc.Text = dialog.SelectedPath;
                SaveReportPaths();
            }
        }

        private void SaveReportPaths()
        {
            var goldPath = GetTextBoxText(tbGoldenLoc);
            Settings.Default["GoldenLoc"] = goldPath;
            var compPath = GetTextBoxText(tbCompLoc);
            Settings.Default["CompLoc"] = compPath;
            Settings.Default.Save();
        }

        private void btnCompDir_Click(object sender, EventArgs e)
        {
            // Open file dialog to get the Comp Directory
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Pick a location to save temp files, which will compare to the golden.";
            dialog.ShowNewFolderButton = false;
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.SelectedPath = @"C:\";
            if (!string.IsNullOrEmpty((string)Settings.Default["CompLoc"]))
            {
                dialog.SelectedPath = (string)Settings.Default["CompLoc"];
            }
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbCompLoc.Text = dialog.SelectedPath;
                SaveReportPaths();
            }
        }

        private void btnCreateCompFiles_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                SaveReportPaths();
                btnStop.Visible = true;
                pbProgressBar.Visible = true;
                backgroundWorker.RunWorkerAsync(tbCompLoc.Text);
            }
        }

        private void button_CreateGolden(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                SaveReportPaths();
                btnStop.Visible = true;
                pbProgressBar.Visible = true;
                backgroundWorker.RunWorkerAsync(tbGoldenLoc.Text); // calls BackgroundWorker_DoWork()
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync(); // calls BackgroundWorker_DoWork()
        }
    }
}