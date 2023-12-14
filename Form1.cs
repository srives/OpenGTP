using System;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Nodes;
using OpenGTP.Properties;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private List<NamedId> _reports = new List<NamedId>();
        private List<NamedId> _projects = new List<NamedId>();
        private List<NamedId> _models = new List<NamedId>();
        private List<NamedId> _packages = new List<NamedId>();
        private int minTimeout = 45; // give things this long to run

        private string http {
            get 
            {
                if (cbHttps.Checked)
                    return "https";
                return "http";
            } 
        }

        public Form1()
        {
            InitializeComponent();
            apiKey.Text = (string)Settings.Default["AppKey"];
        }

        /// <summary>
        /// Button when they apply the App Key
        /// </summary>
        private void btnOpenAPI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(apiKey.Text))
            {
                MessageBox.Show("You must specify an OpenAPI Key.", "STRATUS AppKey");
                return;
            }
            Settings.Default["AppKey"] = apiKey.Text;
            Properties.Settings.Default.Save();
            var curr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            btnFetch.Enabled = true;
            GetProjects();
            GetReports();
            Cursor.Current = curr;
        }


        /// <summary>
        /// Get a list of reports from STRATUS and put list in dropdown list
        /// </summary>
        private void GetReports()
        {
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var url = $"{http}://api.gtpstratus.com/v1/company/reports";
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
                MessageBox.Show(url + Environment.NewLine + e.Message, "Reports Failed.");
            }
        }

        /// <summary>
        /// Get a list of projects from STRATUS and put each one in the projects dropdown list
        /// </summary>
        private void GetProjects()
        {
            cbProjects.Items.Clear();
            cbProjects.Items.Add(string.Empty);
            cbProjects.SelectedIndex = 0;
            _projects = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{http}://api.gtpstratus.com/v2/project";
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
                MessageBox.Show(uri + Environment.NewLine + e.Message, "Projects Failed.");
            }
        }

        /// <summary>
        /// Get a list of Models from STRATUS open API and put each one in the models dropdown list
        /// </summary>
        private void GetModels(string projectId)
        {
            cbModels.Items.Clear();
            cbModels.Items.Add(string.Empty);
            cbModels.SelectedIndex = 0;
            cbModels.Refresh();
            _models = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{http}://api.gtpstratus.com/v1/model?where=ProjectId%3D%22{projectId}%22";
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
                            cbModels.Items.Add(name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(uri + Environment.NewLine + e.Message, "Get Models Failed.");
            }
        }

        /// <summary>
        /// Get a list of packages from STRATUS Open API for the given model
        /// </summary>
        private void GetPackages(string modelId)
        {
            cbPackage.Items.Clear();
            cbPackage.Items.Add(string.Empty);
            cbPackage.SelectedIndex = 0;
            cbPackage.Refresh();
            _packages = new List<NamedId>();
            var key = apiKey.Text;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("app-key", key);
            var uri = $"{http}://api.gtpstratus.com/v1/package?where=ModelId%3D%22{modelId}%22";

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
                            cbPackage.Items.Add(name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(uri + Environment.NewLine + e.Message, "Get Packages Failed.");
            }

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

            var url = $"{http}://api.gtpstratus.com/v1/package/dashboard";
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
        private void RunReport()
        {
            var curr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            var key = apiKey.Text;
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(minTimeout); 
            client.DefaultRequestHeaders.Add("app-key", key);
            var url = SetReportURL(); // get the STRATUS Open API package/dashboard link
            try
            {
                var json = client.GetAsync(url).Result;
                var csv = json.Content.ReadAsStringAsync().Result;
                Cursor.Current = curr;
                ReportForm rf = new ReportForm();
                rf.Set(csv);
                rf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.");
            }
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
                GetPackages(model.id);
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
                GetModels(project.id);
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
            RunReport();
        }

        private void OnReportChanged(object sender, EventArgs e)
        {
            SetReportURL();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbLink.Text);
        }
    }
}
