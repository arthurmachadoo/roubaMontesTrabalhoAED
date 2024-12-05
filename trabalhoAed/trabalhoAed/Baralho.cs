using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trabalhoAed
{
    internal class Baralho
    {
        private Stack<Carta> baralho;


        public Stack<Carta> GetBaralho
        {
            get { return baralho; }
            set { baralho = value; }
        }


        public Baralho()
        {
            baralho = new Stack<Carta>();
        }
        public List<Carta> BaralhoEmbaralhado()
        {
            string[] naipes = ["espadas", "copas", "paus", "ouros"];
            List<Carta> baralho = new List<Carta>();

            foreach (string naipe in naipes)
            {
                for (int i = 1; i <= 13; i++)
                {
                    baralho.Add(new Carta(i, naipe));
                }
            }

            return Embaralhar(baralho);
        }

        public List<Carta> Embaralhar(List<Carta> baralho)
        {
            Random random = new Random();

            for (int i = baralho.Count - 1; i >= 0; i--)
            {
                int j = random.Next(0, i + 1);

                Carta temp = baralho[j];
                baralho[j] = baralho[i];
                baralho[i] = temp;
            }
            return baralho;
        }

        public void ImprimeBaralho()
        {
            foreach (Carta c in baralho)
            {
                Console.WriteLine($"{c.Numero} de {c.Naipe}");
            }
        }

        public Stack<Carta> BaralhoInicial(int tamanhoBaralho)
        {
                for (int i = 0; i < tamanhoBaralho; i++)
                {
                    baralho.Push(BaralhoEmbaralhado().First());
                }

            return baralho;
        }
    }
}
