using System;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;
using System.IO;

namespace IDictionary
{
    class IcibaApi
    {
        private string key = "49A20426BF8CAC1D6F1D2B98653B33EC";

        private string GetTransFromIciba(string query)
        {
            string url = string.Format("http://dict-co.iciba.com/api/dictionary.php?w={0}&key={1}",
                HttpUtility.UrlEncode(query, Encoding.UTF8), key);
            string xmlResult = string.Empty;

            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            try
            {
                xmlResult = wc.DownloadString(url);
            }catch(Exception e)
            {
                throw e;    
            }

            return xmlResult;
        }
        public TranslationResult GetTransResult(string query)
        {
            TranslationResult result = new TranslationResult();
            XmlDocument xdoc = new XmlDocument();
            string xmlStr = GetTransFromIciba(query);
            StringReader reader = new StringReader(xmlStr);
            xdoc.Load(reader);
            XmlNode root = xdoc.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "key") result.key = node.InnerText;
                else if (node.Name == "ps") result.ps[result.psLen++] = node.InnerText;
                else if (node.Name == "pos") result.pos[result.posLen++] = node.InnerText;
                else if (node.Name == "acceptation") result.acceptation[result.acceptationLen++] = node.InnerText;
                else if(node.Name == "sent")
                {
                    foreach(XmlNode cnode in node.ChildNodes)
                        if (cnode.Name == "orig") result.sentOrig[result.origLen++] = cnode.InnerText;
                        else if (cnode.Name == "trans") result.sentTrans[result.transLen++] = cnode.InnerText;
                }
            }

            return result;
        }
    }
}
