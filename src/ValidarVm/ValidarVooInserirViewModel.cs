using CrossCutting;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ValidarVm
{
    public class ValidarVooInserirViewModel : ValidadorBase<VooInserirViewModel>
    {

   
        public ValidarVooInserirViewModel(VooInserirViewModel _ObjValidar) 
                        : base(_ObjValidar)
        {


        }

        protected override void ValidarDadosFluent()
        {
            RuleFor(x => x).Must(x => x.AeroportoDestinoId.EGuid()).WithMessage(" Atenção! campo AeroportoDestinoId inválido. ");

            RuleFor(x => x).Must(x => x.AeroportoOrigemId.EGuid()).WithMessage(" Atenção! campo AeroportoOrigemId inválido. ");

            RuleFor(x => x).Must(x => x.AeronaveId.EGuid()).WithMessage(" Atenção! campo AeronaveId inválido. ");

            RuleFor(x => x).Must(x => !(x.DataAgendamento < DateTime.Now)).WithMessage($" Atenção! dataagendamento  inválido. ");

        }
    }
}
