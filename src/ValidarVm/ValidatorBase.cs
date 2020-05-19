using CrossCutting;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidarVm
{
    public abstract class ValidadorBase<T> :
                                AbstractValidator<T> where T : class
    {

        protected T ObjValidar { get; private set; }

        public bool Evalido { get; private set; }

        public LNoty notys;

        protected abstract void ValidarDadosFluent();

        protected ValidadorBase(T _ObjValidar)
        {
            notys = new LNoty();
            ObjValidar = _ObjValidar;
            ValidarDadosFluent();
            Evalidos();
        }

        void Evalidos()
        {
            notys = new LNoty();
            var Result = Validate(ObjValidar);

            foreach (var failure in Result.Errors)
                notys.Add(new Noty { Mensagem = failure.ErrorMessage });
               

            
            Evalido = !notys.TemErros;
        }
    }
}
