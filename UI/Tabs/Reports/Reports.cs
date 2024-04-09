using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.Json;
using UIHelper;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private List<string> _reportListCache = [];
        private List<NamedId> _reports = [];
        private List<NamedId> _projects = [];
        private List<NamedId> _models = [];
        private List<NamedId> _packages = [];
        private int _progress = 0; // used for progress bar

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
        /// Get a list of Models from STRATUS open API and put each one in the models dropdown list
        /// </summary>
        private bool GetModels(string projectId, bool showError)
        {
            var success = true;
            Safe.ClearComboBox(this, cbModels);
            Safe.SetLabel(this, lblNumModels, "0");
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
                            Safe.ComboBoxAdd(this, cbModels, name);
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

            Safe.SetLabel(this, lblNumModels, $"{_models.Count}");
            return success;
        }

        /// <summary>
        /// Get a list of packages from STRATUS Open API for the given model
        /// </summary>
        private bool GetPackages(string modelId, bool showError)
        {
            var success = true;
            Safe.ClearComboBox(this, cbPackage);
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
                            Safe.ComboBoxAdd(this, cbPackage, name);
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

            Safe.SetLabel(this, lblNumPackages, $"{_packages.Count}");
            return success;
        }

        /// <summary>
        /// Get a list of reports from STRATUS and put list in dropdown list
        /// </summary>
        private bool GetReportsList(bool showError)
        {
            var success = true;
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var url = $"{URLRoot}/v1/company/reports";
            var reports = client.GetAsync(url).Result;

            cbListReports.Items.Clear();
            cbReports.Items.Clear();
            cbReports.Items.Add(string.Empty);
            _reportListCache.Clear();

            try
            {
                var res = reports.Content.ReadAsStringAsync().Result;
                _reports = JsonSerializer.Deserialize<List<NamedId>>(res) ?? [];

                for (int i = 0; i < _reports.Count; i++)
                {
                    var rep = _reports[i];
                    var name = rep.name;
                    cbReports.Items.Add(name);
                    cbListReports.Items.Add(name);
                    _reportListCache.Add(name);
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

            MatchScreenChecksToSavedChecks();
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
                if (data != null && data?["data"] is JsonArray)
                {
                    var projects = data["data"] as JsonArray;
                    if (projects != null)
                    {
                        var len = projects.Count;
                        for (int i = 0; i < len; i++)
                        {
                            var item = projects[i];
                            var name = (string?)item?["name"];
                            var id = (string?)item?["id"];
                            if (name != null && id != null)
                            {
                                _projects.Add(new NamedId() { name = name, id = id });
                                cbProjects.Items.Add(name);
                            }
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
            cbtProjects.Init(_projects, "Projects to use", "SelectedProjects");
            return success;
        }

        /// <summary>
        /// Run the package/dashboard report based on current report, project, model and pacakge
        /// Put the resulting data into a new window form
        /// </summary>
        private (string?, double) RunOneReport(bool showInDialog = true, string? url = null)
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

            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {                
                var json = client.GetAsync(url).Result;
                sw.Stop();
                csv = json.Content.ReadAsStringAsync().Result;
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
                sw.Stop();
                if (showInDialog)
                {
                    MessageBox.Show(ex.Message, "Error.");
                }
            }
            var totalMS = sw.Elapsed.TotalMilliseconds;
            return (csv, totalMS);
        }

        private List<string> GetCheckedReports()
        {
            List<string> ret = [];
            if (cbListReports.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    ret = cbListReports.CheckedItems.Cast<string>().ToList();
                }));
            }
            else
            {
                ret = cbListReports.CheckedItems.Cast<string>().ToList();
            }
            return ret;
        }

        private void RunAllReports(string saveToPath, bool writeZeroByteFiles, BackgroundWorker worker, DoWorkEventArgs e)
        {
            var errors = 0;
            _progress = 0;
            int projects;
            int models;
            int packages;

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

            Stopwatch timer = new ();
            timer.Start();
            Safe.SetLabel(this, lblStartTime, $"Started {DateTime.Now.ToString("HH:mm")}");
            Safe.SetLabel(this, lblTotalTime, "Running...");
            var checkedReports = GetCheckedReports();

            // Loop through all reports, all projects, all models, all packages
            // and create a golden file for each one
            foreach (var report in _reports)
            {                
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (string.IsNullOrEmpty(report.name) || !checkedReports.Contains(report.name))
                {
                    continue;
                }
                _progress++;
                projects = 0;
                models = 0;
                packages = 0;
                Safe.SetLabel(this, lblProgress, $"Report {_progress} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
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
                    Safe.SetLabel(this, lblProgress, $"Report {_progress} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
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
                        Safe.SetLabel(this, lblProgress, $"Report {_progress} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Packages {_packages.Count}. *({errors})");
                        var url = $"{URLRoot}/v1/package/dashboard?projectId={project.id}&modelId={model.id}&reportId={report.id}";
                        Write(url, writeZeroByteFiles, saveToPath, report.name, project.name, model.name, string.Empty);

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
                                Safe.SetLabel(this, lblProgress, $"Report {_progress} of {_reports.Count}, Project {projects} of {_projects.Count}, Model {models} of {_models.Count}, Package {packages} of {_packages.Count}. *({errors})");
                                url = $"{URLRoot}/v1/package/dashboard?projectId={project.id}&packageId={package.id}&modelId={model.id}&reportId={report.id}";
                                Write(url, writeZeroByteFiles, saveToPath, report.name, project.name, model.name, package.name);
                            }
                        }
                    }
                }
            }

            timer.Stop();
            Safe.SetLabel(this, lblTotalTime, $"{timer.Elapsed.TotalHours:F2} hours");
        }

        private void Write(string url, bool writeZeroByteFiles, string saveToPath, string report, string project, string model, string package)
        {
            var (csv, timeMS) = RunOneReport(false, url);
            if (!string.IsNullOrEmpty(csv) || writeZeroByteFiles)
            {
                var fname = $"{saveToPath}\\{Clean(report)}{Clean(project)}{Clean(model)}{Clean(package)}.csv";
                File.WriteAllText(fname, csv);
                fname = $"{saveToPath}\\{Clean(report)}{Clean(project)}{Clean(model)}{Clean(package)}.time";
                File.WriteAllText(fname, timeMS.ToString());
            }
        }
    }
}
