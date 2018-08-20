using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VerificaPosicaoDomain;
using VerificaPosicaoDomain.Model;

namespace ProjetoVerificaPosicao.Test
{
    [TestClass]
    public class UnitTestDistancia
    {
        Distancia distancia = Distancia.Instance;
        [TestMethod]
        public void TestCalculaDistancia1()
        {
            Ponto ponto1 = new Ponto();
            ponto1.PontoA = 1;
            ponto1.PontoB = 1;

            Ponto ponto2 = new Ponto();
            ponto2.PontoA = 1;
            ponto2.PontoB = 4;

            Assert.AreEqual(3, distancia.CalculaDistancia(ponto1, ponto2));
        }
        [TestMethod]
        public void TestCalculaDistancia2()
        {
            Ponto ponto1 = new Ponto();
            ponto1.PontoA = 1;
            ponto1.PontoB = 2;

            Ponto ponto2 = new Ponto();
            ponto2.PontoA = 2;
            ponto2.PontoB = 3;

            Assert.AreEqual(1.41421, distancia.CalculaDistancia(ponto1, ponto2), 5);
        }
        [TestMethod]
        public void TestMethodTresMenoresDistancias()
        {
            Dictionary<int, double> listaDistânciasSort = new Dictionary<int, double>();
            listaDistânciasSort.Add(0, 9);
            listaDistânciasSort.Add(1, 10);
            listaDistânciasSort.Add(2, 12);
            listaDistânciasSort.Add(3, 15);
            listaDistânciasSort.Add(4, 20);

            Dictionary<int, double> listaDistâncias = new Dictionary<int, double>();
            listaDistâncias.Add(0, 20);
            listaDistâncias.Add(1, 10);
            listaDistâncias.Add(2, 15);
            listaDistâncias.Add(3, 9);
            listaDistâncias.Add(4, 12);

            Dictionary<int, double> listaDistânciasEsperadas = new Dictionary<int, double>();
            listaDistânciasEsperadas.Add(3, 9);
            listaDistânciasEsperadas.Add(1, 10);
            listaDistânciasEsperadas.Add(4, 12);

            Dictionary<int, double> listaDistância = distancia.TresMenoresDistancias(listaDistânciasSort, listaDistâncias);

            CollectionAssert.AreEqual(listaDistânciasEsperadas, distancia.TresMenoresDistancias(listaDistânciasSort, listaDistâncias));
        }

        [TestMethod]
        public void TestMethodCalculaDistancias()
        {
            List<Ponto> listaPontos = new List<Ponto>();

            Ponto ponto1 = new Ponto();
            ponto1.PontoA = 1;
            ponto1.PontoB = 1;

            Ponto ponto2 = new Ponto();
            ponto2.PontoA = 5;
            ponto2.PontoB = 6;

            Ponto ponto3 = new Ponto();
            ponto3.PontoA = 2;
            ponto3.PontoB = 9;

            Ponto ponto4 = new Ponto();
            ponto4.PontoA = 12;
            ponto4.PontoB = 20;

            Ponto ponto5 = new Ponto();
            ponto5.PontoA = 10;
            ponto5.PontoB = 14;

            listaPontos.Add(ponto1);
            listaPontos.Add(ponto2);
            listaPontos.Add(ponto3);
            listaPontos.Add(ponto4);
            listaPontos.Add(ponto5);

            Ponto pontoOrigem = new Ponto();
            pontoOrigem.PontoA = 6;
            pontoOrigem.PontoB = 4;

            Dictionary<Ponto, double> listPontoEsperada = new Dictionary<Ponto, double>();
            listPontoEsperada.Add(ponto1, 2);
            listPontoEsperada.Add(ponto2, 2.23607);
            listPontoEsperada.Add(ponto5, 4.47214);

            CollectionAssert.AreEqual(listPontoEsperada, distancia.CalculaDistancias(pontoOrigem, listaPontos));
        }
    }
}