using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using iKandi.Common;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using iKandi.BLL;


namespace iKandi.Web.Components
{
    public class FileHelper
    {
        public static string SaveFile(Stream image, string originalFileName, string folderPath, bool createThumbnail, string suggestedFileName)
        {
            if (string.IsNullOrEmpty(suggestedFileName))
                suggestedFileName = System.Guid.NewGuid().ToString();

            suggestedFileName = suggestedFileName.Trim().Replace(":", "-").Replace(";", "-").Replace("|", "-").Replace("<", "-").Replace(">", "-").Replace(@"""", "-").Replace(@"/", "-").Replace(@"\", "-").Replace("?", "-").Replace("*", "-");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string ext = originalFileName.Substring(originalFileName.LastIndexOf("."));

            if (createThumbnail && (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png"
                || ext.ToLower() == ".bmp" || ext.ToLower() == ".jpe" || ext.ToLower() == ".tiff"))
            {
                System.Drawing.Image thumb = ResizeImage(image, 150, 150);
                System.Drawing.Image reducedImage = ResizeImage(image, 1024, 1024);

                if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg")
                {
                    System.Drawing.Imaging.ImageCodecInfo[] Info = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
                    System.Drawing.Imaging.EncoderParameters Params = new System.Drawing.Imaging.EncoderParameters(1);
                    Params.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                    thumb.Save(Path.Combine(folderPath, "thumb-" + suggestedFileName + ext), Info[1], Params);
                    reducedImage.Save(Path.Combine(folderPath, suggestedFileName + ext), Info[1], Params);
                }
                else
                {

                    thumb.Save(Path.Combine(folderPath, "thumb-" + suggestedFileName + ext));
                    reducedImage.Save(Path.Combine(folderPath, suggestedFileName + ext));
                }

                try
                {
                    if (thumb != null)
                    {
                        thumb.Dispose();
                        thumb = null;
                    }

                    if (reducedImage != null)
                    {
                        reducedImage.Dispose();
                        reducedImage = null;
                    }

                    if (image != null)
                    {
                        image.Dispose();
                    }

                    GC.Collect();
                }
                catch (Exception ex)
                {
                    //NotificationController controller = new NotificationController();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                }

                return suggestedFileName + ext;
            }

            // Get size of uploaded file
            int contentLength = (int)image.Length;

            // Allocate a buffer for reading of the file
            byte[] buffer = new byte[contentLength];

            image.Read(buffer, 0, contentLength);

            WriteToFile(Path.Combine(folderPath, suggestedFileName + ext), ref buffer);

            return suggestedFileName + ext;
        }

        // Writes file to current folder

        private static void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }


        public static System.Drawing.Image CreateThumbNail(Stream OriginalImageStream, Int32 ThumbImageHeight, Int32 ThumbImageWidth)
        {
            System.Drawing.Image OrignalImage = null;
            System.Drawing.Image Thumb = null;
            Int32 OrignalImageHeight;
            Int32 OrignalImageWidth;
            IntPtr ptr = new IntPtr();

            try
            {
                OrignalImage = System.Drawing.Image.FromStream(OriginalImageStream, true);
                OrignalImageHeight = OrignalImage.Height;
                OrignalImageWidth = OrignalImage.Width;

                if (OrignalImageHeight > OrignalImageWidth)
                {
                    ThumbImageWidth = (int)(ThumbImageHeight * ((Double)OrignalImageWidth / OrignalImageHeight));
                }
                else if (OrignalImageWidth > OrignalImageHeight)
                {
                    ThumbImageHeight = (int)(ThumbImageWidth * ((Double)OrignalImageHeight / OrignalImageWidth));
                }

                Thumb = OrignalImage.GetThumbnailImage(ThumbImageWidth, ThumbImageHeight, null, ptr);

                return Thumb;
            }
            catch (Exception ex)
            {
                //NotificationController controller = new NotificationController();
                //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            finally
            {
            }

            return null;
        }

        public static System.Drawing.Image ResizeImage(Stream OriginalImageStream, Int32 ThumbImageHeight, Int32 ThumbImageWidth)
        {
            System.Drawing.Image OrignalImage = null;
            System.Drawing.Image Thumb = null;
            Int32 OrignalImageHeight;
            Int32 OrignalImageWidth;
          
            System.Drawing.Graphics graphic = null;

            try
            {

                OrignalImage = System.Drawing.Image.FromStream(OriginalImageStream, true);
                OrignalImageHeight = OrignalImage.Height;
                OrignalImageWidth = OrignalImage.Width;

                if (OrignalImageHeight > OrignalImageWidth)
                {
                    ThumbImageWidth = (int)(ThumbImageHeight * ((Double)OrignalImageWidth / OrignalImageHeight));
                }
                else if (OrignalImageWidth > OrignalImageHeight)
                {
                    ThumbImageHeight = (int)(ThumbImageWidth * ((Double)OrignalImageHeight / OrignalImageWidth));
                }

                Thumb = new Bitmap(ThumbImageWidth, ThumbImageHeight);

                graphic = System.Drawing.Graphics.FromImage(Thumb);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;

                //Thumb = OrignalImage.GetThumbnailImage(ThumbImageWidth, ThumbImageHeight, null, ptr);
                graphic.DrawImage(OrignalImage, 0, 0, ThumbImageWidth, ThumbImageHeight);

                return Thumb;
            }
            catch (Exception ex)
            {
                //NotificationController controller = new NotificationController();
                //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            finally
            {
                if (graphic != null)
                    graphic.Dispose();
            }

            return null;
        }

       
    }
}
