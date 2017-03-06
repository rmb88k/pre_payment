using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace LXS.Common
{
    public class CookieHelper
    {
        public static string get(string CookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie != null)
                return cookie.Value;
            else
                return null;
        }
        public static string get(string ParentName, string CookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[ParentName];
            if (cookie != null)
                return HttpContext.Current.Request.Cookies[ParentName][CookieName]; 
            else
                return null;
        }

        public static void set(string CookieName, string CookieValue, int ExpiresDay)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            cookie.Value = CookieValue;
            if (ExpiresDay > 0)
                cookie.Expires = DateTime.Now.AddDays(ExpiresDay);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        public static void set(string ParentName, string CookieName, string CookieValue, int ExpiresDay)
        {
            HttpCookie cookie;
            if (get(ParentName) == null)
                cookie = new HttpCookie(CookieName);
            else
                cookie = HttpContext.Current.Request.Cookies[ParentName];

            cookie.Values[CookieName] = CookieValue;
            if (ExpiresDay > 0)
                cookie.Expires = DateTime.Now.AddDays(ExpiresDay);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void remove(string CookieName)
        {
            System.Web.HttpContext.Current.Response.Cookies[CookieName].Value = null;

        }
        public static void remove(string ParentName, string CookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[ParentName];
            cookie.Values.Remove(CookieName);
        }
    }
    
}
