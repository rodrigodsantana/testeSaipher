using CrossCutting;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Data.Repository
{
    public class VooRepository : RepositoyBase<Voo>, IVooRepository
    {
        public VooRepository(IContexto contexto) : base(contexto)
        {



        }

        public new async Task Remover(Guid id)
        {
            using (var _command = _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       UPDATE VOO 
                        SET 
                        Ativo= 0
                       WHERE ID  =@ID  
                ";
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@Id", id));
                 await _contexto.ExecCommandAsync(_command);
            }
        }

        public new async Task<Voo> Atualizar(Voo entity)
        {
            using (var _command = _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       UPDATE VOO 
                        SET 
                        AeroportoDestinoId=@AeroportoDestinoId,
                        AeroportoOrigemId=@AeroportoOrigemId,
                        AeronaveId=@AeronaveId,
                       
                        DataAgendamentoVoo=@DataAgendamentoVoo
                        
                       WHERE ID  =@ID  

                    SELECT SCOPE_IDENTITY();
                        
                ";
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@Id", entity.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeroportoDestinoId", entity.AeroportoDestino.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeroportoOrigemId", entity.AeroportoOrigem.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeronaveId", entity.Aeronave.Id));
              
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@DataAgendamentoVoo", entity.DataAgendamentoVoo));

                var Id = await _contexto.ExecEscalarAsync(_command);

                entity.Id = new Guid(Id.ToString());
            }
            return entity;
        }


        public new async  Task<Voo> Adicionar(Voo entity)
        {
            using (var _command = _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       INSERT INTO Voo(Id,
                                       AeroportoDestinoId,
                                       AeroportoOrigemId,
                                       AeronaveId,
                                       TempoVooPrevisto,
                                       DataAgendamentoVoo,
                                       Ativo) 
                               VALUES (@Id,
                                       @AeroportoDestinoId,
                                       @AeroportoOrigemId,
                                       @AeronaveId,
                                       @TempoVooPrevisto,
                                       @DataAgendamentoVoo,
                                       @Ativo )

                    
                        
                ";
                _command.Parameters.Add(_contexto.ObterParametro(_command,"@Id", entity.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeroportoDestinoId", entity.AeroportoDestino.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeroportoOrigemId", entity.AeroportoOrigem.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@AeronaveId", entity.Aeronave.Id));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@TempoVooPrevisto", entity.TempoVooPrevisto));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@DataAgendamentoVoo", entity.DataAgendamentoVoo));
                _command.Parameters.Add(_contexto.ObterParametro(_command, "@Ativo",true));

                await _contexto.ExecCommandAsync(_command);

                entity.Id = new Guid(entity.Id.ToString());

               
            }
            return entity;
        }

        public new async Task<Voo> ObterPorId(Guid id)
        {
            var aeronave = new Voo();
            using (var _command = _contexto.ObterCommand())
            {

                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       SELECT 
                        AERO.NOME AS AERONOME,
                        AERO.ID AS AEROID,
                        AER.ID AS AERID,
                        AER.MATRICULA AS AERMATRICULA,
                        AERD.NOME AS AERDNOME,
                        AERD.ID AS AERDID, 
                        V.ID AS  VID,
                        V.DataAgendamentoVoo as  VDataAgendamentoVoo ,
						V.TempoVooPrevisto AS VTempoVooPrevisto,
						V.TempoVooEfetivado AS  VTempoVooEfetivado
                        FROM VOO AS V
                        JOIN AEROPORTO AERD
                        ON AERD.ID = V.AeroportoDestinoId
                        JOIN AEROPORTO AERO 
                        ON AERO.ID = V.AeroportoOrigemId
                        JOIN AERONAVE AER
                        ON AER.ID = V.AeronaveId
                        WHERE 1=1 
                       
                ";

                await _contexto.ExecReaderAsync(_command, (datareader) =>
                {

                    if (datareader.HasRows)
                    {

                        while (datareader.Read())
                        {
                            aeronave.Id = new Guid(datareader["VID"].ToString());
                            aeronave.Aeronave = new Aeronave { Id = new Guid(datareader["AERID"].ToString()) };
                            aeronave.AeroportoDestino = new Aeroporto { Id = new Guid(datareader["AERDID"].ToString()) };
                            aeronave.AeroportoOrigem = new Aeroporto { Id = new Guid(datareader["AEROID"].ToString()) };
                            aeronave.DataAgendamentoVoo = datareader["VDataAgendamentoVoo"].ToDataBaseDateTime(DateTime.MinValue);
                            break;
                        }
                    }
                });
            }

            return aeronave;
        }

        public async Task<IEnumerable<VooListaViewModel>> ObterVoos(VooConsultaViewModel vooConsultaViewModel)
        {
            List<VooListaViewModel> listaVoos = new List<VooListaViewModel>();
            using ( var _command =  _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       SELECT 
                        AERO.NOME AS AERONOME,
                        AER.MATRICULA AS AERMATRICULA,
                        AERD.NOME AS AERDNOME,
                        V.ID AS  VID,
                        V.DataAgendamentoVoo as  VDataAgendamentoVoo ,
						V.TempoVooPrevisto AS VTempoVooPrevisto,
						V.TempoVooEfetivado AS  VTempoVooEfetivado
                        FROM VOO AS V
                        JOIN AEROPORTO AERD
                        ON AERD.ID = V.AeroportoDestinoId
                        JOIN AEROPORTO AERO 
                        ON AERO.ID = V.AeroportoOrigemId
                        JOIN AERONAVE AER
                        ON AER.ID = V.AeronaveId
                        WHERE 1=1 

                        AND V.ATIVO = @VATIVO    
                ";
                 var parAtivo =  _command.CreateParameter();
                parAtivo.ParameterName = "@VATIVO";
                parAtivo.Value = vooConsultaViewModel.Ativo.ToDataBaseBoolean(false);
                _command.Parameters.Add(parAtivo);

                if (!string.IsNullOrEmpty(vooConsultaViewModel.AeronaveNome))
                {
                    _command.CommandText += @" AND AER.MATRICULA LIKE  @MATRICULA ";
                    _command.Parameters.Add(_contexto.ObterParametro(_command, "@MATRICULA","%"+vooConsultaViewModel.AeronaveNome+"%"));
                }

               await _contexto.ExecReaderAsync(_command, (datareader) => {

                   if (datareader.HasRows)
                   {

                       while (datareader.Read())
                       {
                           var voo = new VooListaViewModel {

                               VooId = datareader["VID"].ToString(),
                               DescricaoVoo = $"  AERONAVE - {datareader["AERMATRICULA"]} SAIU - {datareader["AERONOME"]} DEST - {datareader["AERDNOME"]} AS {datareader["VDataAgendamentoVoo"]} ",
                               Aeronave = datareader["AERMATRICULA"].ToString(),
                               AeroportoDestino = datareader["AERDNOME"].ToString(),
                               AeroportoOrigem = datareader["AERONOME"].ToString(),
                               TempoPrevisto   = (datareader["VTempoVooPrevisto"] == null || datareader["VTempoVooPrevisto"] ==  DBNull.Value) ? "" :  Convert.ToDateTime(datareader["VTempoVooPrevisto"]).ToString(),
                               TempoEfetivado  = (datareader["VTempoVooEfetivado"] == null || datareader["VTempoVooEfetivado"] == DBNull.Value) ? "" : Convert.ToDateTime(datareader["VTempoVooEfetivado"]).ToString(),
                               DataVoo =         (datareader["VDataAgendamentoVoo"] == null || datareader["VDataAgendamentoVoo"] == DBNull.Value) ? "" : Convert.ToDateTime(datareader["VDataAgendamentoVoo"]).ToString()
                           };
                           listaVoos.Add(voo);
                       }
                   }
                });

            }

            return listaVoos;
        }
    }
}
