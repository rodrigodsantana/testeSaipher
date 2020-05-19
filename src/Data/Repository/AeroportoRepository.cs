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
    public class AeroportoRepository : RepositoyBase<Aeroporto>, IAeroportoRepository
    {


        public new async Task<Aeroporto> ObterPorId(Guid id)
        {
            var aeroporto = default(Aeroporto);
            using (var _command = _contexto.ObterCommand())
            {

                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                        SELECT 
                        AER.ID as  AERID, 
                        AER.Nome AS AERNOME,
                        AER.ativo as AERativo, 
                        AER.Endereco AS AEREndereco
                        FROM Aeroporto AER
                        WHERE 1=1    

                        AND AER.ID=@ID
                       
                ";

                _command.Parameters.Add(_contexto.ObterParametro(_command, "@ID", id));

                await _contexto.ExecReaderAsync(_command, (datareader) => {

                    if (datareader.HasRows)
                    {
                        aeroporto = new Aeroporto();
                        while (datareader.Read())
                        {
                            aeroporto.Id = new Guid(datareader["AERID"].ToString());
                            aeroporto.Nome = datareader["AERNOME"].ToString();
                            aeroporto.Endereco = datareader["AEREndereco"].ToString();
                            aeroporto.Ativo = datareader["AERativo"].ToDataBaseBoolean(false);
                        }
                    }
                });
            }

            return aeroporto;
        }

        public async Task<IEnumerable<AeroportoViewModel>> ObterAeroportos()
        {
            List<AeroportoViewModel> listaAeroporto = new List<AeroportoViewModel>();
            using (var _command = _contexto.ObterCommand())
            {
                _command.CommandType = System.Data.CommandType.Text;
                _command.CommandText = $@" 
                                    
                     SELECT  [Id]
                              ,[Nome]
                              ,[Endereco]
                              ,[Ativo]
                          FROM [Saipher].[dbo].[Aeroporto]
                        WHERE 1=1 

                        AND [Ativo] = 1 
                ";



                await _contexto.ExecReaderAsync(_command, (datareader) => {

                    if (datareader.HasRows)
                    {

                        while (datareader.Read())
                        {
                            var voo = new AeroportoViewModel
                            {
                                Nome = datareader["Nome"].ToString(),
                                Id = datareader["Id"].ToString()
                            };
                            listaAeroporto.Add(voo);
                        }
                    }
                });

            }

            return listaAeroporto;
        }

        public AeroportoRepository(IContexto contexto) : base(contexto)
        {




            }
    }
}
