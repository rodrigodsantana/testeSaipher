using App.Interfaces;
using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{

    [RoutePrefix("api/aeronave")]
    public class AeronaveController : BaseController
    {

        readonly IAeronaveApp  _aeronaveApp;

        public AeronaveController(IAeronaveApp aeronaveApp,LNoty notificacoes) : base(notificacoes)
        {
            _aeronaveApp = aeronaveApp;
        }


        [HttpGet]
        [Route("ObterAeronaves")]
        public async Task<HttpResponseMessage> ObterAeronaves()
        {
            try
            {
                var ret = await _aeronaveApp.ObterAeronaves();
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }

        }

    }
}
