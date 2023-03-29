using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依存関係逆転の原則.Objects
{
    public sealed class ProductFake : IProduct
    {
        public string GetData()
        {
            return "XXX fake";
        }

        public void Save(string value)
        {
            throw new NotImplementedException();
        }
    }
}
