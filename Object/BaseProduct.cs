using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Object
{
    /// <summary>
    /// 所有产品的基类
    /// </summary>
    public abstract class BaseProduct
    {
        /// <summary>
        /// 以ID号填充数据
        /// </summary>
        /// <param name="id">ID号</param>
        public abstract void ReadByPrimaryKey(int id);
        /// <summary>
        /// 以货号填充数据
        /// </summary>
        /// <param name="huo_hao">货号</param>
        public abstract void ReadByHuoHao(string huo_hao);
    }
}
