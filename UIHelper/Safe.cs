namespace UIHelper
{
    public static class Safe
    {
        public static string GetComboBoxText(Control ctrl, ComboBox cb)
        {
            string text = string.Empty;
            if (cb.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(() => text = cb.Text));
            }
            else
            {
                text = cb.Text;
            }
            return text;
        }

        public static void ComboBoxAdd(Control ctrl, ComboBox cb, string? value)
        {
            if (value != null)
            {
                if (cb.InvokeRequired)
                {
                    ctrl.Invoke(new MethodInvoker(() =>
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

        public static void ClearComboBox(Control ctrl, ComboBox cb)
        {
            if (cb.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(() =>
                {
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

        public static void SetLabel(Control ctrl, Label lbl, string progress)
        {
            try
            {
                if (lbl.InvokeRequired)
                {
                    ctrl.Invoke(new MethodInvoker(() => lbl.Text = progress));
                }
                else
                {
                    lbl.Text = progress;
                }
            }
            catch
            {
            }
        }

        public static string GetTextBoxText(Control ctrl, TextBox tb)
        {
            string text = string.Empty;
            if (tb.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(() => text = tb.Text));
            }
            else
            {
                text = tb.Text;
            }
            return text;
        }

        public static void SetButtonVisible(Control ctrl, Button btn, bool visible)
        {
            if (btn.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(() => btn.Visible = visible));
            }
            else
            {
                btn.Visible = visible;
            }
        }
    }
}
