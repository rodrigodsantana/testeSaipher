using App.Interfaces;
using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public abstract class AppBase : IAppBase
    {

        protected LNoty _notificacoes = new LNoty();

        protected AppBase(LNoty notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
