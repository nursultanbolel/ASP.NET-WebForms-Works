using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4
{
    public partial class FileDownload : System.Web.UI.Page
    {
        TextBox[] txt_box_link = new TextBox[3];
        string[] download_file_name = new string[3];
        string[] localFile = new string[3];
        bool[] downloaded_files = new bool[3];
        Thread thread_1;
        Thread thread_3;
        Thread thread_5;
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_box_link[0] = TextBox_link1;
            txt_box_link[0] = TextBox_link2;
            txt_box_link[0] = TextBox_link3;

            thread_1 = new Thread(new ThreadStart(t_file_download_1));
            thread_3 = new Thread(new ThreadStart(t_file_download_2));
            thread_5 = new Thread(new ThreadStart(t_file_download_3));
          
        }
        protected void btnDownloadClick(object sender, EventArgs e)
        {

            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            String[] extensions = { "mp3", "png", "jpg", "gif", "pdf", "docx", "doc", "xls", "xlsx", "ppt", "pptx" };
            pd1.Visible = true;
            pd2.Visible = true;
            pd3.Visible = true;
            downloaded_files[0] = false;
            downloaded_files[1] = false;
            downloaded_files[2] = false;

            try
            {

                string[] strArr1 = TextBox_link1.Text.Split('/');
                download_file_name[0] = strArr1[strArr1.Length - 1];
                string[] donwload_file_ext1 = download_file_name[0].Split('.');

                for (int j = 0; j < extensions.Length; j++)
                {
                    if (donwload_file_ext1[donwload_file_ext1.Length - 1] == extensions[j])
                    {
                        flag1 = true;
                    }
                }
                string[] strArr2 = TextBox_link2.Text.Split('/');
                download_file_name[1] = strArr2[strArr2.Length - 1];
                string[] donwload_file_ext2 = download_file_name[1].Split('.');

                for (int j = 0; j < extensions.Length; j++)
                {
                    if (donwload_file_ext2[donwload_file_ext2.Length - 1] == extensions[j])
                    {
                        flag2 = true;
                    }
                }

                string[] strArr3 = TextBox_link3.Text.Split('/');
                download_file_name[2] = strArr3[strArr3.Length - 1];
                string[] donwload_file_ext3 = download_file_name[2].Split('.');

                for (int j = 0; j < extensions.Length; j++)
                {
                    if (donwload_file_ext3[donwload_file_ext3.Length - 1] == extensions[j])
                    {
                        flag3 = true;
                    }
                }


                if (flag1 && flag2 && flag3)
                {

                    try
                    {
                        localFile[0] = Path.Combine(HttpContext.Current.Server.MapPath("DownloadedFiles"), download_file_name[0]);
                        localFile[1] = Path.Combine(HttpContext.Current.Server.MapPath("DownloadedFiles"), download_file_name[1]);
                        localFile[2] = Path.Combine(HttpContext.Current.Server.MapPath("DownloadedFiles"), download_file_name[2]);

                        
                        thread_1.Start();
                        thread_3.Start();
                        thread_5.Start();
                       
                        while(true)
                        {
                           if(downloaded_files[0] && downloaded_files[1] && downloaded_files[2])
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "$(document).ready(function(){ProgressBars_finish(); }); ", true);
                                break;
                            }
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Label_error.Text = "Files were not downloaded successfully." + " Error Message : " + ex.Message;
                        pd1.Visible = false;
                        pd2.Visible = false;
                        pd3.Visible = false;
                        return;
                    }
                }
                else
                {
                    Label_error.Text = "Enter three file links for downloading. Type of files must be mp3, png, jpg, gif, pdf, docx, doc, xls, xlsx, ppt or pptx .";
                    pd1.Visible = false;
                    pd2.Visible = false;
                    pd3.Visible = false;
                    return;
                }

            }
            catch
            {
                Label_error.Text = "Files were not downloaded successfully.";
                pd1.Visible = false;
                pd2.Visible = false;
                pd3.Visible = false;
                return;
            }
        }

        public void t_file_download_1()
        {
            WebClient wc = new WebClient();
            try
            {
                Uri uri = new Uri(TextBox_link1.Text);
               
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged1);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted1);
                wc.DownloadFileAsync(uri, localFile[0]);
                
            }
            catch(Exception ex)
            {
                Label_error.Text = "Files were not downloaded successfully.." + " Error Message: " + ex.Message;
                pd1.Visible = false;
                pd2.Visible = false;
                pd3.Visible = false;
            }
        }

        public void DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            Debug.WriteLine("Proggres1-" + e.ProgressPercentage);
        }
        public void DownloadFileCompleted1(object sender, AsyncCompletedEventArgs e)
        {
            downloaded_files[0] = true;
        }
        public void t_file_download_2()
        {
            WebClient wc = new WebClient();
            try
            {
                Uri uri = new Uri(TextBox_link2.Text);

                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged2);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted2);
                wc.DownloadFileAsync(uri, localFile[1]);

            }
            catch (Exception ex)
            {
                Label_error.Text = "Files were not downloaded successfully.." + " Error Message: " + ex.Message;
                pd1.Visible = false;
                pd2.Visible = false;
                pd3.Visible = false;
            }

        }
        public void DownloadProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            Debug.WriteLine("Proggres2-" + e.ProgressPercentage);
        }
        public void DownloadFileCompleted2(object sender, AsyncCompletedEventArgs e)
        {
            downloaded_files[1] = true;
        }
        public void t_file_download_3()
        {
            WebClient wc = new WebClient();
            try
            {
                Uri uri = new Uri(TextBox_link3.Text);

                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged3);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted3);
                wc.DownloadFileAsync(uri, localFile[2]);

            }
            catch (Exception ex)
            {
                Label_error.Text = "Files were not downloaded successfully.." + " Error Message: " + ex.Message;
                pd1.Visible = false;
                pd2.Visible = false;
                pd3.Visible = false;
            }

        }
        public void DownloadProgressChanged3(object sender, DownloadProgressChangedEventArgs e)
        {
            Debug.WriteLine("Proggres3-" + e.ProgressPercentage);
        }
        public void DownloadFileCompleted3(object sender, AsyncCompletedEventArgs e)
        {
            downloaded_files[2] = true;
        }
    }
}
