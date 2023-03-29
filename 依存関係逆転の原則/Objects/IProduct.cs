using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依存関係逆転の原則.Objects
{
    public interface IProduct
    {
        string GetData();

        void Save(string value);

    }
}
