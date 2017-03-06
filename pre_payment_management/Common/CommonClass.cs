using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mime;
//using myJmail;
//using PubSet;

//常用函数系列:
//public static string Get_ClientIP() 得到客户端IP
//public static string Get_CMac(string IP) 得到客户端 CMac 地址
//public static string RequestF(string xPName,string xPType,int xLenDef) 安全接收数据系列
//public static string Show_Cont(string xStr) 过滤显示字串
//public static string Show_jsStr(string xStr) 过滤显示js

//安全检测函数:
//public static string CheckUrl(string xDirPage) 上页地址认证
//public static string Chk_Perm0(string xPerm,string xSys,string xAct) 权限认证系列
//public static string Chk_Perm1(string xPerm,string xSys,string xAct) 权限认证系列
//public static string Chk_Perm2(string xPerm,string xSys,string xAct) 权限认证系列

//邮件发送函数:
//public void SendEmail(string xSubj,string xCont,string FmAddr,string ToAddr) 
//public void SendSmtp(string xSubj,string xCont,string xFrom,string xTo)
//邮件发送2.0
//

//加密解密函数：
//public static string Enc_PW(string xID,string xPW,int xLen) 改装sha1+md5加密解密函数加密函数
//public static string Conv_10toXX(long xNum,int xBase) 10进制 转 XX 进制
//public static long Conv_XXto10(string xStr,int xBase) xx进制 转 10 进制
//public static string DESDec(string pToDecrypt, string sKey) DES解密
//public static string DESEnc(string pToEncrypt, string sKey) DES加密密
//public static string DESMhywy(string xStr, string xType) 改装DES
//public static string DESSwap(string xStr, int xN) DES 改装算法

//文件操作函数：
//public static string fCreate(string xFile,string xContent) 建立文件
//public void ImgCode (Page containsPage,string validateNum) 生成图片认证码
//public static string ImgShow(string xPName,int xImgW,int xImgH,int xMaxW,int xMaxH) 按比例大小显示图片
//public static DataTable fList(string xPath) 显示文件列表 显示文件夹列表
//public static string fRead(string xFile) 文件读取函数
//public static ArrayList fUpload(HttpPostedFile xFile,string xPath,string xOrg,int xSize,string xType) 文件上传认证函数
//public static MoveFile(string SourcFilePath,string DirectFilePath) 转移文件

//时间/随即字串函数：
//public static string Get_AutoID(int xLen) 自动随机 ID 串
//public static string Get_HHMMSS()  得到时间HHmmss格式
//public static string Get_TimeID()  得到年月日时间YYYY-MM-DD HH:mm:ss格式
//public static string Get_YYYYMMDD() 得到年月日YYYYMMDD格式
//public static string Get_mSec() 得到毫秒
//public static string Rnd_ID(string xType,int xLen)  自动随机 ID 串
//public static int Rnd_NM(int xN,int xM)  自动随机 N ~ M 数字


//数据库操作函数：
//public static void rs_AddLog(string xconn,string xUSID,string xAct,string xSys,string xNote) 添加 Log
//public static int rs_Count(string xConn,string xSQL,string xTable) 计算记录条数
//public static void rs_DoSQL(string xConn,string xSQL) 执行SQL语句
//public static string rs_Exist(string xConn,string xSQL,string xTable) 检查是否存在
//public static void rs_List(DropDownList xDDList,string xConn,string xSql,string xDefValue,string xClear) 绑定DropDownList
//public static string rs_Val(string xConn,string xSQL,string xTable,string xCol) 得到特定 字段值


