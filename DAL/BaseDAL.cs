using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.Global;

namespace Mondiland.DAL
{
    public abstract class BaseDal<T> : IBaseDal<T> where T : BaseEntity, new()
    {
        #region 构造函数

        protected string tableName;//需要初始化的对象表名
        protected string primaryKey = string.Empty;//数据库的主键字段名
        protected string sortField = string.Empty;//排序字段

        protected string selectedFields = " * ";//选择的字段，默认为所有(*)
        //protected bool isDescending = true;       //排序方式
        protected OrderType order = OrderType.ASC;


        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            set
            {
                sortField = value;
            }
        }

        /// <summary>
        /// 选择的字段，默认为所有(*)
        /// </summary>
        protected string SelectedFields
        {
            get { return selectedFields; }
            set { selectedFields = value; }
        }

        /// <summary>
        /// 是否为降序
        /// </summary>
        protected OrderType Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// 数据库访问对象的表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }
        }

        /// <summary>
        /// 数据库访问对象的外键约束
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                return primaryKey;
            }
        }

        public BaseDal()
        { }

        /// <summary>
        /// 指定表名以及主键,对基类进构造
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">表主键</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="isDescending">排序方式</param>
        public BaseDal(string tableName, string primaryKey, string sortField, OrderType type)
        {
            this.tableName = tableName;
            this.primaryKey = primaryKey;
            this.sortField = sortField;
            this.order = type;
        }



        #endregion



        #region 字类必须实现的函数

        /// <summary>
        /// 设置排序方式
        /// </summary>
        /// <param name="type">false为升序</param>
        public void SetSortType(OrderType type)
        {
            order = type;
        }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected virtual T DataReaderToEntity(IDataReader dr)
        {
            T obj = new T();
            PropertyInfo[] pis = obj.GetType().GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                try
                {
                    if (!String.IsNullOrEmpty(dr[pi.Name].ToString()))
                    {
                        pi.SetValue(obj, dr[pi.Name] ?? "", null);
                    }
                }
                catch { }
            }
            return obj;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected virtual Hashtable GetHashByEntity(T obj)
        {
            Hashtable ht = new Hashtable();
            PropertyInfo[] pis = obj.GetType().GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                //if (pis[i].Name != PrimaryKey)
                {
                    object objValue = pis[i].GetValue(obj, null);
                    objValue = (objValue == null) ? DBNull.Value : objValue;

                    if (!ht.ContainsKey(pis[i].Name))
                    {
                        ht.Add(pis[i].Name, objValue);
                    }
                }
            }
            return ht;
        }

        #endregion


        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="recordField">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
        /// <returns>成功返回TRUE</returns>
        public bool Insert(Hashtable recordField)
        {
            int result = 0;
            string fields = ""; // 字段名
            string vals = ""; // 字段值
            if (recordField == null || recordField.Count < 1)
            {
                return false;
            }

            SqlParameter[] param = null;

            if (string.IsNullOrEmpty(primaryKey))
                param = new SqlParameter[recordField.Count];
            else
                param = new SqlParameter[recordField.Count - 1];

            IEnumerator eKeys = recordField.Keys.GetEnumerator();

            int i = 0;
            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();
                if (field == primaryKey)
                    continue;
                fields += string.Format("[{0}],", field);//加[]为了去除别名引起的错误
                vals += string.Format("@{0},", field);
                object val = recordField[eKeys.Current.ToString()];
                val = val ?? DBNull.Value;
                if (val is DateTime)
                {
                    if (Convert.ToDateTime(val) <= Convert.ToDateTime("1753-1-1"))
                    {
                        val = DBNull.Value;
                    }
                }
                param[i] = new SqlParameter("@" + field, val);

                i++;
            }

            fields = fields.Trim(',');//除去前后的逗号
            vals = vals.Trim(',');//除去前后的逗号
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, fields, vals);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;

            if (param != null)
            {
                sqlcomm.Parameters.AddRange(param);
            }

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;

                result = sqlcomm.ExecuteNonQuery();

                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return result > 0;
        }

        #region IBaseDal接口实现
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="obj">记录对象</param>
        /// <returns></returns>
        public bool Insert(T obj)
        {
            Hashtable hash = GetHashByEntity(obj);
            return Insert(hash);
        }
        /// <summary>
        /// 通用条件更新表
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public bool Update(string sql, SqlParameter[] param)
        {
            int result = 0;

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;

            if (param != null)
            {
                sqlcomm.Parameters.AddRange(param);
            }

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;

                result = sqlcomm.ExecuteNonQuery();

                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return result > 0;
        }

        /// <summary>
        /// 根据主键更新表
        /// </summary>
        /// <param name="id">主键记录</param>
        /// <param name="recordField">更新的字段</param>
        /// <returns>成功返回true</returns>
        public bool Update(string id, Hashtable recordField)
        {
            return Update(id.ToString(), recordField);
        }

        /// <summary>
        /// 根据主键更新表
        /// </summary>
        /// <param name="id">主键记录</param>
        /// <param name="recordField">更新的字段</param>
        /// <returns>成功返回true</returns>
        public bool Update(int id, Hashtable recordField)
        {
            string field = ""; // 字段名
            object val = null; // 值
            StringBuilder setValue = new StringBuilder(null); // 更新Set () 中的语句
            string where = string.Empty;
            string sql = string.Empty;

            if (recordField == null || recordField.Count < 1)
            {
                return false;
            }

            SqlParameter[] param = new SqlParameter[recordField.Count + 1];
            int i = 0;

            IEnumerator eKeysValue = recordField.Keys.GetEnumerator();
            while (eKeysValue.MoveNext())
            {
                field = eKeysValue.Current.ToString();
                val = recordField[eKeysValue.Current.ToString()];
                val = val ?? DBNull.Value;
                if (val is DateTime)
                {
                    if (Convert.ToDateTime(val) <= Convert.ToDateTime("1753-1-1"))
                    {
                        val = DBNull.Value;
                    }
                }

                setValue.Append(string.Format("[{0}] = @{0},", field));//加[ ]用来避免关键字错误
                param[i] = new SqlParameter(string.Format("@{0}", field), val);

                i++;
            }

            where = " id = @id ";

            param[i] = new SqlParameter("@id", id);

            sql = string.Format("UPDATE {0} SET {1} WHERE {2} ", tableName, setValue.ToString().Substring(0, setValue.Length - 1), where);

            return Update(sql, param);
        }

        /// <summary>
        /// 根据条件更新表
        /// </summary>
        /// <param name="recordField"></param>
        /// <param name="recordWhere"></param>
        public bool Update(Hashtable recordField, Hashtable recordWhere)
        {
            string field = ""; // 字段名
            object val = null; // 值
            StringBuilder setValue = new StringBuilder(null); // 更新Set () 中的语句
            StringBuilder setWhere = new StringBuilder(null);
            string where = string.Empty;
            string sql = string.Empty;

            if (recordField == null || recordField.Count < 1)
            {
                return false;
            }

            SqlParameter[] param = new SqlParameter[recordField.Count + recordWhere.Count];
            int i = 0;

            IEnumerator eKeysValue = recordField.Keys.GetEnumerator();
            while (eKeysValue.MoveNext())
            {
                field = eKeysValue.Current.ToString();
                val = recordField[eKeysValue.Current.ToString()];
                val = val ?? DBNull.Value;
                if (val is DateTime)
                {
                    if (Convert.ToDateTime(val) <= Convert.ToDateTime("1753-1-1"))
                    {
                        val = DBNull.Value;
                    }
                }

                setValue.Append(string.Format("[{0}] = @{0},", field));//加[ ]用来避免关键字错误
                param[i] = new SqlParameter(string.Format("@{0}", field), val);

                i++;
            }

            IEnumerator eKeysWhere = recordWhere.Keys.GetEnumerator();

            while (eKeysWhere.MoveNext())
            {
                string whereField = eKeysWhere.Current.ToString();
                setWhere.Append(string.Format(" {0} = @{1} and", whereField, whereField));

                string whereVal = recordWhere[eKeysWhere.Current.ToString()].ToString();
                param[i] = new SqlParameter(string.Format("@{0}", whereField), whereVal);


                i++;
            }

            where = setWhere.ToString().Substring(0, setWhere.Length - 3);

            sql = string.Format("UPDATE {0} SET {1} WHERE {2} ", tableName, setValue.ToString().Substring(0, setValue.Length - 1), where);

            return Update(sql, param);

        }



        /// <summary>
        /// 查询数据库,返回单条记录
        /// </summary>
        /// <param name="recordTable">条件</param>
        /// <returns></returns>
        public T Find(Hashtable recordTable)
        {
            T entity = null;

            SqlParameter[] param = new SqlParameter[recordTable.Count];
            IEnumerator eKeys = recordTable.Keys.GetEnumerator();

            StringBuilder tmp_where = new StringBuilder(null);
            string where = string.Empty;
            string sql = string.Empty;

            int index = 0;

            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();
                tmp_where.Append(string.Format(" {0} = @{1} and", field, field));
                string val = recordTable[eKeys.Current.ToString()].ToString();
                param[index] = new SqlParameter(string.Format("@{0}", field), val);

                index++;

            }

            where = tmp_where.ToString().Substring(0, tmp_where.Length - 3);

            sql = string.Format("select {0} from {1} where {2} ", selectedFields, tableName, where);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;

            if (param != null)
            {
                sqlcomm.Parameters.AddRange(param);
            }

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                IDataReader dr = sqlcomm.ExecuteReader();

                while (dr.Read())
                {
                    entity = this.DataReaderToEntity(dr);
                }

                dr.Close();
                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }



            return entity;
        }



        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于整型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        public T FindByID(int key)
        {
            return FindByID(key.ToString());
        }

        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        public T FindByID(string key)
        {
            T entity = null;

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            string sql = string.Format("Select {0} From {1} Where ({2} = @ID)", selectedFields, tableName, primaryKey);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;
            sqlcomm.Parameters.AddWithValue("@ID", key);

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                IDataReader dr = sqlcomm.ExecuteReader();

                while (dr.Read())
                {
                    entity = this.DataReaderToEntity(dr);
                }

                dr.Close();
                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return entity;
        }

        /// <summary>
        /// 查询数据库，返回记录的主键
        /// </summary>
        /// <param name="recordTable">查询条件</param>
        /// <returns>>0成功返回</returns>
        public int FindPrimaryKey(Hashtable recordTable)
        {
            if (String.IsNullOrEmpty(this.primaryKey)) return 0;

            SqlParameter[] param = new SqlParameter[recordTable.Count];
            IEnumerator eKeys = recordTable.Keys.GetEnumerator();

            StringBuilder tmp_where = new StringBuilder(null);

            string where = string.Empty;

            int index = 0;
            int result = 0;

            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();
                tmp_where.Append(string.Format(" {0} = @{1} and", field, field));

                string val = recordTable[eKeys.Current.ToString()].ToString();
                param[index] = new SqlParameter(string.Format("@{0}", field), val);

                index++;

            }

            where = tmp_where.ToString().Substring(0, tmp_where.Length - 3);

            string sql = string.Format("select {0} from {1} where {2}", PrimaryKey, tableName, where);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;
            sqlcomm.Parameters.AddRange(param);

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                result = Convert.ToInt32(sqlcomm.ExecuteScalar());

                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return result;

        }


        public bool Delete(Hashtable recordTable)
        {
            SqlParameter[] param = new SqlParameter[recordTable.Count];
            IEnumerator eKeys = recordTable.Keys.GetEnumerator();

            StringBuilder tmp_where = new StringBuilder(null);
            string where = string.Empty;

            int index = 0;
            int result = 0;

            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();
                tmp_where.Append(string.Format(" {0} = @{1} and", field, field));

                string val = recordTable[eKeys.Current.ToString()].ToString();
                param[index] = new SqlParameter(string.Format("@{0}", field), val);

                index++;

            }

            where = tmp_where.ToString().Substring(0, tmp_where.Length - 3);

            string sql = string.Format("delete from {0} where {1}", tableName, where);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;
            sqlcomm.Parameters.AddRange(param);

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                result = Convert.ToInt32(sqlcomm.ExecuteScalar());

                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return result >= 0;
        }
        /// <summary>
        /// 查询数据库,检查是否存在指定键值的对象
        /// </summary>
        /// <param name="recordTable">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool IsExistKey(Hashtable recordTable)
        {
            SqlParameter[] param = new SqlParameter[recordTable.Count];
            IEnumerator eKeys = recordTable.Keys.GetEnumerator();

            StringBuilder tmp_where = new StringBuilder(null);
            string where = string.Empty;

            int index = 0;
            int result = 0;

            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();
                tmp_where.Append(string.Format(" {0} = @{1} and", field, field));

                string val = recordTable[eKeys.Current.ToString()].ToString();
                param[index] = new SqlParameter(string.Format("@{0}", field), val);

                index++;

            }

            where = tmp_where.ToString().Substring(0, tmp_where.Length - 3);

            string sql = string.Format("select count(*) from {0} where {1}", tableName, where);

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;
            sqlcomm.Parameters.AddRange(param);

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                result = Convert.ToInt32(sqlcomm.ExecuteScalar());

                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return result > 0;

        }

        #endregion

        #region IBaseDal接口实现(返回集合)

        /// <summary>
        /// 以字符串的方式返回对象的指定列
        /// </summary>
        /// <param name="Fields">列名</param>
        /// <returns>字符串类型的列的集合</returns>
        public virtual List<string> GetItemString(string Fields, bool isSort)
        {
            List<string> list = new List<string>();

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            
            if(isSort)
            {
                if(!String.IsNullOrEmpty(sortField))
                {
                    if(order == OrderType.ASC)
                        sqlcomm.CommandText = string.Format("select {0} from {1} order by {2} {3}", Fields, tableName, sortField, "ASC");
                    else
                        sqlcomm.CommandText = string.Format("select {0} from {1} order by {2} {3}", Fields, tableName, sortField, "DESC");
                }
            }
            else
            {
                sqlcomm.CommandText = string.Format("select {0} from {1}", Fields, tableName);
            }
            
 
            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                IDataReader dr = sqlcomm.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(dr[0].ToString());
                }

                dr.Close();
                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }


            return list;
        }

        /// <summary>
        /// 返回数据库所有的对象集合
        /// </summary>
        /// <param name="isSort">是否排序</param>
        /// <returns>指定对象的集合</returns>
        public List<T> GetAll(bool isSort)
        {
            string sql = string.Empty;

            if (isSort)
            {
                if (!String.IsNullOrEmpty(sortField))
                {
                    if(order == OrderType.ASC)
                        sql = string.Format("select {0} from {1} order by {2} {3}", selectedFields, tableName, sortField, "ASC");
                    else
                        sql = string.Format("select {0} from {1} order by {2} {3}", selectedFields, tableName, sortField, "DESC");
                }
            }
            else
            {
                sql = string.Format("select {0} from {1}", selectedFields, tableName);
            }


            return GetList(sql, null);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="recordTable">查询的条件</param>
        /// <param name="isSort">是否排序</param>
        /// <param name="op">操作方式</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> Find(Hashtable recordTable, SqlOperator op, bool isSort)
        {
            SqlParameter[] param = new SqlParameter[recordTable.Count];
            IEnumerator eKeys = recordTable.Keys.GetEnumerator();

            StringBuilder tmp_where = new StringBuilder(null);
            string where = string.Empty;
            string order = string.Empty;
            string sql = string.Empty;

            int index = 0;

            while (eKeys.MoveNext())
            {
                string field = eKeys.Current.ToString();

                if (op == SqlOperator.And)
                {
                    tmp_where.Append(string.Format(" {0} = @{1} and", field, field));
                }
                else if (op == SqlOperator.Like)
                {
                    tmp_where.Append(string.Format(" {0} like '%'+@{1}+'%' and", field, field));
                }

                string val = recordTable[eKeys.Current.ToString()].ToString();
                param[index] = new SqlParameter(string.Format("@{0}", field), val);

                index++;

            }

            where = tmp_where.ToString().Substring(0, tmp_where.Length - 3);

            if (isSort)
            {
                if (!string.IsNullOrEmpty(sortField))
                {
                    if(this.order == OrderType.ASC)
                        order = string.Format(" order by {0} {1}", sortField,"ASC");
                    else
                        order = string.Format(" order by {0} {1}",sortField, "DESC");
                }
            }

            sql = string.Format("select {0} from {1} where {2} {3}", selectedFields, tableName, where, order);

            return GetList(sql, param);

        }

        /// <summary>
        /// 通用获取集合对象方法
        /// </summary>
        /// <param name="sql">查询的Sql语句</param>
        /// <param name="param">参数列表</param>
        /// <returns>符合条件的记录集</returns>
        public List<T> GetList(string sql, SqlParameter[] param)
        {
            List<T> list = new List<T>();

            SqlConnection sqlconn = new SqlConnection(AppConfig.BuildConnectionString);
            SqlCommand sqlcomm = sqlconn.CreateCommand();
            SqlTransaction sqltran = null;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.CommandText = sql;

            if (param != null)
            {
                sqlcomm.Parameters.AddRange(param);
            }

            try
            {
                sqlconn.Open();
                sqltran = sqlconn.BeginTransaction();
                sqlcomm.Transaction = sqltran;
                IDataReader dr = sqlcomm.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(this.DataReaderToEntity(dr));
                }

                dr.Close();
                sqltran.Commit();
            }
            catch (SqlException ex)
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqltran.Rollback();

                MessageUtil.ShowError(ex.Message);

            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return list;
        }


        #endregion
    }
}
