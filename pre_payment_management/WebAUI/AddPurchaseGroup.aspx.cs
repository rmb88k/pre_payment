using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LXS.Common;

public partial class AddPurchaseGroupCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btInsert_Click(object sender, EventArgs e)
    {
        string strErr = "";

        if (this.txtPurchaseGroupCode.Text.Trim().Length == 0)
        {
            strErr += "PurchaseGroupCode不能为空！\\n";
        }
        if (this.txtPurchaseGroupCodeName.Text.Trim().Length == 0)
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
        }
        if (this.txtFirstReviewer.Text.Trim().Length == 0)
        {
            strErr += "FirstReviewer不能为空！\\n";
        }
        if (this.txtSecondReviewer.Text.Trim().Length == 0)
        {
            strErr += "SecondReviewer不能为空！\\n";
        }
        if (this.txtFirstApprover.Text.Trim().Length == 0)
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
      

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }

        string PurchaseGroupCode = this.txtPurchaseGroupCode.Text;
        string PurchaseGroupCodeName = this.txtPurchaseGroupCodeName.Text;
        string Category = this.txtCategory.Text;
        string ERS_Layout = this.txtERS_Layout.Text;
        string PurchaseRequestor = this.txtPurchaseRequestor.Text;
        string STR_PurchaseGroup = this.txtSTR_PurchaseGroup.Text;
        string FirstReviewer = this.txtFirstReviewer.Text;
        string SecondReviewer = this.txtSecondReviewer.Text;
        string FirstApprover = this.txtFirstApprover.Text;
        string SecondApprover = this.txtSecondApprover.Text;
        string CopyToACC = this.txtCopyToACC.Text;
        string CreateBy = "lxdzn";
        DateTime CreateDate = DateTime.Now;
        DateTime EditDate = DateTime.Now;
        bool FlagDelete = false;

        LXS.Model.MD_PurchaseGroup model = new LXS.Model.MD_PurchaseGroup();

        model.PurchaseGroupCode = PurchaseGroupCode;
        model.PurchaseGroupCodeName = PurchaseGroupCodeName;
        model.Category = Category;
        model.ERS_Layout = ERS_Layout;
        model.PurchaseRequestor = PurchaseRequestor;
        model.STR_PurchaseGroup = STR_PurchaseGroup;
        model.FirstReviewer = FirstReviewer;
        model.SecondReviewer = SecondReviewer;
        model.FirstApprover = FirstApprover;
        model.SecondApprover = SecondApprover;
        model.CopyToACC = CopyToACC;
        model.CreateBy = CreateBy;
        model.CreateDate = CreateDate;
        model.EditDate = EditDate;
        model.FlagDelete = FlagDelete;

        LXS.BLL.MD_PurchaseGroup bll = new LXS.BLL.MD_PurchaseGroup();
        bll.Add(model);
        MessageBox.ShowAndRedirect(this, "保存成功！", "ListPurchaseGroup.aspx");
    }
}