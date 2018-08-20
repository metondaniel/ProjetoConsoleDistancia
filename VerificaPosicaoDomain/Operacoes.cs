using System;
using System.Collections.Generic;
using VerificaPosicaoDomain.Model;

namespace VerificaPosicaoDomain
{
    public class Operacoes
    {
        private static readonly Operacoes instance = new Operacoes();
        
        private Operacoes() { }

        public static Operacoes Instance
        {
            get
            {
                return instance;
            }
        }
        
        public double Somar(double a,double b)
        {
            return a + b;
        }
        public double Subtrair(double a, double b)
        {
            return a - b;
        }
        public double Multiplicar(double a, double b)
        {
            return a*b;
        }
        public double RaizQuadrada(double a)
        {
            return Math.Sqrt(a);
        }
        public double Quadrado(double a)
        {
            return Math.Pow(a, 2);
        }
        public Dictionary<int,double> Sort(Dictionary<int,double> vetor, int primeiro, int ultimo)
        {
            double pivo, repositorio;
            int baixo, alto, meio;
            baixo = primeiro;
            alto = ultimo;
            meio = (int)((baixo + alto) / 2);

            pivo = vetor[meio];

            while (baixo <= alto)
            {
                while (vetor[baixo] < pivo)
                    baixo++;
                while (vetor[alto] > pivo)
                    alto--;
                if (baixo < alto)
                {
                    repositorio = vetor[baixo];
                    vetor[baixo++] = vetor[alto];
                    vetor[alto--] = repositorio;
                }
                else
                {
                    if (baixo == alto)
                    {
                        baixo++;
                        alto--;
                    }
                }
            }

            if (alto > primeiro)
                Sort(vetor, primeiro, alto);
            if (baixo < ultimo)
                Sort(vetor, baixo, ultimo);
            return vetor;
        }
    }
}

