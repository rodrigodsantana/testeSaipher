using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{

    public enum Criticidade
    {
        Alta = 1,
        Media = 2,
        Baixa = 3
    }

    public enum Camada
    {
        App = 1,
        Dominio = 2,
        Repositorio = 3,
        Outros = 4
    }

    public enum TipoNotificacao
    {
        Alerta = 1,
        Erro = 2,
        Sucesso = 3,
        Informacao = 4

    }

    public enum IntencaoNotificacao
    {

        InconsistenciaDataAgendamentoVoo = 10

    }

    public class LNoty : List<Noty>
    {

        public bool TemErros { get { return this.Any(x => x.TipoNotificacao == TipoNotificacao.Erro); } }

        public bool TemAlertas { get { return this.Any(x => x.TipoNotificacao == TipoNotificacao.Alerta); } }

        public bool TemSucesso { get { return this.Any(x => x.TipoNotificacao == TipoNotificacao.Sucesso); } }

        public bool TemInformacao { get { return this.Any(x => x.TipoNotificacao == TipoNotificacao.Informacao); } }


        public new void AddRange(IEnumerable<Noty> noties)
        {

            if (noties == null || (noties != null && !noties.Any()))
                return;

            List<Noty> notiesAdd = new List<Noty>();
            foreach (var item in noties)
            {
                if (item.IntencaoNotificacao != null)
                {
                    var n = this.FirstOrDefault(x => x.IntencaoNotificacao != null && x.IntencaoNotificacao == item.IntencaoNotificacao);
                    if (n != null)
                    {
                        n = item;
                        continue;
                    }
                }
                notiesAdd.Add(item);
            }
            base.AddRange(notiesAdd);

        }

        public new void Add(Noty noty)
        {
            if (noty == null)
                return;
            if (noty.IntencaoNotificacao != null)
            {
                var n = this.FirstOrDefault(x => x.IntencaoNotificacao != null && x.IntencaoNotificacao == noty.IntencaoNotificacao);
                if (n != null)
                {
                    n = noty;
                }
            }

            base.Add(noty);

        }
    }

    public class Noty
    {

        public Criticidade Criticidade { get; set; }

        public Camada? Camada { get; set; }

        public TipoNotificacao TipoNotificacao { get; set; }

        public string Mensagem { get; set; }

        public IntencaoNotificacao? IntencaoNotificacao { get; set; }

        public List<string> CamposCriticados { get; set; }

        public Noty()
        {
            CamposCriticados = new List<string>();
            TipoNotificacao = TipoNotificacao.Erro;
        }

    }
}
