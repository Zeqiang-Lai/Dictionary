using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace IDictionary
{
    public partial class Form1 : Form
    {
        string dic = string.Empty;
        int maxSuggest = 12;
        private string hisPath = "history.txt";
    
        List<string> history = new List<string>();
        IcibaApi api = new IcibaApi();
        FileProcesser fileIO = new FileProcesser();
        Setting Setting;

        public Form1()
        {
            InitializeComponent();
            dic = Properties.Resources.words;
            //dic = File.ReadAllText("C:/Users/91632/Desktop/words.txt")
            LoadSetting();
        }

        private void LoadSetting()
        {
            Setting = fileIO.GetSettingFromFile();
            LoadFont();
            LoadHistory();
            LoadSearchSetting();
        }

        private void LoadSearchSetting()
        {
            this.maxSuggest = Setting.maxSuggest;
        }

        private void LoadFont()
        {
            this.titileLbl.Font = Setting.titleFont;
            this.accentLbl.Font = Setting.accentFont;
            this.transBox.Font = Setting.transFont;

            this.titleFontEditLbl.Font = Setting.titleFont;
            this.accentFontEditLbl.Font = Setting.accentFont;
            this.transFontEditlbl.Font = Setting.transFont;
        }

        private void LoadHistory()
        {
            try
            {
                history = fileIO.GetHistoryList();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.fileError);
                throw;
            }
        }

        private void ShowTrans(string query)
        {
            string addedQuery = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(query);
            query = query.ToLower();
            inputBox.Text = string.Empty;
            shortInputBox.Text = string.Empty;

            hisPanel.Visible = false;
            settingPanel.Visible = false;
            searchPlusPanel.Visible = true;

            if (query.Length == 0)
            {
                titileLbl.Text = Properties.Resources.AppName;
                accentLbl.Text = Properties.Resources.InitialAccent;
                transBox.Text = Properties.Resources.WelcomeDoc;
                searchPlusPanel.Visible = true;
                shortInputBox.Focus();
            }
            else
            {
                TranslationResult result = api.GetTransResult(query);

                if (!history.Contains(addedQuery)) history.Add(addedQuery);

                if (result.key.Length < 10)
                    titileLbl.Font = Setting.titleFont;
                else if (result.key.Length < 15)
                    titileLbl.Font = Setting.stitleFont;
                else
                    titileLbl.Font = Setting.sstitleFont;
                titileLbl.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(result.key);   //单词英文

                if (result.psLen > 0)
                    accentLbl.Text = "| " + result.ps[0] + " |";   // 音标
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
        // find matching words
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            hisListBox.Items.Clear();
            string prefix = inputBox.Text;
            if (prefix.Length > 0)
            {
                string pattern = "^[^a-zA-z]*" + prefix + "[a-zA-Z]*";
                Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Match m = r.Match(dic);
                int matchCount = 0;

                while (m.Success && matchCount < maxSuggest)
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
        //
        //

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

        //
        // change button image
        //
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
        //
        //

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
            searchSetpanel.Visible = false;
            fontSetpanel.Visible = false;
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



        // save history
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                fileIO.SaveToFile(history);
                fileIO.SaveSettingToFile(Setting);
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.fileError);
                throw;
            }
        }

        // create history.txt
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                fileIO.createFile();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.fileError);
            }
        }


        //
        // setting panel
        //
        private void emptyHisBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("确认删除？", "Confirm Message", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    fileIO.EmptyHistory();
                    history = fileIO.GetHistoryList();
                }
                catch (Exception)
                {
                    MessageBox.Show(Properties.Resources.fileError);
                    throw;
                }
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
                    File.Copy(hisPath, saveFileDialog1.FileName);
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
            fontSetpanel.Visible = !fontSetpanel.Visible;
            searchSetpanel.Visible = false;
        }

        private void suggestSetBtn_MouseClick(object sender, MouseEventArgs e)
        {
            searchSetpanel.Visible = !searchSetpanel.Visible;
            fontSetpanel.Visible = false;
        }
      


        //
        // font edit 
        //
        private void SelectedFont(Label lbl)
        {
            fontDialog1.Font = lbl.Font;
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbl.Font = fontDialog1.Font;
            }
        }

        private void titleFontEditLbl_MouseClick(object sender, MouseEventArgs e)
        {
            titleFontEditLbl.ForeColor = Color.Black;
            SelectedFont(titleFontEditLbl);
        }

        private void accentFontEditLbl_MouseClick(object sender, MouseEventArgs e)
        {
            accentFontEditLbl.ForeColor = Color.Black;
            SelectedFont(accentFontEditLbl);
        }

        private void transFontEditlbl_Click(object sender, EventArgs e)
        {
            transFontEditlbl.ForeColor = Color.Black;
            SelectedFont(transFontEditlbl);
        }

        private void titleFontEditLbl_MouseEnter(object sender, EventArgs e)
        {
            titleFontEditLbl.ForeColor = Color.MidnightBlue;
        }

        private void titleFontEditLbl_MouseLeave(object sender, EventArgs e)
        {
            titleFontEditLbl.ForeColor = Color.Black;
        }

        private void accentFontEditLbl_MouseEnter(object sender, EventArgs e)
        {
            accentFontEditLbl.ForeColor = Color.MidnightBlue;
        }

        private void accentFontEditLbl_MouseLeave(object sender, EventArgs e)
        {
            accentFontEditLbl.ForeColor = Color.Black;
        }

        private void transFontEditlbl_MouseEnter(object sender, EventArgs e)
        {
            transFontEditlbl.ForeColor = Color.MidnightBlue;
        }

        private void transFontEditlbl_MouseLeave(object sender, EventArgs e)
        {
            transFontEditlbl.ForeColor = Color.Black;
        }

        private void confirmEditBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Setting.titleFont = titleFontEditLbl.Font;
                Setting.accentFont = accentFontEditLbl.Font;
                Setting.transFont = transFontEditlbl.Font;
                this.LoadFont();
                this.Validate();
                MessageBox.Show("字体修改成功");
            }
            catch (Exception)
            {
                MessageBox.Show("字体修改失败");
            }
        }

        private void resetFontBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Setting.titleFont = Setting.ctitleFont;
                Setting.accentFont = Setting.caccentFont;
                Setting.transFont = Setting.ctransFont;
                this.LoadFont();
                this.Validate();
                MessageBox.Show("字体已恢复为默认配置");
            }
            catch (Exception)
            {
                MessageBox.Show("字体恢复失败");
            }
        }
        

        // maxSuggest
        private void numConfirmBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Setting.maxSuggest = (int)sugNumericUpDown.Value;
                this.LoadSearchSetting();
                MessageBox.Show("修改成功");
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败");
            }
        }
       
    }
}