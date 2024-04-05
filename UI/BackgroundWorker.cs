
namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }
            var path = (string)e.Argument;
            RunAllReports(path, cbZeroBytes.Checked, backgroundWorker, e);
        }

        private void BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (_reports == null || _reports.Count == 0)
            {
                return;
            }
            var percent = (int)(((double)_progress / (double)_reports.Count) * 100.0);
            if (pbProgressBar.InvokeRequired)
            {
                pbProgressBar.Invoke(new Action(() => pbProgressBar.Value = percent));
            }
            else
            {
                pbProgressBar.Value = percent;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (pbProgressBar.InvokeRequired)
            {
                pbProgressBar.Invoke(new Action(() => pbProgressBar.Visible = false));
            }
            else
            {
                pbProgressBar.Visible = false;
            }
            if (btnStop.InvokeRequired)
            {
                btnStop.Invoke(new Action(() => pbProgressBar.Enabled = false));
            }
            else
            {
                btnStop.Enabled = false;
            }

        }

    }

}
