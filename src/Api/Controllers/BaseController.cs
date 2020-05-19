using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected LNoty _notificacoes = new LNoty();

        protected BaseController(LNoty notificacoes)
        {
            _notificacoes = notificacoes;
        }

        protected
           HttpResponseMessage ErroPadrao(Exception ex)
        {
            return CustomResponse(new LNoty { new Noty { Mensagem = ex.Message } });
        }

        protected HttpResponseMessage CustomResponse(object valor)
        {
            if (_notificacoes != null && _notificacoes.TemErros
                
                )
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { success = false, value = _notificacoes  });
            return Request.CreateResponse(HttpStatusCode.OK, new { success = true, value = valor ?? new { } });

        }

    }
}
