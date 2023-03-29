using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依存関係逆転の原則.Objects
{
    public class ModuleA
    {
        private IProduct _product;

        public ModuleA(IProduct product)
        {
            _product = product;
        }
        public string GetValue()
        {
            //var p = new ProductSqlServer();

            var value = _product.GetData();
            if(value.Length == 5)
            {
                return value;
            }

            return value + "%";
        }

        public int GetAB(int a, int b)
        {
            return a + b;
        }

    }
}
