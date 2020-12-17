using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao

    {
        [Theory]
        [InlineData(1200,new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000,new double[] { 800, 900, 1000, 990 })]
        [InlineData(800,new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado,double[] ofertas)
        {
            //Arranje - definindo cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            

            //Act - método sob test
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");

            leilao.TerminaPregao();
            
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}