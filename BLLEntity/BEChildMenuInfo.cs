using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEChildMenuInfo:BLLEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        private int m_Id = 0;
        /// <summary>
        /// 菜单名称
        /// </summary>
        private string m_Menu_name = string.Empty;
        /// <summary>
        /// 菜单图标名称
        /// </summary>
        private int m_Menu_bmp = 0;
        /// <summary>
        /// 菜单备注
        /// </summary>
        private string m_Menu_memo = string.Empty;
        /// <summary>
        /// 菜单所要打开的窗口名称
        /// </summary>
        private string m_Menu_window = string.Empty;


        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName
        {
            get { return m_Menu_name; }
            set { m_Menu_name = value; }
        }

        /// <summary>
        /// 菜单图标名称
        /// </summary>
        public int MenuBmp
        {
            get { return m_Menu_bmp; }
            set { m_Menu_bmp = value; }
        }

        /// <summary>
        /// 菜单备注
        /// </summary>
        public string MenuMemo
        {
            get { return m_Menu_memo; }
            set { m_Menu_memo = value; }
        }

        /// <summary>
        /// 菜单所要打开的窗口名称
        /// </summary>
        public string MenuWindow
        {
            get { return m_Menu_window; }
            set { m_Menu_window = value; }
        }

    }
}
