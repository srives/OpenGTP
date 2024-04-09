using OpenGTP.Properties;
using System.Collections.Specialized;
using UIHelper;


namespace OpenGTP
{
    public partial class CheckBoxListToggle : UserControl
    {
        private List<NamedId> _theList = [];
        private List<string> _listCache = [];
        private string _settingsKey = string.Empty;

        public CheckBoxListToggle()
        {
            InitializeComponent();
        }

        public void Init(List<NamedId> baseList, string listDescription, string settingsKey)
        {
            _settingsKey = settingsKey;
            Safe.SetLabel(this, lblWhat, listDescription);
            _theList = new List<NamedId>(baseList);
            for (int i = 0; i < _theList.Count; i++)
            {
                var rep = _theList[i];
                var name = rep.name;
                cbList.Items.Add(name);
                _listCache.Add(name);
            }
            MatchScreenChecksToSavedChecks();
        }

        private void btnToggleSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                var item = cbList.Items[i];
                cbList.SetItemChecked(cbList.Items.IndexOf(item), !cbList.GetItemChecked(cbList.Items.IndexOf(item)));
            }
        }

        private void btnToggleAllOn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                var item = cbList.Items[i];
                cbList.SetItemChecked(cbList.Items.IndexOf(item), true);
            }
        }

        private void btnToggleAllOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                var item = cbList.Items[i];
                cbList.SetItemChecked(cbList.Items.IndexOf(item), false);
            }
        }

        private bool IsReportCheckedInSettings(string name)
        {
            if (Settings.Default[_settingsKey] is StringCollection stringCollection)
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
            if (Settings.Default[_settingsKey] is StringCollection stringCollection)
            {
                if (stringCollection != null && stringCollection.Count > 0)
                {
                    foreach (var item in _theList)
                    {
                        var name = item.name;
                        if (stringCollection.Contains(name) == true)
                        {
                            if (cbList.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    if (cbList.Items.IndexOf(name) >= 0)
                                    {
                                        cbList.SetItemChecked(cbList.Items.IndexOf(name), true);
                                    }
                                }));
                            }
                            else
                            {
                                if (cbList.Items.IndexOf(name) >= 0)
                                {
                                    cbList.SetItemChecked(cbList.Items.IndexOf(name), true);
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
                if (Settings.Default[_settingsKey] == null)
                {
                    Settings.Default[_settingsKey] = new StringCollection();
                }
                if (Settings.Default[_settingsKey] is StringCollection stringCollection)
                {
                    if (stringCollection.Contains(name) == false)
                    {
                        stringCollection.Add(name);
                        Settings.Default[_settingsKey] = stringCollection;
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void RemovedUncheckedListItemAndSave(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (Settings.Default[_settingsKey] is StringCollection stringCollection)
                {
                    if (stringCollection.Contains(name) == true)
                    {
                        stringCollection.Remove(name);
                        Settings.Default[_settingsKey] = stringCollection;
                        Settings.Default.Save();
                    }
                }
            }
        }

        private void cbList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var name = cbList?.Items[e.Index] as string;
            if (!string.IsNullOrEmpty(name))
            {
                var isChecked = (e.NewValue == CheckState.Checked);
                if (isChecked)
                {
                    AddCheckedReportAndSave(name);
                }
                else
                {
                    RemovedUncheckedListItemAndSave(name);
                }
            }
        }

        private void cbHideUnused_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            var isChecked = cb?.CheckState == CheckState.Checked;
            cbList.Items.Clear();
            foreach (var item in _listCache)
            {
                if (isChecked)
                {
                    if (IsReportCheckedInSettings(item))
                    {
                        cbList.Items.Add(item);
                    }
                }
                else
                {
                    cbList.Items.Add(item);
                }
            }
            MatchScreenChecksToSavedChecks();
        }
    }
}
