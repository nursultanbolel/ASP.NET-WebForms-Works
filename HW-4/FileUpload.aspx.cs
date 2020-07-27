using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HW4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        HttpPostedFile[] files = new HttpPostedFile[3];
        Thread thread_1;
        Thread thread_3;
        Thread thread_5;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            thread_1 = new Thread(new ThreadStart(t_file_upload_1));
            thread_3 = new Thread(new ThreadStart(t_file_upload_2));
            thread_5 = new Thread(new ThreadStart(t_file_upload_3));

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            files[0] = Request.Files["file1"];
            files[1] = Request.Files["file2"];
            files[2] = Request.Files["file3"];

            if(files[0].FileName == "" || files[1].FileName == "" || files[2].FileName == "")
            {
                Label_error.Text = "You must fill all file uploading areas.";
                return;
            }
            else
            {
                try
                {
                    thread_1.Start();
                    thread_3.Start();
                    thread_5.Start();
                    
                    bool control_thr1, control_thr2, control_thr3;
                    while (true)
                    {
                        control_thr1 = thread_1.IsAlive;
                        control_thr2 = thread_3.IsAlive;
                        control_thr3 = thread_5.IsAlive;
                        if (control_thr1 || control_thr2 || control_thr3)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "$(document).ready(function(){ProgressBars_finish(); }); ", true);
                            break;
                        }
                    }
                }
                catch
                {
                    Label_error.Text = "You must choose three files. ";
                    pb1.Visible = false;
                    pb2.Visible = false;
                    pb3.Visible = false;
                   
                    return;
                }
            }
            
        }

        public void t_file_upload_1()
        {
            WebClient wc = new WebClient();
            try
            {
                string fname = Path.GetFileName(files[0].FileName);
                files[0].SaveAs(Server.MapPath(Path.Combine("~/UploadedFiles/", fname)));
                
            }
            catch (Exception ex)
            {
                Label_error.Text = "Files were not uploaded successfully." + " Error Message: " + ex.Message;
                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = false;
               
            }
        }
        public void t_file_upload_2()
        {
            WebClient wc = new WebClient();
            try
            {
                string fname = Path.GetFileName(files[1].FileName);
                files[1].SaveAs(Server.MapPath(Path.Combine("~/UploadedFiles/", fname)));
               
            }
            catch (Exception ex)
            {
                Label_error.Text = "Files were not uploaded successfully." + " Error Message: " + ex.Message;
                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = false;
               
            }
        }

        public void t_file_upload_3()
        {
            WebClient wc = new WebClient();
            try
            {
                string fname = Path.GetFileName(files[2].FileName);
                files[2].SaveAs(Server.MapPath(Path.Combine("~/UploadedFiles/", fname)));
                
            }
            catch (Exception ex)
            {
                Label_error.Text = "Files were not uploaded successfully." + " Error Message: " + ex.Message;
                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = false;
              
            }
        }
        
    }
}