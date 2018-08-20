using System;
using System.Collections.Generic;
using VerificaPosicaoDomain;
using VerificaPosicaoDomain.Model;

namespace ProjetoVerificaPosicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Distancia distancia = Distancia.Instance;
            List<Ponto> listaDePontos = PegarValoresAmigos();


            Console.WriteLine("");
            Console.WriteLine("Menores Distâncias");
            foreach (Ponto posicao in listaDePontos)
            {
                
                    Console.WriteLine("Para Ponto : [" + posicao.PontoA + "," + posicao.PontoB + "]");
                    foreach (KeyValuePair<Ponto, double> valor in distancia.CalculaDistancias(posicao, listaDePontos))
                    {
                        Console.WriteLine("Ponto : [" + valor.Key.PontoA + "," + valor.Key.PontoB + "] : Valor : " + valor.Value);
                    }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static List<Ponto> PegarValoresAmigos()
        {
            List<Ponto> listaDePontos = new List<Ponto>();
            string[] resultado;
            Console.WriteLine("Digite os valores das posições de seus amigos no formato (x,y). Digite s para parar");
            do
            {

                int pontoA;
                int pontoB;
                resultado = Console.ReadLine().Split(',');
                if (resultado.Length > 1)
                {
                    Int32.TryParse(resultado[0], out pontoA);
                    Int32.TryParse(resultado[1], out pontoB);

                    listaDePontos.Add(new Ponto() { PontoA = pontoA, PontoB = pontoB });
                }
            } while (resultado[0] != "s");

            return listaDePontos;
        }
    }
}
