using App.Interfaces;
using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ViewModel;

namespace Api.Controllers
{

    [RoutePrefix("api/voo")]

    public class VooController : BaseController
    {

        readonly IVooApp _vooApp;

        public VooController(IVooApp vooApp,LNoty notificacoes) : base(notificacoes)
        {
            _vooApp = vooApp;
        }


        [HttpPost]
        [Route("InserirVoo")]
        public async Task<HttpResponseMessage> InserirVooAsync([FromBody] VooInserirViewModel vooInserirViewModel)
        {
            try
            {
                var ret =  await _vooApp.InserirVoo(vooInserirViewModel);
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }
        
        }

        [HttpDelete]
        [Route("DeletarVoo/{id:guid}")]
        public async Task<HttpResponseMessage> DeletarVoo(Guid id)
        {
            try
            {
                var ret = await _vooApp.ExcluirVoo(id);
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }

        }

        [HttpGet]
        [Route("ObterVoo/{id:guid}")]
        public async Task<HttpResponseMessage> ObterVoo(Guid id)
        {
            try
            {
                var ret = await _vooApp.ObterVoo(id);
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }

        }

        [HttpPost]
        [Route("ObterVoos")]
        public async Task<HttpResponseMessage> ObterVoos([FromBody]VooConsultaViewModel vooConsultaViewModel)
        {
            try
            {
                var ret = await _vooApp.ObterVoos(vooConsultaViewModel);
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }

        }

        [HttpPut]
        [Route("AlterarVoo")]
        public async Task<HttpResponseMessage> AlterarVoo([FromBody] VooAlterarViewModel vooInserirViewModel)
        {
            try
            {
               var ret =  await _vooApp.AlterarVoo(vooInserirViewModel);
                return CustomResponse(ret);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }


        }

    }
}
