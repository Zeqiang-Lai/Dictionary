using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IDictionary
{
    class FileProcesser
    {
        private string hisPath = "history.txt";
        private string settingPath = "setting.dat";
        public List<string> GetHistoryList()
        {
            List<string> his = new List<string>();
            if (File.Exists(hisPath))
            {
                string[] strs = File.ReadAllLines(hisPath);
                his = new List<string>(strs);
            }

            return his;
        }

        public void SaveToFile(List<string> his)
        {
            string[] strs = his.ToArray();
            File.WriteAllLines(hisPath, strs);
        }

        public void createFile()
        {
            if (!File.Exists(hisPath))
                File.Create(hisPath).Close();

        } 

        public void EmptyHistory()
        {
            File.WriteAllText(hisPath, string.Empty);
        }

        public void SaveSettingToFile(Setting setting)
        {
            FileStream fs = new FileStream(settingPath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, setting);
            fs.Close();
        }

        public Setting GetSettingFromFile()
        {
            try
            {
                FileStream fs = new FileStream(settingPath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Setting setting = bf.Deserialize(fs) as Setting;
                fs.Close();
                return setting;
            }
            catch(Exception)
            {
                return new Setting();
            }
        }
    }
}
