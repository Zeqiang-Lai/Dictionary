using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDictionary
{
    class TranslationResult
    {
        public string key;  //原文
        public string[] ps = new string[10];   //音标
        public string[] pos = new string[10];   //单词类型
        public string[] acceptation = new string[10];   //单词释义
        public string[] sentOrig = new string[20];  //例句原文
        public string[] sentTrans = new string[20]; //例句翻译

        public int psLen;
        public int posLen;
        public int acceptationLen;
        public int origLen;
        public int transLen;

        public TranslationResult()
        {
            key = null;
            psLen = 0;
            posLen = 0;
            acceptationLen = 0;
            origLen = 0;
            transLen = 0;
        }
    }
}
