using System.Windows.Forms;
using System;

namespace IDictionary
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void inputBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                string query = inputBox.Text;
                ShowTrans(query,true);
                inputBox.Text = string.Empty;
            }
        }

        private void ShowTrans(string query,Boolean isAdd)
        {
            hisPanel.Visible = false;

            if (query.Length == 0)
            {
                label1.Text = Properties.Resources.AppName;
                label2.Text = Properties.Resources.InitialAccent;
                transBox.Text = Properties.Resources.WelcomeDoc;
                shortInputBox.Text = string.Empty;
                searchPlusPanel.Visible = true;
                shortInputBox.Focus();
            }
            else
            {
                IcibaApi api = new IcibaApi();
                TranslationResult result = api.GetTransResult(query);

                if(isAdd) hisListBox.Items.Add(query);

                label1.Text = result.key;   //单词英文
                if (result.psLen > 0)
                    label2.Text = "| " + result.ps[0] + " |";   // 音标
                                                                // 释义
                transBox.Clear();
                for (int i = 0; i < result.posLen; i++)
                {
                    transBox.AppendText(result.pos[i] + result.acceptation[i]);
                }
                //例句
                if (result.origLen > 0)
                    transBox.AppendText(Properties.Resources.SeparatedLine);
                for (int i = 0; i < result.origLen; i++)
                {
                    transBox.AppendText(result.sentOrig[i]);
                    transBox.AppendText(result.sentTrans[i]);
                }
            }
        }

        private void hisListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = hisListBox.IndexFromPoint(e.Location);
            if(index != -1)
            {
                string query = hisListBox.SelectedItem.ToString();
                ShowTrans(query,false);
                hisPanel.Visible = false;
            }
            
        }

        private void hisListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (hisListBox.IndexFromPoint(e.Location) == -1) hisListBox.ClearSelected();
        }

        private void deleteBtn_MouseClick(object sender, MouseEventArgs e)
        {
            inputBox.Text = string.Empty;
            shortInputBox.Text = string.Empty;
            searchPlusPanel.Visible = true;
            if(hisListBox.Items.Count > 0)
                hisPanel.Visible = true;
        }

        private void deleteBtn_MouseEnter(object sender, EventArgs e)
        {
            deleteBtn.Image = Properties.Resources.deleteButtonClicked;
        }

        private void deleteBtn_MouseLeave(object sender, EventArgs e)
        {
            deleteBtn.Image = Properties.Resources.deleteButton;
        }

        private void menuBtn_MouseEnter(object sender, EventArgs e)
        {
            menuBtn.Image = Properties.Resources.menuIconClicked;
        }

        private void menuBtn_MouseLeave(object sender, EventArgs e)
        {
            menuBtn.Image = Properties.Resources.menuIcon;
        }

        private void settingBtn_MouseEnter(object sender, EventArgs e)
        {
            settingBtn.Image = Properties.Resources.settingIconClicked;
        }

        private void settingBtn_MouseLeave(object sender, EventArgs e)
        {
            settingBtn.Image = Properties.Resources.settingIcon;
        }

        private void shortInputBox_TextChanged(object sender, EventArgs e)
        {
            inputBox.Text = shortInputBox.Text;
            inputBox.Focus();
            inputBox.SelectionStart = inputBox.TextLength;
            searchPlusPanel.Visible = false;      
        }

        private void menuBtn_MouseClick(object sender, MouseEventArgs e)
        {
            hisPanel.Visible = !hisPanel.Visible;
        }
    }
}