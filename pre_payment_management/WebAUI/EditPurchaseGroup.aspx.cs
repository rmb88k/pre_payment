using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LXS.Common;


public partial class EditPurchaseGroupCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                int ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(ID);
            }
        }
    }

    private void ShowInfo(int ID)
    {
        LXS.BLL.MD_PurchaseGroup bll = new LXS.BLL.MD_PurchaseGroup();
        LXS.Model.MD_PurchaseGroup model = bll.GetModel(ID);
        this.txtID.Text = model.ID.ToString();
        this.txtPurchaseGroupCode.Text = model.PurchaseGroupCode;
        this.txtPurchaseGroupCodeName.Text = model.PurchaseGroupCodeName;
        this.txtCategory.Text = model.Category;
        this.txtERS_Layout.Text = model.ERS_Layout;
        this.txtPurchaseRequestor.Text = model.PurchaseRequestor;
        this.txtSTR_PurchaseGroup.Text = model.STR_PurchaseGroup;
        this.txtFirstReviewer.Text = model.FirstReviewer;
        this.txtSecondReviewer.Text = model.SecondReviewer;
        //this.txtFirstApprover.Text = model.FirstApprover;
        //this.txtSecondApprover.Text = model.SecondApprover;
        this.txtCopyToACC.Text = model.CopyToACC;
        this.txtCreateBy.Text = model.CreateBy;
        this.txtCreateDate.Text = model.CreateDate.ToString();
        this.txtEditBy.Text = model.EditBy;
        this.txtEditDate.Text = model.EditDate.ToString();
        //this.chkFlagDelete.Checked = model.FlagDelete;

    }

    public void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (!PageValidate.IsNumber(txtID.Text))
        {
            strErr += "ID格式错误！\\n";
        }
        if (this.txtPurchaseGroupCode.Text.Trim().Length == 0)
        {
            strErr += "PurchaseGroupCode不能为空！\\n";
        }
        /*if (this.txtPurchaseGroupCodeName.Text.Trim().Length == 0)
        {
            strErr += "PurchaseGroupCodeName不能为空！\\n";
        }
        if (this.txtCategory.Text.Trim().Length == 0)
        {
            strErr += "Category不能为空！\\n";
        }
        if (this.txtERS_Layout.Text.Trim().Length == 0)
        {
            strErr += "ERS_Layout不能为空！\\n";
        }
        if (this.txtPurchaseRequestor.Text.Trim().Length == 0)
        {
            strErr += "PurchaseRequestor不能为空！\\n";
        }
        if (this.txtSTR_PurchaseGroup.Text.Trim().Length == 0)
        {
            strErr += "STR_PurchaseGroup不能为空！\\n";
        }*/
        if (this.txtFirstReviewer.Text.Trim().Length == 0)
        {
            strErr += "FirstReviewer不能为空！\\n";
        }
        if (this.txtSecondReviewer.Text.Trim().Length == 0)
        {
            strErr += "SecondReviewer不能为空！\\n";
        }
        /*if (this.txtFirstApprover.Text.Trim().Length == 0)
        {
            strErr += "FirstApprover不能为空！\\n";
        }
        if (this.txtSecondApprover.Text.Trim().Length == 0)
        {
            strErr += "SecondApprover不能为空！\\n";
        }
        if (this.txtCopyToACC.Text.Trim().Length == 0)
        {
            strErr += "CopyToACC不能为空！\\n";
        }
        if (this.txtCreateBy.Text.Trim().Length == 0)
        {
            strErr += "CreateBy不能为空！\\n";
        }
        if (!PageValidate.IsDateTime(txtCreateDate.Text))
        {
            strErr += "CreateDate格式错误！\\n";
        }
        if (this.txtEditBy.Text.Trim().Length == 0)
        {
            strErr += "EditBy不能为空！\\n";
        }
        if (!PageValidate.IsDateTime(txtEditDate.Text))
        {
            strErr += "EditDate格式错误！\\n";
        }*/

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        int ID = int.Parse(this.txtID.Text);
        string PurchaseGroupCode = this.txtPurchaseGroupCode.Text;
        string PurchaseGroupCodeName = this.txtPurchaseGroupCodeName.Text;
        string Category = this.txtCategory.Text;
        string ERS_Layout = this.txtERS_Layout.Text;
        string PurchaseRequestor = this.txtPurchaseRequestor.Text;
        string STR_PurchaseGroup = this.txtSTR_PurchaseGroup.Text;
        string FirstReviewer = this.txtFirstReviewer.Text;
        string SecondReviewer = this.txtSecondReviewer.Text;
        //string FirstApprover = this.txtFirstApprover.Text;
        //string SecondApprover = this.txtSecondApprover.Text;
        string CopyToACC = this.txtCopyToACC.Text;
        //string CreateBy = this.txtCreateBy.Text;
        //DateTime CreateDate = DateTime.Parse(this.txtCreateDate.Text);
        string EditBy = "LXDZN";
        DateTime EditDate = DateTime.Now;
        //bool FlagDelete = this.chkFlagDelete.Checked;

        LXS.BLL.MD_PurchaseGroup bll = new LXS.BLL.MD_PurchaseGroup();
        LXS.Model.MD_PurchaseGroup model = bll.GetModel(ID);
        model.ID = ID;
        model.PurchaseGroupCode = PurchaseGroupCode;
        model.PurchaseGroupCodeName = PurchaseGroupCodeName;
        model.Category = Category;
        model.ERS_Layout = ERS_Layout;
        model.PurchaseRequestor = PurchaseRequestor;
        model.STR_PurchaseGroup = STR_PurchaseGroup;
        model.FirstReviewer = FirstReviewer;
        model.SecondReviewer = SecondReviewer;
        //model.FirstApprover = FirstApprover;
        //model.SecondApprover = SecondApprover;
        model.CopyToACC = CopyToACC;
        //model.CreateBy = CreateBy;
        //model.CreateDate = CreateDate;
        model.EditBy = EditBy;
        model.EditDate = EditDate;
        //model.FlagDelete = FlagDelete;

        //LXS.BLL.MD_PurchaseGroup bll = new LXS.BLL.MD_PurchaseGroup();
        bll.Update(model);
        MessageBox.ShowAndRedirect(this, "保存成功！", "ListPurchaseGroup.aspx");

    }
}