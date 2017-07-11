using System.Collections.Generic;
using System.IO;

namespace IDictionary
{
    class FileProcesser
    {
        public List<string> GetHistoryList()
        {
            List<string> his = new List<string>();
            if (File.Exists(Setting.hisPath))
            {
                string[] strs = File.ReadAllLines(Setting.hisPath);
                his = new List<string>(strs);
            }
           
            return his;
        }

        public void SaveToFile(List<string> his)
        {
            string[] strs = his.ToArray();
            File.WriteAllLines(Setting.hisPath, strs);
        }

        public void createFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
        }
        public void EmptyHistory()
        {
            File.WriteAllText(Setting.hisPath, string.Empty);
        }
    }
}
