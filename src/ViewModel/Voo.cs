using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{


    public class VooExcluirViewModel {


        public string Id { get; set; }


    }

    public class VooConsultaViewModel
    {

        public string AeronaveNome { get; set; }

  

        public bool Ativo { get; set; }

    }

    public class VooListaViewModel
    {

        public string VooId { get; set; }

        public string DescricaoVoo { get; set; }

        public string Aeronave { get; set; }

        public string AeronaveId { get; set; }

        public string AeroportoOrigem { get; set; }

        public string AeroportoOrigemId { get; set; }

        public string AeroportoDestino { get; set; }

        public string AeroportoDestinoId { get; set; }

        public DateTime DataAgendamento { get; set; }

        public string TempoPrevisto { get; set; }

        public string   TempoEfetivado { get; set; }

        public string DataVoo { get; set; }

    }

    public class VooAlterarViewModel : VoorViewModel
    {

       
    }

    public class AeronaveViewModel
    {
        public string Id { get; set; }

        public string Matricula { get; set; }

    }

    public class AeroportoViewModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

    }

    public abstract class VoorViewModel
    {

        public string Id { get; set; }

        public string AeroportoDestinoId { get; set; }

        public string AeroportoOrigemId { get; set; }

        public string AeronaveId { get; set; }

        public DateTime DataAgendamento { get; set; }

    }

    public class VooInserirViewModel: VoorViewModel
    {

        
        

    }
}
