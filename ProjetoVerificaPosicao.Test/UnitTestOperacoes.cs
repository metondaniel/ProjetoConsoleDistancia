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
            Dictionary<int, double> listaDist�ncias = new Dictionary<int, double>();
            listaDist�ncias.Add(0, 20);
            listaDist�ncias.Add(1, 10);
            listaDist�ncias.Add(2, 15);
            listaDist�ncias.Add(3, 9);
            listaDist�ncias.Add(4, 12);

            Dictionary<int, double> listaDist�nciasEsperadas = new Dictionary<int, double>();
            listaDist�nciasEsperadas.Add(0, 9);
            listaDist�nciasEsperadas.Add(1, 10);
            listaDist�nciasEsperadas.Add(2, 12);
            listaDist�nciasEsperadas.Add(3, 15);
            listaDist�nciasEsperadas.Add(4, 20);
            

            
            CollectionAssert.AreEqual(listaDist�nciasEsperadas, operacoes.Sort(listaDist�ncias, 0, 4));
        }
    }
}
