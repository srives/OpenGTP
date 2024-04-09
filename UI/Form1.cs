using OpenGTP.Properties;
using UIHelper;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private int _minTimeout = 45; // give things this long to run

        private string Http
        {
            get
            {
                var isChecked = false;
                if (cbHttps.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => isChecked = cbHttps.Checked));
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
                var env = Safe.GetComboBoxText(this, cbEnv)?.ToLower() ?? string.Empty;
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
                    return $"{Http}://local";
                }

                if (env.StartsWith("prod"))
                {
                    return $"{Http}://api.gtpstratus.com";
                }

                return $"{Http}://api-{env}.gtpstratus.com";
            }
        }

        public Form1()
        {
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
        /// Build a URL with proper format, using ? and & signs as needed
        /// </summary>
        private static string AddParameter(string url, string name, string value)
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
    }
}
