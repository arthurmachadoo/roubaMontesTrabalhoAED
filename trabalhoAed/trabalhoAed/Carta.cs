using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoAed
{
    internal class Carta
    {
        private int numero {  get; set; }
        private string naipe {  get; set; }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Naipe
        {
            get { return naipe; }
            set { naipe = value; }
        }

        public Carta(int numero, string naipe)
        {
            this.numero = numero;
            this.naipe = naipe;
        }

    }
}
