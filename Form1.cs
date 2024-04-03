using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO.Packaging;
using System.Reflection;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Nodes;
using OpenGTP.Properties;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private List<NamedId> _reports = new List<NamedId>();
        private List<NamedId> _projects = new List<NamedId>();
        private List<NamedId> _models = new List<NamedId>();
        private List<NamedId> _packages = new List<NamedId>();
        private int _minTimeout = 45; // give things this long to run
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private string http
        {
            get
            {
                var isChecked = false;
                if (cbHttps.InvokeRequired)
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() => isChecked = cbHttps.Checked));
                }
                else
                {
                    isChecked = cbHttps.Checked;
                }

                if (cbHttps.Checked)
                {
                    return "https";
                }
                return "http";
            }
        }

        private string EnvLower
        {
            get
            {
                var env = string.Empty;
                if (cbEnv.InvokeRequired)
                {                    
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() => env = cbEnv.Text.ToLower()));
                }
                else
                {
                    env = cbEnv.Text.ToLower();
                }
                return env;
            }
        }

        private string URLRoot
        {
            get
            {
                var env = EnvLower;
                if (env.StartsWith("local"))
                {
                    return $"{http}://local";
                }

                if (env.StartsWith("prod"))
                {
                    return $"{http}://api.gtpstratus.com";
                }

                return $"{http}://api-{env}.gtpstratus.com";
            }
        }

        public Form1()
        {
            _cts = new CancellationTokenSource();
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            apiKey.Text = (string)Settings.Default["AppKey"];
            tbCompLoc.Text = (string)Settings.Default["CompLoc"];
            tbGoldenLoc.Text = (string)Settings.Default["GoldenLoc"];
            cbHttps.Checked = (bool)Settings.Default["https"];
            cbEnv.Text = (string)Settings.Default["Env"];
            if (cbEnv.Text == string.Empty)
            {
                cbEnv.Text = "PROD";
            }
        }

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
            Properties.Settings.Default.Save();
            var curr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            cbReports.Items.Clear();
            if (GetProjects(true) && GetListOfReports(true))
            {
                success = true;
            }
            btnFetch.Enabled = success;
            btnCompareToGolden.Enabled = success;
            btnCreateGolden.Enabled = success;
            Cursor.Current = curr;
        }

        /// <summary>
        /// Get a list of reports from STRATUS and put list in dropdown list
        /// </summary>
        private bool GetListOfReports(bool showError)
        {
            var success = true;
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var url = $"{URLRoot}/v1/company/reports";
            var reports = client.GetAsync(url).Result;

            cbReports.Items.Clear();
            cbReports.Items.Add(string.Empty);

            try
            {
                var res = reports.Content.ReadAsStringAsync().Result;
                _reports = JsonSerializer.Deserialize<List<NamedId>>(res);

                if (_reports != null)
                {
                    for (int i = 0; i < _reports.Count; i++)
                    {
                        var rep = _reports[i];
                        var name = rep.name;
                        cbReports.Items.Add(name);
                    }
                }
            }
            catch (Exception e)
            {
                success = false;
                if (showError)
                {
                    MessageBox.Show(url + Environment.NewLine + e.Message, "Reports Failed.");
                }
            }

            if (_reports == null)
            {
                _reports = new List<NamedId>();
            }

            lblNumReports.Text = $"{_reports.Count}";
            return success;
        }

        /// <summary>
        /// Get a list of projects from STRATUS and put each one in the projects dropdown list
        /// </summary>
        private bool GetProjects(bool showErrors)
        {
            var success = true;
            cbProjects.Items.Clear();
            cbProjects.Items.Add(string.Empty);
            cbProjects.SelectedIndex = 0;
            _projects = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{URLRoot}/v2/project";
            try
            {
                var json = client.GetAsync(uri).Result;
                var res = json.Content.ReadAsStringAsync().Result;
                var data = JsonSerializer.Deserialize<JsonObject>(res);
                if (data != null)
                {
                    var projects = data["data"] as JsonArray;
                    if (projects != null)
                    {
                        var len = projects.Count();
                        for (int i = 0; i < len; i++)
                        {
                            var item = projects[i];
                            string name = (string)item["name"];
                            string id = (string)item["id"];
                            _projects.Add(new NamedId() { name = name, id = id });
                            cbProjects.Items.Add(name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                success = false;
                if (showErrors)
                {
                    MessageBox.Show(uri + Environment.NewLine + e.Message, $"{cbEnv.Text} Projects Failed.");
                }
            }
            lblNumPorjects.Text = $"{_projects.Count}";
            return success;
        }

        private void ComboBoxAdd(ComboBox cb, string? value)
        {
            if (value != null)
            {
                if (cb.InvokeRequired)
                {
                    this.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                    {
                        cb.Items.Add(value);
                    }));
                }
                else
                {
                    cb.Items.Add(value);
                }
            }
        }

        private void ClearComboBox(ComboBox cb)
        {
            if (cb.InvokeRequired)
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(() => { 
                    cb.Items.Clear();
                    cb.Items.Add(string.Empty);
                    cb.SelectedIndex = 0;
                    cb.Refresh();
                }));
            }
            else
            {
                cb.Items.Clear();
                cb.Items.Add(string.Empty);
                cb.SelectedIndex = 0;
                cb.Refresh();
            }

        }
        /// <summary>
        /// Get a list of Models from STRATUS open API and put each one in the models dropdown list
        /// </summary>
        private bool GetModels(string projectId, bool showError)
        {
            var success = true;
            ClearComboBox(cbModels);
            SetLabel(lblNumModels, "0");
            _models = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{URLRoot}/v1/model?where=ProjectId%3D%22{projectId}%22";
            try
            {
                var json = client.GetAsync(uri).Result;
                var res = json.Content.ReadAsStringAsync().Result;
                var data = JsonSerializer.Deserialize<JsonObject>(res);
                if (data != null)
                {
                    var models = data["data"] as JsonArray;
                    if (models != null)
                    {
                        var len = models.Count();
                        for (int i = 0; i < len; i++)
                        {
                            var item = models[i];
                            string name = (string)item["name"];
                            string id = (string)item["id"];
                            _models.Add(new NamedId() { name = name, id = id });
                            ComboBoxAdd(cbModels, name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                success = false;
                if (showError)
                {
                    MessageBox.Show(uri + Environment.NewLine + e.Message, "Get Models Failed.");
                }
            }

            SetLabel(lblNumModels, $"{_models.Count}");
            return success;
        }

        /// <summary>
        /// Get a list of packages from STRATUS Open API for the given model
        /// </summary>
        private bool GetPackages(string modelId, bool showError)
        {
            var success = true;
            ClearComboBox(cbPackage);
            _packages = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{URLRoot}/v1/package?where=ModelId%3D%22{modelId}%22";

            try
            {
                var json = client.GetAsync(uri).Result;
                var res = json.Content.ReadAsStringAsync().Result;
                var data = JsonSerializer.Deserialize<JsonObject>(res);
                if (data != null)
                {
                    var packages = data["data"] as JsonArray;
                    if (packages != null)
                    {
                        var len = packages.Count();
                        for (int i = 0; i < len; i++)
                        {
                            var item = packages[i];
                            string name = (string)item["name"];
                            string id = (string)item["id"];
                            _packages.Add(new NamedId() { name = name, id = id });
                            ComboBoxAdd(cbPackage, name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                success = false;
                if (showError)
                {
                    MessageBox.Show(uri + Environment.NewLine + e.Message, "Get Packages Failed.");
                }
            }

            SetLabel(lblNumPackages, $"{_packages.Count}");
            return success;
        }

        /// <summary>
        /// Build a URL with proper format, using ? and & signs as needed
        /// </summary>
        private string AddParameter(string url, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!url.Contains("?"))
                {
                    url += "?";
                }
                else
                {
                    url += "&";
                }
                url += $"{name}={value}";
            }
            return url;
        }

        /// <summary>
        /// Given everything the user has selected, build a STRATUS Open API
        /// report url suitable for use in Power BI
        /// </summary>
        private string SetReportURL()
        {
            var reportId = string.Empty;
            var packageId = string.Empty;
            var projectId = string.Empty;
            var modelId = string.Empty;
            if (cbModels.SelectedItem != null)
            {
                var modelName = (string)cbModels.SelectedItem;
                var model = _models.Where(x => x.name == modelName).FirstOrDefault();
                if (model != null)
                {
                    modelId = model.id;
                }
            }
            if (cbProjects.SelectedItem != null)
            {
                var projectName = (string)cbProjects.SelectedItem;
                var project = _projects.Where(x => x.name == projectName).FirstOrDefault();
                if (project != null)
                {
                    projectId = project.id;
                }
            }
            if (cbPackage.SelectedItem != null)
            {
                var packageName = (string)cbPackage.SelectedItem;
                var package = _packages.Where(x => x.name == packageName).FirstOrDefault();
                if (package != null)
                {
                    packageId = package.id;
                }
            }
            if (cbReports.SelectedItem != null)
            {
                var reportName = (string)cbReports.SelectedItem;
                var report = _reports.Where(x => x.name == reportName).FirstOrDefault();
                if (report != null)
                {
                    reportId = report.id;
                }
            }

            var url = $"{URLRoot}/v1/package/dashboard";
            url = AddParameter(url, "projectId", projectId);
            url = AddParameter(url, "packageId", packageId);
            url = AddParameter(url, "modelId", modelId);
            url = AddParameter(url, "reportId", reportId);
            tbLink.Text = url;

            return url;
        }

        /// <summary>
        /// Run the package/dashboard report based on current report, project, model and pacakge
        /// Put the resulting data into a new window form
        /// </summary>
        private async Task<string?> RunReportAsync(bool showInDialog = true, string? url = null)
        {
            var csv = string.Empty;
            var curr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            var key = apiKey.Text;
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(_minTimeout);
            client.DefaultRequestHeaders.Add("app-key", key);

            if (string.IsNullOrEmpty(url))
            {
                url = SetReportURL(); // get the STRATUS Open API package/dashboard link
            }

            try
            {
                var json = await client.GetAsync(url);
                csv = await json.Content.ReadAsStringAsync();
                Cursor.Current = curr;
                if (showInDialog)
                {
                    ReportForm rf = new ReportForm();
                    rf.Set(csv);
                    rf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                if (showInDialog)
                {
                    MessageBox.Show(ex.Message, "Error.");
                }
            }

            return csv;
        }

        private void OnModelChanged(object sender, EventArgs e)
        {
            var selected = (string)cbModels.SelectedItem;
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

        private void OnProjectChange(object sender, EventArgs e)
        {
            var selected = (string)cbProjects.SelectedItem;
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

        private void OnReportFetch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(apiKey.Text))
            {
                MessageBox.Show("You must specify an OpenAPI Key.", "STRATUS AppKey");
                return;
            }
            RunReportAsync(true);
        }

        private void OnReportChanged(object sender, EventArgs e)
        {
            SetReportURL();
        }

        private void OnEnvChanged(object sender, EventArgs e)
        {
            var success = false;
            if (cbEnv.Text != (string)Settings.Default["Env"])
            {
                Settings.Default["Env"] = cbEnv.Text;
                Properties.Settings.Default.Save();
                lblNumReports.Text = "0";
                lblNumModels.Text = "0";
                lblNumPackages.Text = "0";
                lblNumPorjects.Text = "0";
                cbReports.Items.Clear();
                if (GetProjects(false) && GetListOfReports(false))
                {
                    success = true;
                }
                btnCreateGolden.Enabled = success;
                btnCompareToGolden.Enabled = success;
                btnFetch.Enabled = success;
            }
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
                Settings.Default["GoldenLoc"] = tbGoldenLoc.Text;
                Properties.Settings.Default.Save();
            }
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
                Settings.Default["CompLoc"] = tbCompLoc.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void SetLabel(Label lbl, string progress)
        {
            if (lbl.InvokeRequired)
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(() => lbl.Text = progress));
            }
            else
            {
                lbl.Text = progress;
            }
        }

        private void RunAllReports(string saveToPath, bool writeZeroByteFiles, BackgroundWorker worker, DoWorkEventArgs e)
        {
            var reports = 0;
            var projects = 0;
            var models = 0;
            var packages = 0;
            var errors = 0;

            if (string.IsNullOrEmpty(saveToPath))
            {
                MessageBox.Show("You must specify a location to save the files.", "Save Location");
                return;
            }

            if (saveToPath.EndsWith('\\'))
            {
                saveToPath = saveToPath.Substring(0, saveToPath.Length - 1);
            }

            if (!Directory.Exists(saveToPath))
            {
                Directory.CreateDirectory(saveToPath);
            }

            if (!Directory.Exists(saveToPath))
            {
                MessageBox.Show($"ERROR: {saveToPath} does not exist and could not be created.", "Save Location");
                return;
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            SetLabel(lblStartTime, $"Started {DateTime.Now.ToString("HH:mm")}");
            SetLabel(lblTotalTime, "Running...");

            // Loop through all reports, all projects, all models, all packages
            // and create a golden file for each one
            foreach (var report in _reports)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                reports++;
                projects = 0;
                models = 0;
                packages = 0;
                SetLabel(lblProgress, $"Report {reports} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
                foreach (var project in _projects)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    projects++;
                    models = 0;
                    packages = 0;
                    SetLabel(lblProgress, $"Report {reports} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
                    if (!GetModels(project.id, false))
                    {
                        errors++;
                    }

                    foreach (var model in _models)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                        models++;
                        SetLabel(lblProgress, $"Report {reports} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
                        var url = $"{URLRoot}/v1/package/dashboard?projectId={project.id}&modelId={model.id}&reportId={report.id}";
                        var csv = RunReportAsync(false, url).Result;
                        if (!string.IsNullOrEmpty(csv) || writeZeroByteFiles)
                        {
                            var fname = $"{saveToPath}\\{Clean(report.name)}{Clean(project.name)}{Clean(model.name)}.csv";
                            File.WriteAllText(fname, csv);
                        }

                        if (cbRunEveryPackage.Checked == true)
                        {
                            packages = 0;
                            GetPackages(model.id, false);
                            foreach (var package in _packages)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                packages++;
                                SetLabel(lblProgress, $"Report {reports} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Package {packages} of {_packages.Count}. *({errors})");
                                url = $"{URLRoot}/v1/package/dashboard?projectId={project.id}&packageId={package.id}&modelId={model.id}&reportId={report.id}";
                                csv = RunReportAsync(false, url).Result;
                                if (!string.IsNullOrEmpty(csv) || writeZeroByteFiles)
                                {
                                    var fname = $"{saveToPath}\\{Clean(report.name)}{Clean(project.name)}{Clean(model.name)}{Clean(package.name)}.csv";
                                    File.WriteAllText(fname, csv);
                                }
                            }
                        }
                    }
                }
            }

            timer.Stop();
            SetLabel(lblTotalTime, $"{timer.Elapsed.TotalHours:F2} hours");
        }

        private void btnCompareToGolden_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                btnStop.Enabled = true;
                backgroundWorker.RunWorkerAsync(1);
            }
        }

        private void button_CreateGolden(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                btnStop.Enabled = true;
                backgroundWorker.RunWorkerAsync(2);
            }
        }

        private string Clean(string s)
        {
            string ret = s.Replace(" ", "-").Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace("\0", "")
                    .Replace("&", "-").Replace("?", "").Replace("=", "").Replace(":", "").Replace(";", "")
                    .Replace("!", "").Replace("@", "").Replace("#", "").Replace("|", "").Replace("\\", "")
                    .Replace("$", "").Replace("%", "").Replace("^", "").Replace("*", "").Replace("/", "-")
                    .Replace("\"", "-").Replace("'", "").Replace("`", "").Replace("~", "-").Replace("+", "")
                    .Replace("<", "").Replace(">", "").Replace("=", "").Replace("--", "-").Replace("--", "-").Replace("--", "-");
            return $"[{ret}]_";

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            _cts.Cancel();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            RunAllReports(tbGoldenLoc.Text, cbZeroBytes.Checked, backgroundWorker, e);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
