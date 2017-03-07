using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LXS.Common;

public partial class ListPurchaseGroup : System.Web.UI.Page
{
    private LXS.BLL.MD_PurchaseGroup bll = new LXS.BLL.MD_PurchaseGroup();
    private const int PAGESIZE = 20;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddPurchaseGroup.aspx");
    }

    private void LoadPage()
    {

        DataSet ds = bll.GetList(this.GetCondition());
        if (WebCheck.DataSetCheck(ds) == false)
        {

            PageNav1.DataTableSource = ds.Tables[0];
            PageNav1.PageSize = PAGESIZE;
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            AspNetPager1.PageSize = PAGESIZE;

            this.gv.DataSource = null;
            this.gv.DataBind();
            //this.lbNoRecord.Visible = true;
     
            return;
        }

        //分页
        PageNav1.DataTableSource = ds.Tables[0];
        PageNav1.PageSize = PAGESIZE;
        AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        AspNetPager1.PageSize = PAGESIZE;

        PageNav1.CurrentPageIndex = AspNetPager1.CurrentPageIndex;

        gv.DataSource = PageNav1.ReturnDataTable();
        gv.DataKeyNames = new string[] { "ID" };
        gv.DataBind();

        //this.lbNoRecord.Visible = false;
        //this.div_op.Visible = !this.lbNoRecord.Visible;
    }

    private string GetCondition()
    {
        string strwhere = " flagdelete=0 ";
        if (!string.IsNullOrEmpty(this.tbPurchaseGroupCode.Text))
            strwhere += " AND PurchaseGroupCode='" + LXS.Common.WebCS.FilterSQL(this.tbPurchaseGroupCode.Text, 10) + "'";
        return strwhere;
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        this.LoadPage();
    }
}