using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace webFinal
{
    public class DatabaseHandler
    {
        private static OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\nur\source\repos\Final\Final\App_Data\main.mdb;Persist Security Info=True");
        private static DatabaseHandler dh;
        private DatabaseHandler() { }

        public void setNull()
        {
            dh = null;
        }

        public static DatabaseHandler getInitial()
        {
            if (dh == null)
            {
                dh = new DatabaseHandler();
                return dh;
            }
            else
            {
                return dh;
            }
        }

        public void addNew(News news)
        {
            OleDbCommand insert = new OleDbCommand("INSERT INTO News (Title,Description,Category,Author,NewLink,PubDate,ImageUrl)" +
                                                   "VALUES (@title,@description,@category,@author,@newLink,@pubDate,@imageUrl)", conn);
            try
            {
                conn.Open();
                insert.Parameters.AddWithValue("@title", news.Title);
                insert.Parameters.AddWithValue("@description", news.Description);
                insert.Parameters.AddWithValue("@category", news.Category);
                insert.Parameters.AddWithValue("@author", news.Author);
                insert.Parameters.AddWithValue("@newLink", news.NewLink);
                insert.Parameters.AddWithValue("@pubDate", news.PubDate);
                insert.Parameters.AddWithValue("@imageUrl", news.ImageUrl);
                insert.ExecuteNonQuery();
                Log.Logger.Information("Veri tabanina " + news.Title + " baslikli haber kaydedildi.");
            }
            catch(Exception err)
            {
                Log.Logger.Error("Veri tabanina haber kaydedilemedi.");
                Console.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public int getNewsCount(string title)
        {
            int result=0;
            OleDbCommand select = new OleDbCommand("Select COUNT(*) from News where Title = @title", conn);
            try
            {
                conn.Open();
                select.Parameters.AddWithValue("@title", title);
                result = (int)select.ExecuteScalar();
                Log.Logger.Information(title + " baslikli haber sayisi veri tabanindan dogru bir sekilde cekildi.");
            }
            catch
            {
                Log.Logger.Error(title + "basligina sahip haber sayisi hesaplanirken hata olustu.");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public ArrayList getLastNews()
        {
            ArrayList lastNews = new ArrayList();
            OleDbCommand select = new OleDbCommand("Select TOP 50 * from News ORDER BY PubDate DESC", conn);

            try
            {
                conn.Open();
                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    News temp = new News(int.Parse(reader["NewsID"].ToString()), reader["Title"].ToString(), reader["Description"].ToString(), reader["Category"].ToString(), reader["Author"].ToString(), reader["NewLink"].ToString(), DateTime.Parse(reader["PubDate"].ToString()), reader["ImageUrl"].ToString());
                    lastNews.Add(temp);
                }
                Log.Logger.Information("Veri tabaninda bulunan en son yayinlanan 30 haber basarili bir sekilde cekildi.");
            }
            catch
            {
                Log.Logger.Error("Veri tabaninda bulunan en son yayinlanan 30 haber cekilemedi.");
            }
            finally
            {
                conn.Close();
            }
            return lastNews;
        }

        public News getNewsByTitle(string title)
        {
            News temp = new News();
            OleDbCommand select = new OleDbCommand("Select * from News where Title = @title", conn);
            select.Parameters.AddWithValue("@title", title);
            try
            {
                conn.Open();
                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    temp = new News(int.Parse(reader["NewsID"].ToString()), reader["Title"].ToString(), reader["Description"].ToString(), reader["Category"].ToString(), reader["Author"].ToString(), reader["NewLink"].ToString(), DateTime.Parse(reader["PubDate"].ToString()), reader["ImageUrl"].ToString());
                }
                Log.Logger.Information(title +" baslikli haber veri tabanindan basarili bir sekilde cekildi.");
            }
            catch
            {
                Log.Logger.Error(title + " baslikli haber veri tabanindan cekilemedi.");
            }
            finally
            {
                conn.Close();
            }
            return temp;
        }

        public ArrayList getNewsByCategory(string category)
        {
            ArrayList categoryNews = new ArrayList();
            OleDbCommand select = new OleDbCommand("Select * from News where Category = @category", conn);
            
            try
            {
                conn.Open();
                select.Parameters.AddWithValue("@category", category);
                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    News temp = new News(int.Parse(reader["NewsID"].ToString()), reader["Title"].ToString(), reader["Description"].ToString(), reader["Category"].ToString(), reader["Author"].ToString(), reader["NewLink"].ToString(), DateTime.Parse(reader["PubDate"].ToString()), reader["ImageUrl"].ToString());
                    categoryNews.Add(temp);
                }
                Log.Logger.Information("Veri tabaninda bulunan kategorsi " + category +" olan herberler basarili bir sekilde cekildi.");
            }
            catch
            {
                Log.Logger.Information("Veri tabaninda bulunan kategorsi " + category + " olan herberler cekilemedi");
            }
            finally
            {
                conn.Close();
            }
            return categoryNews;
        }
    }
}