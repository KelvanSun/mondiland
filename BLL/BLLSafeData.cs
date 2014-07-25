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
    public class BLLSafeData:BaseBLL
    {
        private ITable_SafeData Dal = null;

        public BLLSafeData()
        {
            Dal = Reflect<ITable_SafeData>.Create("DAL_SafeData", "Mondiland.DAL");
        }

        public BindingList<BESafeDataInfo> GetAllInfo()
        {
            BindingList<BESafeDataInfo> list = new BindingList<BESafeDataInfo>();

            IEnumerator<Table_SafeData_Entity> ator = Dal.GetAll(false).GetEnumerator();

            while (ator.MoveNext())
            {
                BESafeDataInfo info = new BESafeDataInfo();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

                list.Add(info);
            }

            return list;

        }
    }
}