namespace LXS.Common
{
    public class WebCS
    {
        /// <summary>
        /// 将string创换成dropdownlist
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>dropdownlist</returns>
        public static DropDownList StringToDDL(string str)
        {
            DropDownList ddl = new DropDownList();
            string[] b = str.Split(new Char[] { ',' });
            ListItem l = null;
            for (int i = 0; i < b.Length && b[i] != ""; i++)
            {
                l = new ListItem();
                l.Text = b[i];
                l.Value = b[i];
                ddl.Items.Add(l);
            }
            return ddl;
        }

    
        /// <summary>
        /// 从数据库读取byte[]并临时创建图片
        /// </summary>
        /// <param name="picname">要生成的图片名</param>
        /// <param name="picfile">图片文件的数据</param>
        /// <returns></returns>
        public static void WritePic(string picname, byte[] picfile)
        {
            if (File.Exists(picname))
                File.Delete(picname);
            FileStream fs = new FileStream(picname, FileMode.CreateNew);
            BinaryWriter br = new BinaryWriter(fs);

            for (int i = 0; i < picfile.Length; i++)
            {
                //从br流中读取一个Byte并马上写入bw流
                br.Write(picfile[i]);
            }

            br.Close();
        }

        
        /// <summary>
        /// 将要上传的图片写到byte[]中
        /// </summary>
        /// <param name="strPicPath">图片名</param>
        /// <returns>图片文件的数据</returns>
        public static byte[] ReadPic(string strPicPath)
        {
            if (!File.Exists(strPicPath))
                return null;

            FileStream fs;
            byte[] iResult;
            bool bOk = false;

            fs = new FileStream(strPicPath, FileMode.Open);
            iResult = new byte[fs.Length];

            try
            {
                BinaryReader br = new BinaryReader(fs);
                br.Read(iResult, 0, Convert.ToInt32(fs.Length));

                bOk = true;
            }
            catch { }
            finally
            {
                fs.Close();
                fs = null;
            }

            if (bOk)
                return iResult;
            else
                return null;
        }
        
        /// <summary>
        /// 计算中文字符数
        /// </summary>
        /// <param name="str">要计算的字符串</param>
        /// <returns>中文字符数</returns>
        public static int getChineselen(string str)
        {
            byte[] b = new byte[2196];
            b = System.Text.ASCIIEncoding.Default.GetBytes(str);
            return b.Length;
        }

        //2进制与10进制之间的转换
        public static string ConvertString(string value, int fromBase, int toBase)
        {

            int intValue = Convert.ToInt32(value, fromBase);
            string temp = Convert.ToString(intValue, toBase);
            if (toBase == 2)//10进制转2进制时做补0处理
            {
                for (int i = 1; i < 4; i++)
                {
                    if (temp.Length <= i)
                        temp = '0' + temp;
                }
            }
            return temp;
        }
        
        /// <summary>
        /// 超过字符数加点截断
        /// </summary>
        /// <param name="stringToSub">要截取的字符串</param>
        /// <param name="length">截取的长度(汉字)</param>
        /// <returns>截取后的字符串</returns>
        public static string CutTitle(string stringToSub, int length)
        {
            length = length * 2;
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    nLength += 2;
                }
                else
                {
                    nLength = nLength + 1;
                }

