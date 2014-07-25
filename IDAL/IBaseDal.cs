using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using Mondiland.Entity;
using Mondiland.Global;


namespace Mondiland.IDal
{
    public interface IBaseDal<T> where T : BaseEntity
    {
        #region 通用查询接口
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="obj">记录对象</param>
        /// <returns></returns>
        bool Insert(T obj);
        /// <summary>
        /// 根据主键更新表
        /// </summary>
        /// <param name="id">主键记录</param>
        /// <param name="recordField">更新的字段</param>
        /// <returns>成功返回true</returns>
        bool Update(string id, Hashtable recordField);
        /// <summary>
        /// 根据主键更新表
        /// </summary>
        /// <param name="id">主键记录</param>
        /// <param name="recordField">更新的字段</param>
        /// <returns>成功返回true</returns>
        bool Update(int id, Hashtable recordField);
        /// <summary>
        /// 设置排序方式
        /// </summary>
        /// <param name="type">true为升序</param>
        void SetSortType(OrderType type);
        /// <summary>
        /// 通用条件更新表
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        bool Update(string sql, SqlParameter[] param);
        /// <summary>
        /// 根据条件更新表
        /// </summary>
        /// <param name="recordField">要更新的字段列表</param>
        /// <param name="recordWhere">条件字段列表</param>
        bool Update(Hashtable recordField, Hashtable recordWhere);
        /// <summary>
        /// 查询数据库,返回单条记录
        /// </summary>
        /// <param name="recordTable">条件</param>
        /// <returns></returns>
        T Find(Hashtable recordTable);
        /// <summary>
        /// 查询数据库,检查是否存在指定键值的对象
        /// </summary>
        /// <param name="recordTable">Hashtable:键[key]为字段名;值[value]为字段对应的值</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        bool IsExistKey(Hashtable recordTable);

        bool Delete(Hashtable recordTable);
        /// <summary>
        /// 查询数据库，返回记录的主键
        /// </summary>
        /// <param name="recordTable">查询条件</param>
        /// <returns>>0成功返回</returns>
        int FindPrimaryKey(Hashtable recordTable);
        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于字符型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        T FindByID(string key);
        /// <summary>
        /// 查询数据库,检查是否存在指定ID的对象(用于整型主键)
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        T FindByID(int key);


        #endregion

        #region 通用查询接口(返回集合）

        /// <summary>
        /// 返回数据库所有的对象集合
        /// </summary>
        /// <param name="isSort">是否排序</param>
        /// <returns>指定对象的集合</returns>
        List<T> GetAll(bool isSort);

        /// <summary>
        /// 以字符串的方式返回对象的指定列
        /// </summary>
        /// <param name="Fields">列名</param>
        /// <returns>字符串类型的列的集合</returns>
        List<string> GetItemString(string Fields, bool isSort);

        /// <summary>
        /// 通用获取集合对象方法
        /// </summary>
        /// <param name="sql">查询的Sql语句</param>
        /// <param name="param">参数列表</param>
        /// <returns>符合条件的记录集</returns>
        List<T> GetList(string sql, SqlParameter[] param);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="recordTable">查询的条件</param>
        /// <param name="isSort">是否排序</param>
        /// <param name="op">操作方式</param>
        /// <returns>指定对象的集合</returns>
        List<T> Find(Hashtable recordTable, SqlOperator op, bool isSort);

        #endregion
    }
}
