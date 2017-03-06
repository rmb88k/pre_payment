using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
namespace LXS.Common
{
/// <summary>
/// UploadIMG 的摘要说明
/// </summary>
public class UploadIMG
{
public UploadIMG()
{
//
// TODO: 在此处添加构造函数逻辑
//
}
    private string _MSG;
    private string _ofullname;
    private string _tfullname;
    private string _ofilename;
    private string _tfilename;

    private int _limitwidth = 2048;
    private int _limitheight = 1536;

    private int _twidth = 100;
    private int _theight = 100;

    private int _size = 1000000;
    private bool _israte = true;

    private string _path = "UpdateFile";

    /// <summary>
    /// 信息
    /// </summary>
    public string MSG
    {
        get { return _MSG; }
        set { _MSG = value; }
    }

    /// <summary>
    /// 保存时的完整路径.原图
    /// </summary>
    public string OFullName
    {
        get { return _ofullname; }
        set { _ofullname = value; }
    }

    /// <summary>
    /// 保存时的完整路径.缩略图
    /// </summary>
    public string TFullName
    {
        get { return _tfullname; }
        set { _tfullname = value; }
    }

    /// <summary>
    /// 保存时的图片名称.原图
    /// </summary>
    public string OFileName
    {
        get { return _ofilename; }
        set { _ofilename = value; }
    }

    /// <summary>
    /// 保存时的图片名称.缩略图
    /// </summary>
    public string TFileName
    {
        get { return _tfilename; }
        set { _tfilename = value; }
    }

    /// <summary>
    /// 限定宽度
    /// </summary>
    public int LimitWidth
    {
        get { return _limitwidth; }
        set { _limitwidth = value; }
    }

    /// <summary>
    /// 限定高度
    /// </summary>
    public int LimitHeight
    {
        get { return _limitheight; }
        set { _limitheight = value; }
    }

    /// <summary>
    /// 缩略图宽度
    /// </summary>
    public int TWidth
    {
        get { return _twidth; }
        set { _twidth = value; }
    }

    /// <summary>
    /// 缩略图高度
    /// </summary>
    public int THeight
    {
        get { return _theight; }
        set { _theight = value; }
    }

    /// <summary>
    /// 文件大小
    /// </summary>
    public int Size
    {
        get { return _size; }
        set { _size = value; }
    }

    /// <summary>
    /// 是否成比例
    /// </summary>
    public bool IsRate
    {
        get { return _israte; }
        set { _israte = value; }
    }

