using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public enum EstadoEntidade
    {
        Inclusao = 1,
        Alteracao = 2,
        Delecao = 3
    }

    public abstract class EntidadeBase
    {

        protected EntidadeBase()
        {
            Ativo = true;
            Id = Guid.NewGuid();
            EstadoEntidade = EstadoEntidade.Inclusao;
        }

        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
        public DateTime? DataDelecao { get; set; }
        public Guid? IdUsuarioDelecao { get; set; }

        public EstadoEntidade EstadoEntidade { get; set; }

        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntidadeBase;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntidadeBase a, EntidadeBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntidadeBase a, EntidadeBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
