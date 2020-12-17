using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4,new double[] { 100,300,600,400 })]
        [InlineData(2, new double[] { 800,900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado( int valorEsperado, double[] ofertas)
        {

            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();

            leilao.RecebeLance(fulano, 1000);
            var valorObtido = leilao.Lances.Count();

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
