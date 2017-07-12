using System;
using System.Drawing;

namespace IDictionary
{
    [Serializable]
    class Setting
    {
        public Font titleFont;
        public Font stitleFont;
        public Font sstitleFont;

        public Font accentFont;

        public Font transFont;

        public Font ctitleFont;
        public Font caccentFont;
        public Font ctransFont;

        public int maxSuggest;

        public Setting()
        {
            titleFont = new Font("Candara", 37, FontStyle.Bold);
            stitleFont = new Font("Candara", 30, FontStyle.Bold);
            sstitleFont = new Font("Candara", 24, FontStyle.Bold);

            accentFont = new Font("Baskerville Old Face", 13, FontStyle.Bold);

            transFont = new Font("微软雅黑", 10);

            ctitleFont = new Font("Candara", 37, FontStyle.Bold);
            caccentFont = new Font("Baskerville Old Face", 13, FontStyle.Bold);
            ctransFont = new Font("微软雅黑", 10);

            maxSuggest = 12;
        }
    }
}
