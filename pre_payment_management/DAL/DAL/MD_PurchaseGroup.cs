using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LXS.Common;
using LXS.Model;

namespace LXS.DAL
{
    /// <summary>
    /// 数据访问类:MD_PurchaseGroup
    /// </summary>
    public partial class MD_PurchaseGroup
    {
        public MD_PurchaseGroup()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MD_PurchaseGroup");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LXS.Model.MD_PurchaseGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MD_PurchaseGroup(");
            strSql.Append("PurchaseGroupCode,PurchaseGroupCodeName,Category,ERS_Layout,PurchaseRequestor,STR_PurchaseGroup,FirstReviewer,SecondReviewer,FirstApprover,SecondApprover,CopyToACC,CreateBy,CreateDate,EditBy,EditDate,FlagDelete)");
            strSql.Append(" values (");
            strSql.Append("@PurchaseGroupCode,@PurchaseGroupCodeName,@Category,@ERS_Layout,@PurchaseRequestor,@STR_PurchaseGroup,@FirstReviewer,@SecondReviewer,@FirstApprover,@SecondApprover,@CopyToACC,@CreateBy,@CreateDate,@EditBy,@EditDate,@FlagDelete)");
            SqlParameter[] parameters = {
                    new SqlParameter("@PurchaseGroupCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@PurchaseGroupCodeName", SqlDbType.NVarChar,250),
                    new SqlParameter("@Category", SqlDbType.NVarChar,50),
                    new SqlParameter("@ERS_Layout", SqlDbType.NVarChar,250),
                    new SqlParameter("@PurchaseRequestor", SqlDbType.NVarChar,50),
                    new SqlParameter("@STR_PurchaseGroup", SqlDbType.NVarChar,50),
                    new SqlParameter("@FirstReviewer", SqlDbType.NVarChar,50),
                    new SqlParameter("@SecondReviewer", SqlDbType.NVarChar,50),
                    new SqlParameter("@FirstApprover", SqlDbType.NVarChar,50),
                    new SqlParameter("@SecondApprover", SqlDbType.NVarChar,50),
                    new SqlParameter("@CopyToACC", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateBy", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateDate", SqlDbType.SmallDateTime),
                    new SqlParameter("@EditBy", SqlDbType.NVarChar,50),
                    new SqlParameter("@EditDate", SqlDbType.SmallDateTime),
                    new SqlParameter("@FlagDelete", SqlDbType.Bit,1)};

