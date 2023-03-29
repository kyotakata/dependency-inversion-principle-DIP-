using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依存関係逆転の原則.Objects
{
    public static class ModuleB
    {
        public static string GetValue(IProduct product)
        {
            return product.GetData() + "%";
        }
    }
}
