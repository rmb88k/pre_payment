using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace PFU
{
    public class Cookie
    {
        //static readonly string cookieName = ConfigurationManager.AppSettings["CookieName"].ToString();
        static string cookieDomain = ConfigurationManager.AppSettings["CookieDomain"].ToString();

        //删除Cookie
        public static void Logout(string cookieName)
        {
            HttpContext.Current.Response.Cookies[cookieName].Value = "0";
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Parse("1900-1-1");
            HttpContext.Current.Response.Cookies[cookieName].Path = "/";
            HttpContext.Current.Response.Cookies[cookieName].Domain = cookieDomain;
        }
        //给Cookie赋值
        public static void SetCookie(string cookieName, string cookieValue)
        {
            int cookieHour = 0;
            int.TryParse(ConfigurationManager.AppSettings["CookieHour"], out cookieHour);
            DateTime expireTime = DateTime.Now.AddHours(cookieHour <= 0 ? 1 : cookieHour);

            HttpContext.Current.Response.Cookies[cookieName].Value = cookieValue;
            HttpContext.Current.Response.Cookies[cookieName].Expires = expireTime;
            HttpContext.Current.Response.Cookies[cookieName].Path = "/";
            HttpContext.Current.Response.Cookies[cookieName].Domain = cookieDomain;
        }


        //读取Cookie的值
        public static HttpCookie GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            return cookie;
        }

    }
}