using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using LXS.BLL;
using System.Data;

namespace WebService
{
    /// <summary>
    /// Summary description for infopath
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class infopath : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public System.Data.DataSet GetPurchaseGroupList()
        {
            LXS.BLL.MD_PurchaseGroup bll = new MD_PurchaseGroup();
            DataSet ds = bll.GetList(" FlagDelete=0 ");
            return ds;
        }
    }

}
