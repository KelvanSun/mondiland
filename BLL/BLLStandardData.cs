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
    public class BLLStandardData : BaseBLL
    {
        private ITable_StandardData Dal = null;

        public BLLStandardData()
        {
            Dal = Reflect<ITable_StandardData>.Create("DAL_StandardData", "Mondiland.DAL");
        }

        public BindingList<BEStandardDataInfo> GetAllInfo()
        {
            BindingList<BEStandardDataInfo> list = new BindingList<BEStandardDataInfo>();

            IEnumerator<Table_StardardData_Entity> ator = Dal.GetAll(false).GetEnumerator();

            while (ator.MoveNext())
            {
                BEStandardDataInfo info = new BEStandardDataInfo();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

                list.Add(info);
            }

            return list;

        }
    }
}
