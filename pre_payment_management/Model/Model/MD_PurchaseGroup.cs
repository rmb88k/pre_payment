
using System;
namespace LXS.Model
{
    /// <summary>
    /// MD_PurchaseGroup:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MD_PurchaseGroup
    {
        public MD_PurchaseGroup()
        { }
        #region Model
        private int _id;
        private string _purchasegroupcode;
        private string _purchasegroupcodename;
        private string _category;
        private string _ers_layout;
        private string _purchaserequestor;
        private string _str_purchasegroup;
        private string _firstreviewer;
        private string _secondreviewer;
        private string _firstapprover;
        private string _secondapprover;
        private string _copytoacc;
        private string _createby;
        private DateTime _createdate;
        private string _editby;
        private DateTime _editdate;
        private bool _flagdelete = false;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PurchaseGroupCode
        {
            set { _purchasegroupcode = value; }
            get { return _purchasegroupcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PurchaseGroupCodeName
        {
            set { _purchasegroupcodename = value; }
            get { return _purchasegroupcodename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ERS_Layout
        {
            set { _ers_layout = value; }
            get { return _ers_layout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PurchaseRequestor
        {
            set { _purchaserequestor = value; }
            get { return _purchaserequestor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STR_PurchaseGroup
        {
            set { _str_purchasegroup = value; }
            get { return _str_purchasegroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstReviewer
        {
            set { _firstreviewer = value; }
            get { return _firstreviewer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondReviewer
        {
            set { _secondreviewer = value; }
            get { return _secondreviewer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstApprover
        {
            set { _firstapprover = value; }
            get { return _firstapprover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondApprover
        {
            set { _secondapprover = value; }
            get { return _secondapprover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CopyToACC
        {
            set { _copytoacc = value; }
            get { return _copytoacc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EditBy
        {
            set { _editby = value; }
            get { return _editby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EditDate
        {
            set { _editdate = value; }
            get { return _editdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FlagDelete
        {
            set { _flagdelete = value; }
            get { return _flagdelete; }
        }
        #endregion Model

    }
}

