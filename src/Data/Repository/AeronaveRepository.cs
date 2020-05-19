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
    public class AeronaveRepository : RepositoyBase<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(IContexto contexto) : base(contexto)
        {



        }

        public async Task<IEnumerable<AeronaveViewModel>> ObterAeronaves()
        {
            List<AeronaveViewModel> listaAeronaves = new List<AeronaveViewModel>();
            using (var _command = _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                       SELECT  [Id]
                          ,[Matricula]
                          ,[Ativo]
                      FROM [Saipher].[dbo].[Aeronave]
                      
                        WHERE 1=1 

                        AND [Ativo] = 1 
                ";
               

               
                await _contexto.ExecReaderAsync(_command, (datareader) => {

                    if (datareader.HasRows)
                    {

                        while (datareader.Read())
                        {
                            var voo = new AeronaveViewModel
                            {
                                Id = datareader["Id"].ToString(),
                                Matricula = datareader["Matricula"].ToString()
                            };
                            listaAeronaves.Add(voo);
                        }
                    }
                });

            }

            return listaAeronaves;
        }

        public new async Task<Aeronave> ObterPorId(Guid id)
        {
            var aeronave = default(Aeronave);
            using (var _command = _contexto.ObterCommand())
            {

                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                        SELECT 
                        AER.ID as  AERID, 
                        AER.MATRICULA AS AERMATRICULA,
                        AER.ativo as ativo
                        FROM AERONAVE AER
                        
                        WHERE 1=1    

                        AND AER.ID=@ID
                       
                ";

                _command.Parameters.Add(_contexto.ObterParametro(_command, "@ID", id));

                await _contexto.ExecReaderAsync(_command, (datareader) =>
                {

                    if (datareader.HasRows)
                    {
                        aeronave = new Aeronave();
                        while (datareader.Read())
                        {
                            aeronave.Id = new Guid(datareader["AERID"].ToString());
                            aeronave.Matricula = datareader["AERMATRICULA"].ToString();
                            aeronave.Ativo = datareader["ativo"].ToDataBaseBoolean(false);
                        }
                    }
                });
            }

            return aeronave;
        }
    }
}
