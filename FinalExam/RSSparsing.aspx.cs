using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace webFinal
{
    public partial class RSSparsing : System.Web.UI.Page
    {
        private DatabaseHandler dh = DatabaseHandler.getInitial();
        ArrayList allNews = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            parseXML("http://www.trt.net.tr/rss/gundem.rss", "Gündem");
            parseXML("http://www.trt.net.tr/rss/turkiye.rss", "Türkiye");
            parseXML("http://www.trt.net.tr/rss/dunya.rss", "Dünya");
            parseXML("http://www.trt.net.tr/rss/spor.rss", "Spor");
            parseXML("http://www.trt.net.tr/rss/ekonomi.rss", "Ekonomi");
            parseXML("http://www.trt.net.tr/rss/saglik.rss", "Sağlık");
            parseXML("http://www.trt.net.tr/rss/cevre.rss", "Çevre");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("C:\\Users\\nur\\source\\repos\\Final\\Final\\Log\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Session["todayNews"] = allNews;
            Response.Redirect("Home.aspx");
        }

        protected void parseXML(string url, string category)
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                rssXmlDoc.Load(url);
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
                foreach (XmlNode rssNode in rssNodes)
                {
                    XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                    string title = rssSubNode != null ? rssSubNode.InnerText : "";

                    rssSubNode = rssNode.SelectSingleNode("link");
                    string newLink = rssSubNode != null ? rssSubNode.InnerText : "";

                    rssSubNode = rssNode.SelectSingleNode("description");
                    string description = rssSubNode != null ? rssSubNode.InnerText : "";

                    string author = "TRT Yeni Medya Kanal Koordinatörlüğü";

                    DateTime pubDate = DateTime.Today;

                    rssSubNode = rssNode.SelectSingleNode("enclosure");

                    string imageUrl = "";
                    if (rssSubNode != null)
                    {
                        imageUrl = rssSubNode.Attributes["url"].Value;
                    }

                    News tempNews = new News(0, title, description, category, author, newLink, pubDate, imageUrl);

                    allNews.Add(tempNews);

                    if (dh.getNewsCount(title) < 1)
                    {
                        dh.addNew(tempNews);
                    }
                }
                Log.Logger.Information("RSS'ler basarili bir sekilde yuklendi.");
            }
            catch
            {
                Log.Logger.Error("RSS'ler yuklenemedi.");
            }
        }
    }
}