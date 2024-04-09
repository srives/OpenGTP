using OpenGTP.Properties;
using System.Collections.Specialized;

namespace OpenGTP
{
    public partial class Form1 : Form
    {
        private void btnToggleReportSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbListReports.Items.Count; i++)
            {
                var item = cbListReports.Items[i];
                cbListReports.SetItemChecked(cbListReports.Items.IndexOf(item), !cbListReports.GetItemChecked(cbListReports.Items.IndexOf(item)));
            }
        }

        private void btnToggleAllOn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbListReports.Items.Count; i++)
            {
                var item = cbListReports.Items[i];
                cbListReports.SetItemChecked(cbListReports.Items.IndexOf(item), true);
            }
        }

        private void btnToggleAllOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbListReports.Items.Count; i++)
            {
                var item = cbListReports.Items[i];
                cbListReports.SetItemChecked(cbListReports.Items.IndexOf(item), false);
            }
        }

        private bool IsReportCheckedInSettings(string name)
        {
            if (Settings.Default["SelectedReports"] is StringCollection stringCollection)
            {
                if (stringCollection != null)
                {
                    if (stringCollection.Contains(name) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void MatchScreenChecksToSavedChecks()
        {
            if (Settings.Default["SelectedReports"] is StringCollection stringCollection)
            {
                if (stringCollection != null && stringCollection.Count > 0)
                {
                    foreach (var item in _reports)
                    {
                        var name = item.name;
                        if (stringCollection.Contains(name) == true)
                        {
                            if (cbListReports.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                    {
                                        if (cbListReports.Items.IndexOf(name) >= 0)
                                        {
                                            cbListReports.SetItemChecked(cbListReports.Items.IndexOf(name), true);
                                        }
                                    }));
                            }
                            else
                            {
                                if (cbListReports.Items.IndexOf(name) >= 0)
                                {
                                    cbListReports.SetItemChecked(cbListReports.Items.IndexOf(name), true);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddCheckedReportAndSave(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if(Settings.Default["SelectedReports"] == null)
                {
                    Settings.Default["SelectedReports"] = new StringCollection();
                }
                if (Settings.Default["SelectedReports"] is StringCollection stringCollection)
                {
                    if (stringCollection.Contains(name) == false)
                    {
                        stringCollection.Add(name);
                        Settings.Default["SelectedReports"] = stringCollection;
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void RemovedUncheckedReportAndSave(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (Settings.Default["SelectedReports"] is StringCollection stringCollection)
                {
                    if (stringCollection.Contains(name) == true)
                    {
                        stringCollection.Remove(name);
                        Settings.Default["SelectedReports"] = stringCollection;
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void cbListReports_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var name = cbListReports?.Items[e.Index] as string;
            if (!string.IsNullOrEmpty(name))
            {
                var isChecked = (e.NewValue == CheckState.Checked);
                if (isChecked)
                {
                    AddCheckedReportAndSave(name);
                }
                else
                {
                    RemovedUncheckedReportAndSave(name);
                }
            }
        }

        private void cbHideUnused_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            var isChecked = cb?.CheckState == CheckState.Checked;
            cbListReports.Items.Clear();
            foreach (var item in _reportListCache)
            {
                if (isChecked)
                {
                    if (IsReportCheckedInSettings(item))
                    {
                        cbListReports.Items.Add(item);
                    }
                }
                else
                {
                    cbListReports.Items.Add(item);
                }
            }
            MatchScreenChecksToSavedChecks();
        }
    }
}