using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VerificaPosicaoDomain;

namespace ProjetoVerificaPosicao.Test
{
    [TestClass]
    public class UnitTestOperacoes
    {
        Operacoes operacoes = Operacoes.Instance;
        [TestMethod]
        public void TestMethodSoma()
        {
            Assert.AreEqual(10, operacoes.Somar(5, 5));
        }
        [TestMethod]
        public void TestMethodSubtracao()
        {
            Assert.AreEqual(6, operacoes.Subtrair(10, 4));
        }
        [TestMethod]
        public void TestMethodQuadrado()
        {
            Assert.AreEqual(25, operacoes.Quadrado(5));
        }
        [TestMethod]
        public void TestMethodRaiz()
        {
            Assert.AreEqual(9, operacoes.RaizQuadrada(81));
        }
        [TestMethod]
        public void TestMethodSort()
        {
            Dictionary<int, double> listaDistâncias = new Dictionary<int, double>();
            listaDistâncias.Add(0, 20);
            listaDistâncias.Add(1, 10);
            listaDistâncias.Add(2, 15);
            listaDistâncias.Add(3, 9);
            listaDistâncias.Add(4, 12);

            Dictionary<int, double> listaDistânciasEsperadas = new Dictionary<int, double>();
            listaDistânciasEsperadas.Add(0, 9);
            listaDistânciasEsperadas.Add(1, 10);
            listaDistânciasEsperadas.Add(2, 12);
            listaDistânciasEsperadas.Add(3, 15);
            listaDistânciasEsperadas.Add(4, 20);
            

            
            CollectionAssert.AreEqual(listaDistânciasEsperadas, operacoes.Sort(listaDistâncias, 0, 4));
        }
    }
}
