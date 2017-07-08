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
                IcibaApi api = new IcibaApi();
                TranslationResult result = api.GetTransResult(query);

                label1.Text = result.key;   //单词英文
                if(result.psLen > 0)
                    label2.Text = "| " + result.ps[0] + " |";   // 音标
                // 释义
                transBox.Clear();
                for(int i=0;i<result.posLen;i++)
                {
                    transBox.AppendText(result.pos[i] + result.acceptation[i] );
                }
                //例句
                if(result.origLen > 0)
                    transBox.AppendText("--------------------------------------");
                for (int i = 0; i < result.origLen; i++)
                {
                    transBox.AppendText(result.sentOrig[i]);
                    transBox.AppendText(result.sentTrans[i]);
                }
            }
        }
    }
}
