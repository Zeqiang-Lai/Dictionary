namespace IDictionary
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttomPanel = new System.Windows.Forms.Panel();
            this.searchPlusPanel = new System.Windows.Forms.Panel();
            this.shortInputBox = new System.Windows.Forms.TextBox();
            this.settingBtn = new System.Windows.Forms.PictureBox();
            this.menuBtn = new System.Windows.Forms.PictureBox();
            this.searchBoxPic = new System.Windows.Forms.PictureBox();
            this.deleteBtn = new System.Windows.Forms.PictureBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hisPanel = new System.Windows.Forms.Panel();
            this.hisListBox = new System.Windows.Forms.ListBox();
            this.wordPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transBox = new System.Windows.Forms.RichTextBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.buttomPanel.SuspendLayout();
            this.searchPlusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBoxPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.hisPanel.SuspendLayout();
            this.wordPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttomPanel
            // 
            this.buttomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttomPanel.Controls.Add(this.searchPlusPanel);
            this.buttomPanel.Controls.Add(this.deleteBtn);
            this.buttomPanel.Controls.Add(this.inputBox);
            this.buttomPanel.Controls.Add(this.pictureBox1);
            this.buttomPanel.Location = new System.Drawing.Point(0, 382);
            this.buttomPanel.Name = "buttomPanel";
            this.buttomPanel.Size = new System.Drawing.Size(287, 63);
            this.buttomPanel.TabIndex = 0;
            // 
            // searchPlusPanel
            // 
            this.searchPlusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchPlusPanel.Controls.Add(this.shortInputBox);
            this.searchPlusPanel.Controls.Add(this.settingBtn);
            this.searchPlusPanel.Controls.Add(this.menuBtn);
            this.searchPlusPanel.Controls.Add(this.searchBoxPic);
            this.searchPlusPanel.Location = new System.Drawing.Point(0, 3);
            this.searchPlusPanel.Name = "searchPlusPanel";
            this.searchPlusPanel.Size = new System.Drawing.Size(287, 63);
            this.searchPlusPanel.TabIndex = 1;
            // 
            // shortInputBox
            // 
            this.shortInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shortInputBox.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortInputBox.Location = new System.Drawing.Point(40, 20);
            this.shortInputBox.Name = "shortInputBox";
            this.shortInputBox.Size = new System.Drawing.Size(131, 23);
            this.shortInputBox.TabIndex = 3;
            this.shortInputBox.TextChanged += new System.EventHandler(this.shortInputBox_TextChanged);
            // 
            // settingBtn
            // 
            this.settingBtn.Image = global::IDictionary.Properties.Resources.settingIcon;
            this.settingBtn.Location = new System.Drawing.Point(239, 12);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(42, 39);
            this.settingBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingBtn.TabIndex = 2;
            this.settingBtn.TabStop = false;
            this.settingBtn.MouseEnter += new System.EventHandler(this.settingBtn_MouseEnter);
            this.settingBtn.MouseLeave += new System.EventHandler(this.settingBtn_MouseLeave);
            // 
            // menuBtn
            // 
            this.menuBtn.Image = global::IDictionary.Properties.Resources.menuIcon;
            this.menuBtn.Location = new System.Drawing.Point(195, 12);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(43, 39);
            this.menuBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuBtn.TabIndex = 1;
            this.menuBtn.TabStop = false;
            this.menuBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menuBtn_MouseClick);
            this.menuBtn.MouseEnter += new System.EventHandler(this.menuBtn_MouseEnter);
            this.menuBtn.MouseLeave += new System.EventHandler(this.menuBtn_MouseLeave);
            // 
            // searchBoxPic
            // 
            this.searchBoxPic.Image = global::IDictionary.Properties.Resources.searchBox;
            this.searchBoxPic.Location = new System.Drawing.Point(6, 12);
            this.searchBoxPic.Name = "searchBoxPic";
            this.searchBoxPic.Size = new System.Drawing.Size(186, 39);
            this.searchBoxPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchBoxPic.TabIndex = 0;
            this.searchBoxPic.TabStop = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.White;
            this.deleteBtn.Image = global::IDictionary.Properties.Resources.deleteButton;
            this.deleteBtn.Location = new System.Drawing.Point(252, 23);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(17, 23);
            this.deleteBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.TabStop = false;
            this.deleteBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteBtn_MouseClick);
            this.deleteBtn.MouseEnter += new System.EventHandler(this.deleteBtn_MouseEnter);
            this.deleteBtn.MouseLeave += new System.EventHandler(this.deleteBtn_MouseLeave);
            // 
            // inputBox
            // 
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputBox.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(40, 23);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(206, 23);
            this.inputBox.TabIndex = 2;
            this.inputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputBox_KeyPress_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::IDictionary.Properties.Resources.longsearchBox;
            this.pictureBox1.Location = new System.Drawing.Point(6, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // hisPanel
            // 
            this.hisPanel.Controls.Add(this.hisListBox);
            this.hisPanel.Location = new System.Drawing.Point(-1, -1);
            this.hisPanel.Name = "hisPanel";
            this.hisPanel.Size = new System.Drawing.Size(287, 386);
            this.hisPanel.TabIndex = 6;
            this.hisPanel.Visible = false;
            // 
            // hisListBox
            // 
            this.hisListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hisListBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hisListBox.FormattingEnabled = true;
            this.hisListBox.ItemHeight = 28;
            this.hisListBox.Location = new System.Drawing.Point(11, 10);
            this.hisListBox.Name = "hisListBox";
            this.hisListBox.Size = new System.Drawing.Size(270, 364);
            this.hisListBox.TabIndex = 0;
            this.hisListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hisListBox_MouseClick);
            this.hisListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hisListBox_MouseDoubleClick);
            // 
            // wordPanel
            // 
            this.wordPanel.Controls.Add(this.hisPanel);
            this.wordPanel.Controls.Add(this.label1);
            this.wordPanel.Controls.Add(this.label2);
            this.wordPanel.Controls.Add(this.transBox);
            this.wordPanel.Location = new System.Drawing.Point(0, 2);
            this.wordPanel.Name = "wordPanel";
            this.wordPanel.Size = new System.Drawing.Size(287, 386);
            this.wordPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dictionary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "| Hello |";
            // 
            // transBox
            // 
            this.transBox.BackColor = System.Drawing.Color.White;
            this.transBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.transBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.transBox.Location = new System.Drawing.Point(15, 116);
            this.transBox.Name = "transBox";
            this.transBox.ReadOnly = true;
            this.transBox.Size = new System.Drawing.Size(263, 267);
            this.transBox.TabIndex = 3;
            this.transBox.Text = ": )  欢迎使用词典\n: ]  本词典使用金山词霸API\n: |  请在下方文本框输入您要翻译的内容\n: |  按回车键进行翻译\n: (  暂仅支持英翻汉\n: " +
    "}  发现Bug可联系我";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.wordPanel);
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(287, 389);
            this.contentPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(287, 445);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttomPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictionary";
            this.buttomPanel.ResumeLayout(false);
            this.buttomPanel.PerformLayout();
            this.searchPlusPanel.ResumeLayout(false);
            this.searchPlusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBoxPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.hisPanel.ResumeLayout(false);
            this.wordPanel.ResumeLayout(false);
            this.wordPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttomPanel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel searchPlusPanel;
        private System.Windows.Forms.PictureBox searchBoxPic;
        private System.Windows.Forms.PictureBox menuBtn;
        private System.Windows.Forms.PictureBox settingBtn;
        private System.Windows.Forms.PictureBox deleteBtn;
        private System.Windows.Forms.TextBox shortInputBox;
        private System.Windows.Forms.Panel hisPanel;
        private System.Windows.Forms.ListBox hisListBox;
        private System.Windows.Forms.Panel wordPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox transBox;
        private System.Windows.Forms.Panel contentPanel;
    }
}

