using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace IDictionary
{
    public partial class Form1 : Form
    {
        string dic = string.Empty;
        List<string> history = new List<string>();
        IcibaApi api = new IcibaApi();
        FileProcesser fileIO = new FileProcesser();

        public Form1()
        {
            InitializeComponent();
            dic = Properties.Resources.words;
            history = fileIO.GetHistoryList();
        }

        private void inputBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                string query = inputBox.Text;           
                ShowTrans(query);
                shortInputBox.Focus();
            }
        }

        private void ShowTrans(string query)
        {
            query = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(query);
            inputBox.Text = string.Empty;
            shortInputBox.Text = string.Empty;

            hisPanel.Visible = false;
            searchPlusPanel.Visible = true;

            if (query.Length == 0)
            {
                label1.Text = Properties.Resources.AppName;
                label2.Text = Properties.Resources.InitialAccent;
                transBox.Text = Properties.Resources.WelcomeDoc;
                searchPlusPanel.Visible = true;
                shortInputBox.Focus();
            }
            else
            {
                TranslationResult result = api.GetTransResult(query);

                if (!history.Contains(query)) history.Add(query);

                if (result.key.Length < 10)
                    label1.Font = Setting.titleFont;
                else if (result.key.Length < 15)
                    label1.Font = Setting.stitleFont;
                else
                    label1.Font = Setting.sstitleFont;
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
                ShowTrans(query);
                shortInputBox.Focus();
                hisPanel.Visible = false;
            }
            
        }

        // change button image
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

        // short inputbox -> long inputbox
        private void shortInputBox_TextChanged(object sender, EventArgs e)
        {
            inputBox.Text = shortInputBox.Text;
            inputBox.Focus();
            inputBox.SelectionStart = inputBox.TextLength;
            searchPlusPanel.Visible = false;      
        }

        // menu button click event
        private void menuBtn_MouseClick(object sender, MouseEventArgs e)
        {
            ListBoxAddItems(history);
            settingPanel.Visible = false;
            hisPanel.Visible = !hisPanel.Visible;   
        }

        // setting button click event
        private void settingBtn_MouseClick(object sender, MouseEventArgs e)
        {
            settingPanel.Visible = !settingPanel.Visible;
            hisPanel.Visible = false;
        }

        private void ListBoxAddItems(List<string> targetList)
        {
            hisListBox.Items.Clear();
            foreach (string item in targetList)
                hisListBox.Items.Add(item);
        }

        // delete button click event
        private void deleteBtn_MouseClick(object sender, MouseEventArgs e)
        {
            inputBox.Text = string.Empty;
            shortInputBox.Text = string.Empty;
            searchPlusPanel.Visible = true;
            shortInputBox.Focus();
            if (history.Count > 0)
            {
                ListBoxAddItems(history);
                hisPanel.Visible = true;
            }
                
        }

        // history list button click event
        private void hisListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (hisListBox.IndexFromPoint(e.Location) == -1) hisListBox.ClearSelected();
        }

        // find matching words
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            hisListBox.Items.Clear();
            string prefix = inputBox.Text;
            if(prefix.Length >0)
            {
                string pattern = "^"+prefix + "[a-zA-Z]*";
                Regex r = new Regex(pattern, RegexOptions.IgnoreCase|RegexOptions.Multiline);
                Match m = r.Match(dic);
                int matchCount = 0;

                while (m.Success && matchCount < 10)
                {
                    hisListBox.Items.Add(m.Value);
                    m = m.NextMatch();
                    matchCount++;
                }
                if (hisPanel.Visible == false) hisPanel.Visible = true;
            }
            else
            {
                hisPanel.Visible = false;
            }
        }

        // save history
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileIO.SaveToFile(history);
        }

        // create history.txt
        private void Form1_Load(object sender, EventArgs e)
        {
            fileIO.createFile(Setting.hisPath);
        }

        // empty histroy button click event
        private void emptyHisBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("确认删除？", "Confirm Message", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                fileIO.EmptyHistory();
                history = fileIO.GetHistoryList();
                MessageBox.Show(Properties.Resources.emptyHis);
            }
            
        }

        private void getUpdateBtn_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.updateLink);
        }

        private void exportHisBtn_MouseClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt |*.txt";
            saveFileDialog1.Title = "Export History";
            saveFileDialog1.FileName = "IDictionary_History";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFileDialog1.ShowDialog();

            if(saveFileDialog1.FileName != "")
            {
                try
                {
                    fileIO.SaveToFile(history);
                    File.Copy(Setting.hisPath, saveFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("保存失败");
                }
            }
        }

        private void emailFBBtn_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Properties.Resources.feedBackIntro);
        }

        private void aboutBtn_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Properties.Resources.about);
        }

        private void fontSetBtn_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Properties.Resources.fontSetStr);
        }
    }
}