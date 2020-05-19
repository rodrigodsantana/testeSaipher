using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IContexto
    {

        Task ExecReaderAsync(DbCommand command, Action<DbDataReader> Event);
        Task ExecCommandAsync(DbCommand command);
        Task<object> ExecEscalarAsync(DbCommand command);

        void ExecReader(DbCommand command, Action<DbDataReader> Event);
        void ExecCommand(DbCommand command);

        object ExecEscalar(DbCommand command);

        DbParameter ObterParametro(DbCommand dbCommand, string nome, object value);

        DbCommand ObterCommand();
    }
}