            parameters[0].Value = model.PurchaseGroupCode;
            parameters[1].Value = model.PurchaseGroupCodeName;
            parameters[2].Value = model.Category;
            parameters[3].Value = model.ERS_Layout;
            parameters[4].Value = model.PurchaseRequestor;
            parameters[5].Value = model.STR_PurchaseGroup;
            parameters[6].Value = model.FirstReviewer;
            parameters[7].Value = model.SecondReviewer;
            parameters[8].Value = model.FirstApprover;
            parameters[9].Value = model.SecondApprover;
            parameters[10].Value = model.CopyToACC;
            parameters[11].Value = model.CreateBy;
            parameters[12].Value = model.CreateDate;
            parameters[13].Value = model.EditBy;
            parameters[14].Value = model.EditDate;
            parameters[15].Value = model.FlagDelete;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(LXS.Model.MD_PurchaseGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MD_PurchaseGroup set ");
            strSql.Append("PurchaseGroupCode=@PurchaseGroupCode,");
            strSql.Append("PurchaseGroupCodeName=@PurchaseGroupCodeName,");
            strSql.Append("Category=@Category,");
            strSql.Append("ERS_Layout=@ERS_Layout,");
            strSql.Append("PurchaseRequestor=@PurchaseRequestor,");
            strSql.Append("STR_PurchaseGroup=@STR_PurchaseGroup,");
            strSql.Append("FirstReviewer=@FirstReviewer,");
            strSql.Append("SecondReviewer=@SecondReviewer,");
            strSql.Append("FirstApprover=@FirstApprover,");
            strSql.Append("SecondApprover=@SecondApprover,");
            strSql.Append("CopyToACC=@CopyToACC,");
            strSql.Append("CreateBy=@CreateBy,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("EditBy=@EditBy,");
            strSql.Append("EditDate=@EditDate,");
            strSql.Append("FlagDelete=@FlagDelete");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@PurchaseGroupCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@PurchaseGroupCodeName", SqlDbType.NVarChar,250),
                    new SqlParameter("@Category", SqlDbType.NVarChar,50),
                    new SqlParameter("@ERS_Layout", SqlDbType.NVarChar,250),
                    new SqlParameter("@PurchaseRequestor", SqlDbType.NVarChar,50),
                    new SqlParameter("@STR_PurchaseGroup", SqlDbType.NVarChar,50),
                    new SqlParameter("@FirstReviewer", SqlDbType.NVarChar,50),
                    new SqlParameter("@SecondReviewer", SqlDbType.NVarChar,50),
                    new SqlParameter("@FirstApprover", SqlDbType.NVarChar,50),
                    new SqlParameter("@SecondApprover", SqlDbType.NVarChar,50),
                    new SqlParameter("@CopyToACC", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateBy", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateDate", SqlDbType.SmallDateTime),
                    new SqlParameter("@EditBy", SqlDbType.NVarChar,50),
                    new SqlParameter("@EditDate", SqlDbType.SmallDateTime),
                    new SqlParameter("@FlagDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PurchaseGroupCode;
            parameters[2].Value = model.PurchaseGroupCodeName;
            parameters[3].Value = model.Category;
            parameters[4].Value = model.ERS_Layout;
            parameters[5].Value = model.PurchaseRequestor;
            parameters[6].Value = model.STR_PurchaseGroup;
            parameters[7].Value = model.FirstReviewer;
            parameters[8].Value = model.SecondReviewer;
            parameters[9].Value = model.FirstApprover;
            parameters[10].Value = model.SecondApprover;
            parameters[11].Value = model.CopyToACC;
            parameters[12].Value = model.CreateBy;
            parameters[13].Value = model.CreateDate;
            parameters[14].Value = model.EditBy;
            parameters[15].Value = model.EditDate;
            parameters[16].Value = model.FlagDelete;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MD_PurchaseGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MD_PurchaseGroup ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LXS.Model.MD_PurchaseGroup GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PurchaseGroupCode,PurchaseGroupCodeName,Category,ERS_Layout,PurchaseRequestor,STR_PurchaseGroup,FirstReviewer,SecondReviewer,FirstApprover,SecondApprover,CopyToACC,CreateBy,CreateDate,EditBy,EditDate,FlagDelete from MD_PurchaseGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)            };
            parameters[0].Value = ID;

            LXS.Model.MD_PurchaseGroup model = new LXS.Model.MD_PurchaseGroup();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LXS.Model.MD_PurchaseGroup DataRowToModel(DataRow row)
        {
            LXS.Model.MD_PurchaseGroup model = new LXS.Model.MD_PurchaseGroup();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PurchaseGroupCode"] != null)
                {
                    model.PurchaseGroupCode = row["PurchaseGroupCode"].ToString();
                }
                if (row["PurchaseGroupCodeName"] != null)
                {
                    model.PurchaseGroupCodeName = row["PurchaseGroupCodeName"].ToString();
                }
                if (row["Category"] != null)
                {
                    model.Category = row["Category"].ToString();
                }
                if (row["ERS_Layout"] != null)
                {
                    model.ERS_Layout = row["ERS_Layout"].ToString();
                }
                if (row["PurchaseRequestor"] != null)
                {
                    model.PurchaseRequestor = row["PurchaseRequestor"].ToString();
                }
                if (row["STR_PurchaseGroup"] != null)
                {
                    model.STR_PurchaseGroup = row["STR_PurchaseGroup"].ToString();
                }
                if (row["FirstReviewer"] != null)
                {
                    model.FirstReviewer = row["FirstReviewer"].ToString();
                }
                if (row["SecondReviewer"] != null)
                {
                    model.SecondReviewer = row["SecondReviewer"].ToString();
                }
                if (row["FirstApprover"] != null)
                {
                    model.FirstApprover = row["FirstApprover"].ToString();
                }
                if (row["SecondApprover"] != null)
                {
                    model.SecondApprover = row["SecondApprover"].ToString();
                }
                if (row["CopyToACC"] != null)
                {
                    model.CopyToACC = row["CopyToACC"].ToString();
                }
                if (row["CreateBy"] != null)
                {
                    model.CreateBy = row["CreateBy"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["EditBy"] != null)
                {
                    model.EditBy = row["EditBy"].ToString();
                }
                if (row["EditDate"] != null && row["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(row["EditDate"].ToString());
                }
                if (row["FlagDelete"] != null && row["FlagDelete"].ToString() != "")
                {
                    if ((row["FlagDelete"].ToString() == "1") || (row["FlagDelete"].ToString().ToLower() == "true"))
                    {
                        model.FlagDelete = true;
                    }
                    else
                    {
                        model.FlagDelete = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PurchaseGroupCode,PurchaseGroupCodeName,Category,ERS_Layout,PurchaseRequestor,STR_PurchaseGroup,FirstReviewer,SecondReviewer,FirstApprover,SecondApprover,CopyToACC,CreateBy,CreateDate,EditBy,EditDate,FlagDelete ");
            strSql.Append(" FROM MD_PurchaseGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,PurchaseGroupCode,PurchaseGroupCodeName,Category,ERS_Layout,PurchaseRequestor,STR_PurchaseGroup,FirstReviewer,SecondReviewer,FirstApprover,SecondApprover,CopyToACC,CreateBy,CreateDate,EditBy,EditDate,FlagDelete ");
            strSql.Append(" FROM MD_PurchaseGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM MD_PurchaseGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from MD_PurchaseGroup T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "MD_PurchaseGroup";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

