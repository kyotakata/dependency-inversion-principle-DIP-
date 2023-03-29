using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依存関係逆転の原則.Objects
{
    public class ProductSqlServer:IProduct
    {
        public string GetData()
        {
            //データベースOpen
            //SQLの実行
            //using (var connection = new SqlConnection("XXXXXXX"))
            //using (var command = new SqlCommand("select * from Product"))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@AreaId", 0);
            //    using (var adapter = new SqlDataAdapter(command))
            //    {
            //    }
            //}


            return "AAA sql server";
        }

        public void Save(string value)
        {
            throw new NotImplementedException();
        }
    }
}
