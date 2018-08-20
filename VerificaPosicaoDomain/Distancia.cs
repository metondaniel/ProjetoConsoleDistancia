using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerificaPosicaoDomain.Model;

namespace VerificaPosicaoDomain
{
    public class Distancia
    {
        private static readonly Distancia instance = new Distancia();

        private Distancia() { }

        public static Distancia Instance
        {
            get
            {
                return instance;
            }
        }
        Operacoes operacoes = Operacoes.Instance;

        public double CalculaDistancia(Ponto ponto1,Ponto ponto2)
        {
            double distancia1 = operacoes.Subtrair(ponto1.PontoA, ponto1.PontoB);
            double distancia2 = operacoes.Subtrair(ponto2.PontoA, ponto2.PontoB);

            double quadradoistancia1 = QuadradoDistancia(distancia1);
            double quadradoistancia2 = QuadradoDistancia(distancia2);

            return Math.Round(operacoes.RaizQuadrada(operacoes.Somar(quadradoistancia1, quadradoistancia2)),5);
        }

        public Dictionary<Ponto,double> CalculaDistancias(Ponto pontoOrigem, List<Ponto> listaPontos)
        {
            Dictionary<Ponto, double> menoresDistancias = new Dictionary<Ponto, double>();
            Dictionary<int, double> distanciasOriginais = new Dictionary<int, double>();
            Dictionary<int,double> distancias = new Dictionary<int,double>();
            int count = 0;
            for(int i = 0; i < listaPontos.Count; i++)
            {
                if (listaPontos[i] != pontoOrigem)
                {
                    distancias.Add(count, CalculaDistancia(pontoOrigem, listaPontos[i]));
                    distanciasOriginais.Add(i, CalculaDistancia(pontoOrigem, listaPontos[i]));
                    count++;
                }
            }

            foreach(KeyValuePair<int,double> i in TresMenoresDistancias((operacoes.Sort(distancias,distancias.FirstOrDefault().Key,distancias.Count-1)), distanciasOriginais))
            {
                menoresDistancias.Add(listaPontos[i.Key],i.Value);
            }
            return menoresDistancias;
        }

        public Dictionary<int, double> TresMenoresDistancias(Dictionary<int,double> sort, Dictionary<int, double> distancias)
        {
            Dictionary<int,double> keys = new Dictionary<int,double>();
            foreach (KeyValuePair<int, double> valor in sort)
            {
                var key = distancias.Where(pair => pair.Value == valor.Value)
                    .Select(pair => pair.Key)
                    .FirstOrDefault();
                keys.Add(key,valor.Value);
                if (keys.Count == 3)
                    break;
            }
            return keys;
        }

        public double QuadradoDistancia(double distancia)
        {
            return operacoes.Quadrado(distancia);
        }
    }
}
