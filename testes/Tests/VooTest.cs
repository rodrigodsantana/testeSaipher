using CrossCutting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class VooTest
    {


        Dominio.Services.VooService _vooService ;
        Moq.Mock<Dominio.Interfaces.IAeronaveRepository> IAeronaveRepository  =  new Mock<Dominio.Interfaces.IAeronaveRepository>();
        Moq.Mock<Dominio.Interfaces.IAeroportoRepository> IAeroportoRepository = new Mock<Dominio.Interfaces.IAeroportoRepository>();
        Moq.Mock<Dominio.Interfaces.IVooRepository> IVooRepository = new Mock<Dominio.Interfaces.IVooRepository>();
        LNoty notificacoes = new LNoty();


        public VooTest()
        {
            
           _vooService = new Dominio.Services.VooService(null, IAeroportoRepository.Object, IAeronaveRepository.Object, IVooRepository.Object, notificacoes);
        }

        [TestMethod]
        public async Task IncluirVooAeroportoNaoEncontradoAeronaveNaoEncontradoAsync()
        {

            // Arrange
            var vooInserir = new VooInserirViewModel {
                
                AeronaveId = "CDB97C11-6AF6-4D5C-84BE-283AD9A026CF",
                AeroportoDestinoId  = "5A30DF3F-ABED-4378-A0B8-1C35BE3FEA6B",
                AeroportoOrigemId = "26D9D393-857F-4472-8078-5CDFD9E481F1",
                DataAgendamento = DateTime.Now.AddDays(10),
            };
            IAeronaveRepository.Setup(x => x.ObterPorId(It.IsAny<Guid>())).Returns(Task.FromResult(default(Dominio.Aeronave)));
            IAeroportoRepository.Setup(x => x.ObterPorId(It.IsAny<Guid>())).Returns(Task.FromResult(default(Dominio.Aeroporto)));


            // Act
            await _vooService.InserirVoo(vooInserir);



            // Assert
            Assert.IsTrue(notificacoes.Any());

        }


        [TestMethod]
        public async Task IncluirVooAeroportoInativoAeronaveInativoAsync()
        {

            // Arrange
            var vooInserir = new VooInserirViewModel
            {

                AeronaveId = "CDB97C11-6AF6-4D5C-84BE-283AD9A026CF",
                AeroportoDestinoId = "5A30DF3F-ABED-4378-A0B8-1C35BE3FEA6B",
                AeroportoOrigemId = "26D9D393-857F-4472-8078-5CDFD9E481F1",
                DataAgendamento = DateTime.Now.AddDays(10),
            };
            IAeronaveRepository.Setup(x => x.ObterPorId(It.IsAny<Guid>())).Returns(Task.FromResult( new Dominio.Aeronave { Ativo = false }));
            IAeroportoRepository.Setup(x => x.ObterPorId(It.IsAny<Guid>())).Returns(Task.FromResult( new Dominio.Aeroporto { Ativo = false }));


            // Act
            await _vooService.InserirVoo(vooInserir);



            // Assert
            Assert.IsTrue(notificacoes.Any());

        }
    }
}
