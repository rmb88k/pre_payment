using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.UI;
using System.Collections;
using System.Text.RegularExpressions;

public partial class PagerNav : System.Web.UI.UserControl
{
    protected const string HTML1 = "<table cellpadding=0 cellspacing=0 ><tr><td>";
    protected const string HTML2 = "</td></tr></table>";
    private static readonly Regex RX = new Regex(KEY_QUERYSTRING + @"=\d+", RegexOptions.Compiled);
    protected const string KEY_QUERYSTRING = "CurrentPageIndex";
    protected System.Web.UI.WebControls.Label lblNumeral;

    private IList dataSource;
    private DataTable dataTable;
    private int pageSize = 10;
    private int bigPageSize = 9;
    private int currentPageIndex = 1;
    private string keyQueryString = KEY_QUERYSTRING;
    private int itemCount;
    protected string emptyText = string.Empty;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // ÔÚ´Ë´¦·ÅÖÃÓÃ»§´úÂëÒÔ³õÊ¼»¯Ò³Ãæ
        //			if(!IsPostBack)
        //			{
        //				this.lblNumeral.Text = CreateNumericPager();
        //			}

    }

    override protected void Render(HtmlTextWriter writer)
    {
        StringBuilder htmlScript = new StringBuilder();
        htmlScript.Append(HTML1);
        htmlScript.Append(CreateNumericPager());
        htmlScript.Append(HTML2);

        writer.Write(htmlScript.ToString());

    }

    public string CreateNumericPager()
    {
        string pageUrl = this.GetPageUrl();
        StringBuilder numeric = new StringBuilder();
        //int bigPageIndex = 0;
        int bigPageIndex = (CurrentPageIndex % bigPageSize) == 0 ? CurrentPageIndex / bigPageSize : (CurrentPageIndex / bigPageSize) + 1;
        int bigPageCount = (PageCount % bigPageSize) == 0 ? PageCount / bigPageSize : (PageCount / bigPageSize) + 1;

        int size = Math.Min(bigPageSize, PageCount - (bigPageIndex - 1) * bigPageSize);
        int start = (bigPageIndex - 1) * bigPageSize;
        if (bigPageIndex > 1)
            numeric.Append("<a href='" + pageUrl.Replace("<!--KEY_QUERYSTRING-->", keyQueryString + "=" + Convert.ToString((bigPageIndex - 1) * bigPageSize)) + "'><<</a>" + "&nbsp;");
        for (int i = 1; i <= size; i++)
        {
            if ((start + i) == CurrentPageIndex)
                numeric.Append("&nbsp;" + "<Font color='red'>" + Convert.ToString(start + i) + "</Font>");
            else
                numeric.Append("&nbsp;" + "<a href='" + pageUrl.Replace("<!--KEY_QUERYSTRING-->", keyQueryString + "=" + Convert.ToString(start + i)) + "'>" + Convert.ToString(start + i) + "</a>");

        }
        if ((bigPageIndex + 1) <= bigPageCount)
            numeric.Append("&nbsp;" + "<a href='" + pageUrl.Replace("<!--KEY_QUERYSTRING-->", keyQueryString + "=" + Convert.ToString(bigPageIndex * bigPageSize + 1)) + "'>>></a>");
        return numeric.ToString();
    }

    public IList ReturnDataSource()
    {
        int start = (CurrentPageIndex - 1) * pageSize;
        int size = Math.Min(pageSize, ItemCount - start);

        IList source = new ArrayList();

        //Add the relevant items from the datasource
        for (int i = 0; i < size; i++)
            source.Add(dataSource[start + i]);
        return source;
    }

    public DataTable ReturnDataTable()
    {
        int start = (CurrentPageIndex - 1) * pageSize;
        int size = Math.Min(pageSize, ItemCount - start);

        DataTable source = dataTable.Clone();

        //Add the relevant items from the datasource
        for (int i = 0; i < size; i++)
            source.ImportRow(dataTable.Rows[start + i]);
        return source;
    }


    private string GetPageUrl()
    {

        string pageUrl = Context.Request.Url.Query;
        if (pageUrl.IndexOf("?") < 0)
            return pageUrl += "?<!--KEY_QUERYSTRING-->";
        if (pageUrl.IndexOf(KeyQueryString) < 0)
            return pageUrl += "&<!--KEY_QUERYSTRING-->";
        else
            pageUrl = pageUrl.Replace(KeyQueryString, KEY_QUERYSTRING);

        //string query = Context.Request.Url.Query.Replace(COMMA, AMP);
        pageUrl = RX.Replace(pageUrl, "<!--KEY_QUERYSTRING-->");

        return pageUrl;
    }


    public object DataSource
    {
        set
        {
            try
            {
                dataSource = (IList)value;
                ItemCount = dataSource.Count;
            }
            catch
            {
                dataSource = null;
                ItemCount = 0;
            }
        }
    }

    public DataTable DataTableSource
    {
        set
        {
            try
            {
                dataTable = value;
                ItemCount = dataTable.Rows.Count;
            }
            catch
            {
                dataTable = null;
                ItemCount = 0;
            }
        }
    }

    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = value; }
    }

    protected int PageCount
    {
        get { return (ItemCount % pageSize) == 0 ? ItemCount / pageSize : (ItemCount / pageSize) + 1; }
    }

    protected int ItemCount
    {
        get { return itemCount; }
        set { itemCount = value; }
    }

    public int CurrentPageIndex
    {
        get { return currentPageIndex; }
        set { currentPageIndex = value; }
    }

    public string KeyQueryString
    {
        get { return keyQueryString; }
        set { keyQueryString = value; }
    }

    #region Web ´°ÌåÉè¼ÆÆ÷Éú³ÉµÄ´úÂë
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: ¸Ãµ÷ÓÃÊÇ ASP.NET Web ´°ÌåÉè¼ÆÆ÷Ëù±ØÐèµÄ¡£
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    ///		Éè¼ÆÆ÷Ö§³ÖËùÐèµÄ·½·¨ - ²»ÒªÊ¹ÓÃ´úÂë±à¼­Æ÷
    ///		ÐÞ¸Ä´Ë·½·¨µÄÄÚÈÝ¡£
    /// </summary>
    private void InitializeComponent()
    {

    }
}
        #endregion