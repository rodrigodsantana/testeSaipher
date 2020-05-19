using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MysqlFactory : AbstractFactoryData
    {
        protected override DbConnection CriarConeccao(string strconn)
        {
            return new MySqlConnection(strconn);
        }
    }
}
