using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SqlFactory : AbstractFactoryData
    {

        protected override DbConnection CriarConeccao(string strconn)
        {
            return new SqlConnection(strconn);
        }
    }
}
