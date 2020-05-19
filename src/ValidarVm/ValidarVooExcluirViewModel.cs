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
    public class ValidarVooExcluirViewModel : ValidadorBase<VooExcluirViewModel>
    {
        public ValidarVooExcluirViewModel(VooExcluirViewModel _ObjValidar) : base(_ObjValidar)
        {
        }

        protected override void ValidarDadosFluent()
        {
            RuleFor(x => x).Must(x => x.Id.EGuid()).WithMessage(" Atenção! campo Id inválido. ");
        }
    }
}