    /// <summary>
    /// 存放图片的文件夹名称
    /// </summary>
    public string Path
    {
        get { return _path; }
        set { _path = value; }
    }

/// <summary>
    /// 图片上传(默认:"等比压缩,限定上传尺寸2048*1536,缩略图尺寸100*100,限定上传大小1MB,存放在根目录UpdateFile中")
    /// </summary>
    /// <param name="UploadFile">文件上传控件</param>
    /// <returns>返回是否成功保存图片</returns>
    public bool UpLoadIMG(FileUpload UploadFile)
    {
        if (UploadFile.HasFile)//检查是否已经选择文件
        {
            
            string filename = UploadFile.FileName.ToLower();
            int i = filename.LastIndexOf(".");
            filename = filename.Substring(i, filename.Length - i).ToLower();

            if (!(filename == ".jpg" || filename == ".jpeg" || filename == ".gif" || filename == ".png" || filename == ".bmp"))
            {
                MSG = "不受支持的类型,请重新选择!";
                return false;
            }//检查上传文件的格式是否有效

            if (UploadFile.PostedFile.ContentLength == 0 || UploadFile.PostedFile.ContentLength >= Size)
            {
                MSG = "指定的文件大小不符合要求!";
                return false;
            }//检查图片文件的大小

            //生成原图
            Stream oStream = UploadFile.PostedFile.InputStream;
            System.Drawing.Image oImage = System.Drawing.Image.FromStream(oStream);

            int owidth = oImage.Width; //原图宽度
            int oheight = oImage.Height; //原图高度

            if (owidth > LimitWidth || oheight > LimitHeight)
            {
                MSG = "超过允许的图片尺寸范围!";
                return false;
            }//检查是否超出规定尺寸

            if (IsRate)
            {
                //按比例计算出缩略图的宽度和高度
                if (owidth >= oheight)
                {
                    THeight = (int)Math.Floor(Convert.ToDouble(oheight) * (Convert.ToDouble(TWidth) / Convert.ToDouble(owidth)));//等比设定高度
                }
                else
                {
                    TWidth = (int)Math.Floor(Convert.ToDouble(owidth) * (Convert.ToDouble(THeight) / Convert.ToDouble(oheight)));//等比设定宽度
                }
            }

            //生成缩略原图
            Bitmap tImage = new Bitmap(TWidth, THeight);
            Graphics g = Graphics.FromImage(tImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度
            g.Clear(Color.Transparent); //清空画布并以透明背景色填充
            g.DrawImage(oImage, new Rectangle(0, 0, TWidth, THeight), new Rectangle(0, 0, owidth, oheight), GraphicsUnit.Pixel);


            Random oRandom = new Random();
            string oStringRandom = oRandom.Next(9999).ToString();//生成4位随机数字

            //格式化日期作为文件名
            DateTime oDateTime = new DateTime();
            oDateTime = DateTime.Now;
            string oStringTime = oDateTime.ToString();
            oStringTime = oStringTime.Replace("-", "");
            oStringTime = oStringTime.Replace(" ", "");
            oStringTime = oStringTime.Replace(":", "");
            oStringTime = oStringTime.Replace("/", "");

            OFileName = "o" + oStringTime + oStringRandom + filename;
            TFileName = "t" + oStringTime + oStringRandom + filename;

            string oSavePath = HttpContext.Current.Server.MapPath("~"+@"\"+Path) + @"\";
            if (!Directory.Exists(oSavePath))
            {
                Directory.CreateDirectory(oSavePath);//在根目录下建立文件夹
            }

            //保存路径+完整文件名
            OFullName = oSavePath + OFileName;
            TFullName = oSavePath + TFileName;

            //开始保存图片至服务器
            try
            {
                switch (filename)
                {
                    case ".jpeg":
                    case ".jpg":
                        {
                            oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        }

                    case ".gif":
                        {
                            oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Gif);
                            tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        }

                    case ".png":
                        {
                            oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Png);
                            tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        }

                    case ".bmp":
                        {
                            oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Bmp);
                            tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        }
                }
                MSG = "图片上传成功!";
                return true;
            }
            catch (Exception ex)
            {
                MSG = ex.Message;
                return false;
            }
            finally
            {
                //释放资源
                oImage.Dispose();
                g.Dispose();
                tImage.Dispose();
            }
        }
        else
        {
            MSG = "请先选择需要上传的图片!";
            return false;
        }
    }
}

    public class UploadFile
    {
        private System.Web.HttpPostedFile postedFile = null;
        private string savePath = "";
        private string extension = "";
        private string saveName = "";
        private int fileLength = 0;
        //显示该组件使用的参数信息
        public string Help
        {
            get
            {
                string helpstring;
                helpstring = "<font size=3>MyUpload myUpload=new MyUpload(); //构造函数";
                helpstring += "myUpload.PostedFile=file1.PostedFile;//设置要上传的文件";
                helpstring += "myUpload.SavePath=\"e:\\\";//设置要上传到服务器的路径，默认c:\\";
                helpstring += "myUpload.FileLength=100; //设置上传文件的最大长度，单位k，默认1k";
                helpstring += "myUpload.Extension=\"doc\";设置上传文件的扩展名，默认txt";
                helpstring += "label1.Text=myUpload.Upload();//开始上传，并显示上传结果</font>";
                helpstring += "<font size=3 color=red>Design By WengMingJun 2001-12-12 All Right Reserved!</font>";
                return helpstring;
            }
        }

        public System.Web.HttpPostedFile PostedFile
        {
            get
            {
                return postedFile;
            }
            set
            {
                postedFile = value;
            }
        }

        public string SavePath
        {
            get
            {
                if (savePath != "") return savePath;
                return "c:\\";
            }
            set
            {
                savePath = HttpContext.Current.Server.MapPath("~") + @"\" + value + @"\";
            }
        }

        public string SaveName
        {
            get
            {
                return saveName;
            }
            set
            {
                saveName = value;
            }
        }

        public int FileLength
        {
            get
            {
                if (fileLength != 0) return fileLength;
                return 1024;
            }
            set
            {
                fileLength = value * 1024;
            }
        }



        public string Extension
        {
            get
            {
                if (extension != "") return extension;
                return "txt";
            }
            set
            {
                extension = value;
            }
        }

        public string PathToName(string path)
        {
            int pos = path.LastIndexOf("\\");
            return path.Substring(pos + 1);
        }

        public string Upload()
        {
            if (PostedFile != null)
            {
                try
                {
                    string fileName = PathToName(PostedFile.FileName);
                    //if (!fileName.EndsWith(Extension)) return "You must select " + Extension + " file!";
                    if (PostedFile.ContentLength > FileLength) return "overflew";
                    PostedFile.SaveAs(SavePath + SaveName);
                    return "success";
                }
                catch (System.Exception exc)
                { return exc.Message; }
            }
            return "fail";
        }
    }
}