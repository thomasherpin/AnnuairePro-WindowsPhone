using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnnuairePro.Helper
{
    public static class Extension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> entity)
        {
            var list = new List<T>();
            var oc = new ObservableCollection<T>();

            foreach (var item in entity)
            {
                oc.Add(item);
            }

            return oc;
        }
    }
}
