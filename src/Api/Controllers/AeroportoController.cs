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

    [RoutePrefix("api/aeroporto")]
    public class AeroportoController : BaseController
    {

        readonly IAeroportoApp _aeroportoApp ;

        public AeroportoController(IAeroportoApp aeroportoApp,LNoty notificacoes) : base(notificacoes)
        {
            _aeroportoApp = aeroportoApp;
        }

        [HttpGet]
        [Route("ObterAeroportos")]
        public async Task<HttpResponseMessage> ObterAeroportos()
        {
            try
            {
                var ret = await _aeroportoApp.ObterAeroportos();
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }

        }

    }
}
