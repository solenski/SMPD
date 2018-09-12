using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPD.Extensions
{
    public static class Rozszerzenia
    {
        public static IEnumerable<IEnumerable<T>> PodzielNaGrupyPoN<T>(this IEnumerable<T> lista, int n)
        {
            var i = 0;
            return lista.GroupBy(item => i++ % n).Select(part => part.AsEnumerable());

        }
    }

}
