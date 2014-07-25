using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.BLLEntity;

namespace Mondiland.BLL
{
    public class BLLMadePlace:BaseBLL
    {
        private ITable_MadePlace Dal = null;

        public BLLMadePlace()
        {
            Dal = Reflect<ITable_MadePlace>.Create("DAL_MadePlace", "Mondiland.DAL");
        }

        public BindingList<BEMadePlaceInfo> GetAllInfo()
        {
            BindingList<BEMadePlaceInfo> list = new BindingList<BEMadePlaceInfo>();

            IEnumerator<Table_MadePlace_Entity> ator = Dal.GetAll(false).GetEnumerator();

            while (ator.MoveNext())
            {
                BEMadePlaceInfo info = new BEMadePlaceInfo();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

                list.Add(info);
            }

            return list;

        }
    }
}
