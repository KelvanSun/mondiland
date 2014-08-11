using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.UI
{
    public interface IMenuFavorites
    {
        /// <summary>
        /// 返回是否已经收藏
        /// </summary>
        bool Favorites
        {
            get;
        }

        void SetFavorites();
        void UnFavorites();

    }
}