                if (nLength <= length)
                {
                    sb.Append(stringChar[i]);
                }
                else
                {
                    break;
                }
            }
            if (sb.ToString() != stringToSub)
            {
                sb.Append("...");
            }
            return sb.ToString(); 
        }

        //写错误日志
        public static void WriteLog(string path, string info,string content)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(path);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ErrorId"] = ds.Tables[0].Rows.Count + 1;
                dr["ErrorInfo"] = info.Trim();
                dr["ErrorContent"] = content.Trim();
                dr["CreateDate"] = DateTime.Now;
                ds.Tables[0].Rows.Add(dr);
                ds.WriteXml(path);
            }
            catch { }
        }


        public static string RequestQ(string xPName, string xPType, int xLenDef)
        {
            string PValue = HttpContext.Current.Request.QueryString[xPName];
            return RequestS(PValue, xPType, xLenDef);
        }
        public static string RequestF(string xPName, string xPType, int xLenDef)
        {
            string PValue = HttpContext.Current.Request.Form[xPName];
            return RequestS(PValue, xPType, xLenDef);
        }
        public static string RequestA(string xPName, string xPType, int xLenDef)
        {
            string PValue = HttpContext.Current.Request[xPName];
            return RequestS(PValue, xPType, xLenDef);
        }

        public static string RequestS(string xPName, string xPType, int xLenDef)
        {
            string PValue = xPName + "";
            string tmpType = xPType;
            switch (tmpType)
            {
                case "N": // Number -1,0,1
                    try { string tI = (int.Parse(PValue)).ToString(); }
                    catch { PValue = xLenDef.ToString(); }
                    break;
                case "D": // Date 
                    try { DateTime tD = DateTime.Parse(PValue); }
                    catch
                    {
                        PValue = xLenDef.ToString();
                        PValue = PValue.Substring(0, 4) + "-" + PValue.Substring(4, 2) + "-" + PValue.Substring(6, 2);
                    }
                    break;
                default: // Text xLenDef = 19001231
                    if (PValue.Length > xLenDef) { PValue = PValue.Substring(0, xLenDef); }
                    PValue = PValue.Replace("'", "''");
                    break;
            }
            return PValue;
        }

        public static string Show_Text(string xStr)
        {
            string tStr = xStr;
            tStr = tStr.Replace("<", "&lt;");
            tStr = tStr.Replace(">", "&gt;");
            tStr = tStr.Replace("\r", "<br>");
            tStr = tStr.Replace("  ", "&nbsp;&nbsp;");
            tStr = tStr.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            return tStr;
        }

        public static string Show_Cont(string xStr)
        {
            string tStr = Show_Text(xStr);
            return tStr;
        }

        public static string Show_Form(string xStr)
        {
            string tStr = xStr;
            tStr = tStr.Replace("\\'", "'");
            tStr = tStr.Replace("\\\"", "\"");
            tStr = tStr.Replace("<", "&lt;");
            tStr = tStr.Replace(">", "&gt;");
            return tStr;
        }

        public static string Show_jsStr(string xStr)
        {
            string tStr = xStr;
            tStr = tStr.Replace("\'", "\\\'");
            tStr = tStr.Replace("\"", "\\\"");
            return tStr;
        }

        public static string Get_ClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        public static string Get_CMac(string IP) //para IP is the client@#s IP 
        {
            string dirResults = ""; //IP = "192.168.37.175";//"211.156.182.34";
            ProcessStartInfo psi = new ProcessStartInfo();
            Process proc = new Process();
            psi.FileName = "nbtstat";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "-A " + IP;
            psi.UseShellExecute = false;
            proc = Process.Start(psi);
            dirResults = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            dirResults = dirResults.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            Regex reg = new Regex("Mac[ ]{0,}Address[ ]{0,}=[ ]{0,}(?<key>((.)*?)) __MAC", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match mc = reg.Match(dirResults + "__MAC");
            if (mc.Success)
            {
                return mc.Groups["key"].Value;
            }
            else
            {
                reg = new Regex("Host not found", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                mc = reg.Match(dirResults);
                if (mc.Success) { return "Host not found!"; }
                else { return "N/A"; }
            }
        }

        public static string FilterSQL(string strSql,int xLenDef) {
            string PValue = strSql;
            if (PValue.Length > xLenDef) { PValue = PValue.Substring(0, xLenDef); }
            PValue = PValue.Replace("'", "''");
            return PValue;
        }
    }

    public class WebID
    {
        public static string Get_TimeID()
        {
            string YMDHMS = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string mSec = Get_mSec();
            return YMDHMS + mSec;
        }

        public static string Get_YYYYMMDD()
        {
            return System.DateTime.Now.ToString("yyyyMMdd");
        }

        public static string Get_MMDDYYYY()
        {
            return System.DateTime.Now.ToString("MMddyyyy");
        }

        public static string Get_HHMMSS()
        {
            return System.DateTime.Now.ToString("HHmmss");
        }

        public static string Get_mSec()
        {
            string mSec = System.DateTime.Now.Millisecond.ToString();
            mSec = "00" + mSec;
            return mSec.Substring(mSec.Length - 3, 3);
        }

        public static string Get_AutoID(int xLen)
        {
            long tNum = DateTime.Now.Ticks;
            string tStr = tNum.ToString("X16");
            if (xLen < tStr.Length) { tStr = tStr.Substring(0, xLen); }
            else { tStr += Rnd_ID("KEY", xLen - tStr.Length); }
            return tStr;
        }

        public static string Rnd_ID(string xType, int xLen)
        {
            string rChar;
            int rMax, i;
            string orgNum = "0123456789";     //  10   xType = 0,A,KEY
            string orgCap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //  26   .  -  _  $  |  !  #  [  ]  
            string orgKey = "ABCDEFGHJKLMNPQRSTUVWXY";      //  23   I  O  Z
            string oStr = "";
            string tStr = "";
            switch (xType)
            {
                case "0": rMax = 10; tStr = orgNum; break;
                case "A": rMax = 26; tStr = orgCap; break;
                default: rMax = 33; tStr = orgNum + orgKey; break;
            }
            System.Random ran = new Random(System.DateTime.Now.Second + (int)System.DateTime.Now.Ticks);
            for (i = 0; i < Math.Abs(xLen); i++)
            {
                int rin = ran.Next(0, rMax - 1);
                rChar = tStr.Substring(rin, 1);
                oStr += rChar;
            }
            return oStr;
        }

        public static int Rnd_NM(int xN, int xM)
        {
            System.Random ran = new Random(System.DateTime.Now.Second + (int)System.DateTime.Now.Ticks);
            return ran.Next(xN, xM);
        }
    }

    
    public class WebCheck
    {
        public static string CheckUrl(string xDirPage)
        {
            string sPrev = HttpContext.Current.Request.ServerVariables["http_referer"] + "";
            string sNow = HttpContext.Current.Request.Url.ToString();
            sPrev = sPrev.ToLower();
            sPrev = sPrev.Replace("http://", "");
            sPrev = sPrev.Replace("www.", "");
            if (sPrev.IndexOf("/", 0) > 0)
            {
                sPrev = sPrev.Substring(0, sPrev.IndexOf("/", 0));
            }
            sNow = sNow.ToLower();
            if ((sPrev.Length == 0) || (sNow.IndexOf(sPrev, 0) < 0))
            {
                if (xDirPage == "") { /*xObj.Response.Redirect(Config.WHome);*/ }
                else { HttpContext.Current.Response.Redirect(xDirPage); }
            }
            return sPrev;
        }

        public static string Chk_Perm1(string xSys, string xAct, string xPath)
        {
            string AdmPerm = (string)HttpContext.Current.Session["AdmPerm"] + "";
            string flgPerm = "Error";
            if (AdmPerm.Length < 3) { flgPerm = "Error"; }
            else { flgPerm = Chk_Perm0(AdmPerm, xSys, xAct); }
            if (flgPerm == "Error")
            {
                if (xPath == "") { /*xObj.Response.Redirect(Config.WHome);*/ }
                else { HttpContext.Current.Response.Redirect(xPath); }
            }
            return flgPerm;
        }

        public static string Chk_Perm2(string xSys, string xAct, string xPath)
        {
            string AdmPerm = (string)HttpContext.Current.Session["AdmPerm"] + "";
            string MemPerm = (string)HttpContext.Current.Session["MemPerm"] + "";
            string flgPerm = "Error";
            if (MemPerm.Length < 3) { flgPerm = "Error"; }
            else { flgPerm = Chk_Perm0(MemPerm, xSys, xAct); }
            if (AdmPerm.Length > 3) { flgPerm = "Pass"; }
            if (flgPerm == "Error")
            {
                if (xPath == "") { HttpContext.Current.Response.Redirect("/"); }
                else { HttpContext.Current.Response.Redirect(xPath); }
            }
            return flgPerm;
        }

        public static string Chk_Perm0(string xPerm, string xSys, string xAct)
        {
            string flgPerm = "(N/A)";
            if (xSys == "") { flgPerm = "Pass"; }
            else
            {
                if (xPerm.IndexOf("(" + xSys + ")") >= 0)
                {
                    if (xAct == "") { flgPerm = "Pass"; }
                    else
                    {
                        int p1 = xPerm.IndexOf("(" + xSys + ")");
                        int p2 = xPerm.IndexOf("(/" + xSys + ")");
                        if ((p1 >= 0) && (p2 > p1))
                        {
                            xPerm = xPerm.Substring(p1, p2 - p1);
                            xAct = xAct.ToUpper();
                            if (xPerm.IndexOf("" + xAct + "") >= 0)
                            { flgPerm = "Pass"; }
                            else { flgPerm = "Error"; }
                        }
                        else { flgPerm = "Error"; }
                    }
                }
                else { flgPerm = "Error"; }
            }
            return flgPerm;
        }

        public static bool DataSetCheck(DataSet ds)
        {
            if (ds == null)
            {
                return false;
            }
            if (ds.Tables.Count == 0)
            {
                return false;
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class WebEnc
    {
        public static string Enc_PW(string xID, string xPW, int xLen)
        {
            string eStr1 = FormsAuthentication.HashPasswordForStoringInConfigFile(xID, "sha1"); // 40
            string eStr2 = "";
            string tStr;
            for (int i = 0; i < 4; i++)
            {
                tStr = eStr1.Substring(10 * i, 10);
                eStr2 += FormsAuthentication.HashPasswordForStoringInConfigFile(xPW + tStr, "md5"); // 32
            }
            int ne1 = (128 - xLen) / 2;
            return eStr2.Substring(ne1, xLen);
        }

        //public static string DESMhywy(string xStr, string xType)
        //{
        // string oStr,sKey=PubSet.Config.DESOffset;
        // if (xType=="Enc") 
        // { 
        //  oStr = DESEnc(xStr,sKey); 
        //  oStr = Mhywy.Common.WebEnc.DESSwap(oStr,4);
        // }
        // else    
        // { 
        //  xStr = Mhywy.Common.WebEnc.DESSwap(xStr,4);
        //  oStr = DESDec(xStr,sKey);
        // }
        // return oStr;
        //}

        public static string DESSwap(string xStr, int xN)
        {
            int sLen;
            string s1 = "", s2 = "", s3 = "";
            sLen = xStr.Length;
            if ((xN > 1) && (xN < sLen))
            {
                s1 = xStr.Substring(0, xN);
                s2 = xStr.Substring(sLen - xN, xN);
            }
            for (int i = (sLen - xN - 1); i >= xN; i--)
            {
                s3 += xStr.Substring(i, 1);
            }
            return s1 + s3 + s2; // xStr.Substring(xN,sLen-(2*xN))
        }



        public static string Conv_10toXX(long xNum, int xBase)
        {
            string oStr = "0123456789ABCDEFGHJKLMNPQRSTUVWXY";
            long nm = xNum;
            long ni = nm / xBase;
            long nr = nm % xBase;
            int nk = (int)nr;
            string ch = "";
            string ns = "";
            while (nm >= xBase)
            {
                ni = nm / xBase;
                nr = nm % xBase;
                nk = (int)nr;
                ch = oStr.Substring(nk, 1);
                ns += ch;
                nm = ni;
            }
            if (nm != 0)
            {
                nk = (int)nm;
                ch = oStr.Substring(nk, 1);
                ns += ch;
            }
            string rs = "";
            for (int i = ns.Length; i > 0; i--)
            {
                rs += ns.Substring(i - 1, 1);
            }
            return rs;
        }

        public static long Conv_XXto10(string xStr, int xBase)
        {
            string oStr = "0123456789ABCDEFGHJKLMNPQRSTUVWXY";
            int i, p;
            double rn = 0;
            string ch = "";
            for (i = xStr.Length; i > 0; i--)
            {
                ch = xStr.Substring(i - 1, 1);
                p = oStr.IndexOf(ch);
                rn += p * Math.Pow(xBase, (xStr.Length - i));
            }
            return (long)rn;
        }
    }

    public class WebEmail
    {
        //public void SendEmail(string xSubj, string xCont, string FmAddr, string ToAddr)
        //{
        //    //
        //    ////string MsgSubj;
        //    //
        //}

        //public void SendSmtp(string xSubj, string xCont, string xFrom, string xTo)
        //{
        //    MailMessage mObj = new MailMessage();
        //    mObj.From = xFrom;
        //    mObj.To = xTo;
        //    mObj.Subject = xSubj;
        //    mObj.Body = xCont;
        //    mObj.BodyFormat = MailFormat.Html;
        //    //mObj.BodyEncoding = "gb2312";
        //    //mObj.Priority = MailPriority.Normal/Low/High;
        //    //mObj.Attachments.Add(new MailAttachment("c:\\test.txt"));
        //    SmtpMail.Send(mObj);
        //}
    }

    public class WebEmaiNew
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTitle">邮件主题</param>
        /// <param name="mailBody">邮件内容</param>
        /// <param name="sendMailAddress">收件人地址</param>
        /// <param name="fromAddress">发件人地址</param>
        /// <param name="smtpAddress">SMTP服务器地址</param>
        /// <param name="smtpUserName">SMTP服务器登录用户名</param>
        /// <param name="smtpUserPassword">SMTP服务器登录密码</param>
        public static void SendMail(string mailTitle, string mailBody, string sendMailAddress, string fromAddress, string smtpAddress, string smtpUserName, string smtpUserPassword)
        {
            //Message jmail = new Message();

            //jmail.From = mailTitle;

            //jmail.AddRecipient(fromAddress, null, null);

            //jmail.Logging = true;

            //jmail.MailServerUserName = "brookes";

            //jmail.MailServerPassWord = "walkor";

            //jmail.Body = mailBody;

            //jmail.Subject = mailTitle;

            //jmail.Send(sednMailAddress, false);


            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            //收件人
            message.To.Add(sendMailAddress);
            ////抄送
            //foreach (string mailAddress in otherSendAddress)
            //{
            //    if (!string.IsNullOrEmpty(mailAddress))
            //    {
            //        message.CC.Add(mailAddress);
            //    }
            //}        
            //主题
            message.Subject = mailTitle;
            message.From = new System.Net.Mail.MailAddress(fromAddress);
            message.Body = mailBody;
            message.IsBodyHtml = true;
            ////发送附件
            //if (fulAttachment.HasFile)
            //{
            //    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(fulAttachment.PostedFile.FileName);
            //    message.Attachments.Add(attachment);
            //}
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpAddress, 8825);//SMTP服务器地址
            smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpUserPassword);

            //try
            //{            
            smtp.Send(message);
            //}
            //catch (System.Net.Mail.SmtpException ex)
            //{
            //    lblReturnMessage.Text = "Send Error:" + ex.Message;
            //}

        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTitle">邮件主题</param>
        /// <param name="mailBody">邮件内容</param>
        /// <param name="sendMailAddress">收件人地址</param>
        /// <param name="otherSendAddress">抄送地址</param>
        /// <param name="fromAddress">发件人地址</param>
        /// <param name="smtpAddress">SMTP服务器地址</param>
        /// <param name="smtpUserName">SMTP服务器登录用户名</param>
        /// <param name="smtpUserPassword">SMTP服务器登录密码</param>
        public static void SendMail(string mailTitle, string mailBody, string sendMailAddress, string[] otherSendAddress, string fromAddress, string smtpAddress, string smtpUserName, string smtpUserPassword)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            //收件人
            message.To.Add(sendMailAddress);

            //抄送
            foreach (string mailAddress in otherSendAddress)
            {
                if (!string.IsNullOrEmpty(mailAddress))
                {
                    message.CC.Add(mailAddress);
                }
            }

            //主题
            message.Subject = mailTitle;

            //发送人地址
            message.From = new System.Net.Mail.MailAddress(fromAddress);

            //邮件主体
            message.Body = mailBody;
            message.IsBodyHtml = true;

            ////发送附件
            //if (fulAttachment.HasFile)
            //{
            //    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(fulAttachment.PostedFile.FileName);
            //    message.Attachments.Add(attachment);
            //}

            //SMTP服务器设置
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpAddress);
            smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpUserPassword);

            //发送邮件
            smtp.Send(message);


        }
        
        /// <summary>
        /// Send email with attachment
        /// </summary>
        /// <param name="mailTitle"></param>
        /// <param name="mailBody"></param>
        /// <param name="sendMailAddress"></param>
        /// <param name="fromAddress"></param>
        /// <param name="fromName"></param>
        /// <param name="smtpAddress"></param>
        /// <param name="smtpUserName"></param>
        /// <param name="smtpUserPassword"></param>
        /// <param name="sbXML"></param>
        public static void SendMail(string mailTitle, string mailBody, string sendMailAddress, string[] otherSendAddress, string fromAddress, string fromName, string smtpAddress, string smtpUserName, string smtpUserPassword, StringBuilder sbXML)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            //收件人
            message.To.Add(sendMailAddress);

            //抄送
            foreach (string mailAddress in otherSendAddress)
            {
                if (!string.IsNullOrEmpty(mailAddress))
                {
                    message.CC.Add(mailAddress);
                }
            }

            //主题
            message.Subject = mailTitle;

            //发送人地址
            message.From = new System.Net.Mail.MailAddress(fromAddress);

            //邮件主体
            message.Body = mailBody;
            message.IsBodyHtml = true;

            ////发送XML附件
            
            UTF8Encoding uniEncoding = new UTF8Encoding();
            byte[] byteArray=uniEncoding.GetBytes(sbXML.ToString());
            System.IO.MemoryStream ms = new MemoryStream(byteArray);
            
            ContentType ct = new ContentType(MediaTypeNames.Text.Xml);
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, ct);
            ContentDisposition disposition = attachment.ContentDisposition;
            // Suggest a file name for the attachment.
            disposition.FileName = "IP_" + WebID.Get_YYYYMMDD() + ".xml";
            message.Attachments.Add(attachment);

            //SMTP服务器设置
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpAddress, 8825);
            smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpUserPassword);

            //发送邮件
            smtp.Send(message);


        }


        public static void SendMail(string mailTitle, string mailBody, string sendMailAddress, string[] otherSendAddress, string[] bccAddress, System.Net.Mail.MailAddress fromAddress, string smtpAddress, string smtpUserName, string smtpUserPassword)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            //收件人
            message.To.Add(sendMailAddress);
            //抄送
            foreach (string mailAddress in otherSendAddress)
            {
                if (!string.IsNullOrEmpty(mailAddress))
                {
                    message.CC.Add(mailAddress);
                }
            }
            //暗送
            foreach (string mailAddress in bccAddress)
            {
                if (!string.IsNullOrEmpty(mailAddress))
                {
                    message.Bcc.Add(mailAddress);
                }
            }

            //主题
            message.Subject = mailTitle;

            //发送人地址
            message.From = fromAddress;

            //邮件主体
            message.Body = mailBody;
            message.IsBodyHtml = true;

            ////发送附件
            //if (fulAttachment.HasFile)
            //{
            //    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(fulAttachment.PostedFile.FileName);
            //    message.Attachments.Add(attachment);
            //}

            //SMTP服务器设置
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpAddress, 8825);
            smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpUserPassword);

            //发送邮件
            smtp.Send(message);


        }
    }

    public class WebFile
    {
        // File.Delete("F:\\net\\241.net\\t2\\t2\\t2\txt");
        // Directory.CreateDirectory("F:\\net\\241.net\\t2\\t2\\t2");  
        // Directory.Delete();
        public static string fCreate(string xFile, string xContent)
        {
            string fRes;
            FileStream fs;
            if (!File.Exists(xFile))
            {
                fs = new FileStream(xFile, FileMode.OpenOrCreate, FileAccess.Write);
                fRes = "Create";
            }
            else
            {
                fs = new FileStream(xFile, FileMode.Truncate, FileAccess.Write);
                fRes = "Edit";
            }
            StreamWriter w = new StreamWriter(fs);
            w.Write(xContent);
            w.Flush();
            fs.Close();
            return fRes;
        }
        public static string fRead(string xFile)
        {
            string fRes;
            if (!File.Exists(xFile)) { fRes = "\0"; }
            else
            {
                FileStream fs = new FileStream(xFile, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs); // ,Encoding.GetEncoding(950),true
                fRes = sr.ReadToEnd();
                fs.Close();

            }
            return fRes;
        }

        public static DataTable fList(string xPath)
        {
            Directory.CreateDirectory(xPath);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Object Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Size", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Created", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Modified", typeof(string)));

            DirectoryInfo cd = new DirectoryInfo(xPath + "\\");
            foreach (DirectoryInfo Dir in cd.GetDirectories())
            {
                dr = dt.NewRow();
                dr[0] = Dir.Name;
                dr[1] = "Dir.";
                dr[2] = "";
                dr[3] = Dir.CreationTime.ToString("yy-MM-dd HH:mm");
                dr[4] = Dir.LastWriteTime.ToString("yy-MM-dd HH:mm");
                dt.Rows.Add(dr);
            }
            foreach (FileInfo Fil in cd.GetFiles())
            {
                dr = dt.NewRow();
                dr[0] = Fil.Name;
                dr[1] = "File";
                dr[2] = Fil.Length; // "999,999,999,999"
                dr[3] = Fil.CreationTime.ToString("yy-MM-dd HH:mm");
                dr[4] = Fil.LastWriteTime.ToString("yy-MM-dd HH:mm");
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static ArrayList fUpload(HttpPostedFile xFile, string xPath, string xOrg, int xSize, string xType)
        {
            ArrayList OutArr = new ArrayList();
            OutArr.Add(""); //Rerurn Result 
            OutArr.Add(""); //Extend File Name
            OutArr.Add(""); //Org File Name
            OutArr.Add("0"); //Size
            OutArr.Add("0"); //Width
            OutArr.Add("0"); //Height

            HttpPostedFile pFile = xFile; // Get Files Info
            int fSize = pFile.ContentLength;
            byte[] fData = new byte[fSize];
            string upFlag = "(OK)";
            string fType = "", fName = "";

            xSize *= 1024;    // Check Files Size
            if ((xSize < 5120) || (xSize > 204800)) { xSize = 198 * 1024; }
            if (fSize == 0) { upFlag = "Siz0"; }
            if (fSize > xSize) { upFlag = "Size"; }
            OutArr[3] = fSize.ToString(); //OutFileSize = fSize; // *****

            if (upFlag == "(OK)")   // Check Files Type
            {
                int cPos = xOrg.LastIndexOf("\\") + 1;
                fName = xOrg.Substring(cPos, (xOrg.Length - cPos));
                fType = fName;
                cPos = fType.LastIndexOf(".");
                if (cPos > 0) { fType = fName.Substring(cPos, (fName.Length - cPos)).ToUpper(); }
                else { fType = "(ER)"; }
                OutArr[1] = fType; //OutFileExt = fType;  // *****
                OutArr[2] = fName; //OutFileName = fName; // *****
                xType = xType.ToUpper();
                if (xType.IndexOf(fType) < 0) { upFlag = "Type"; }
                string yType = "/.ASP/.ASPX/.EXE/.ASAX/.ASA/";
                if (yType.IndexOf(fType) >= 0) { upFlag = "yTyp"; }
            }

            if (upFlag == "(OK)")  // Save Files
            {
                pFile.InputStream.Read(fData, 0, fSize);
                xPath += fType;
                FileStream tFile = new FileStream(xPath, FileMode.Create);
                tFile.Write(fData, 0, fData.Length);
                tFile.Close();
                if ((fType == ".GIF") || (fType == ".JPG") || (fType == ".JPEG")) // Get Size
                {
                    FileStream fs = File.Open(xPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Bitmap tImg = new Bitmap(fs);
                    OutArr[4] = tImg.Width.ToString(); //OutFileWidth = tImg.Width;  // *****
                    OutArr[5] = tImg.Height.ToString(); //OutFileHeight = tImg.Height; // *****
                    fs.Close();
                }
            }
            OutArr[0] = upFlag; //OutFileRes = upFlag;
            return OutArr;

        }


        public static string ImgShow(string xPName, int xImgW, int xImgH, int xMaxW, int xMaxH)
        {
            string fRes = "";
            float oW = xMaxW, oH = xMaxH;
            float oScale = xMaxW / xMaxH;
            float iScale = xImgW / xImgW;
            if ((xImgW > xMaxW) && (xImgH > xMaxH))
            { // >>
                if (iScale > oScale) { oW = xMaxW; oH = xImgH / iScale; }
                if (iScale < oScale) { oH = xMaxH; oW = xMaxW * iScale; }
            }
            if ((xImgW > xMaxW) && (xImgH < xMaxH))
            { // ><
                oW = xMaxW; oH = xImgH / iScale;
            }
            if ((xImgW < xMaxW) && (xImgH > xMaxH))
            { // <>
                oH = xMaxH; oW = xMaxW * iScale;
            }
            if ((xImgW < xMaxW) && (xImgH < xMaxH))
            { // <<
                oW = xImgW; oH = xImgH;
            }
            fRes = "<img border='0' src='" + xPName + "' width=" + oW + " height=" + oH + ">";
            return fRes;
        }

        /// <summary>
        /// 创建验证码的图片 CreateValidateGraphic
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public void ImgCode(Page containsPage, string validateNum)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateNum.Length * 12.5), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 5; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }//
                Font font = new Font("Courier", 12, (FontStyle.Bold)); //Arial |FontStyle.Italic
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 10; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片
                containsPage.Response.Clear();
                containsPage.Response.ContentType = "image/jpeg";
                containsPage.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

    }
    // Get_rsOpt(xconn,xTab,xID,xName,xType,xWhere,xDef)  
    // Get_Option(xmid,xfirst,xend,xstep) ; 
    // Get_vPath(xLen) Get_fName()
}


