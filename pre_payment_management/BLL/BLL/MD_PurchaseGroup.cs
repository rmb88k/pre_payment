using System;
using System.Data;
using System.Collections.Generic;
using LXS.Model;

namespace LXS.BLL
{
    /// <summary>
    /// MD_PurchaseGroup
    /// </summary>
    public partial class MD_PurchaseGroup
    {
        private readonly LXS.DAL.MD_PurchaseGroup dal = new LXS.DAL.MD_PurchaseGroup();
        public MD_PurchaseGroup()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LXS.Model.MD_PurchaseGroup model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(LXS.Model.MD_PurchaseGroup model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LXS.Model.MD_PurchaseGroup GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LXS.Model.MD_PurchaseGroup> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LXS.Model.MD_PurchaseGroup> DataTableToList(DataTable dt)
        {
            List<LXS.Model.MD_PurchaseGroup> modelList = new List<LXS.Model.MD_PurchaseGroup>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LXS.Model.MD_PurchaseGroup model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetListV(string strwhere) {
            DataSet ds = new DataSet();
            return ds;
        }
        #endregion  ExtensionMethod
    }
}

