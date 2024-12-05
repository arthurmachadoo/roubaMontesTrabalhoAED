using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoAed
{
    internal class Jogador
    {
        private string nome;
        private int posicao;
        private int quantidadeCartas;
        private Queue<int> ultimasPosicoes;
        private Stack<Carta> monteDoJogador;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Posicao
        {
            get { return posicao;}
            set { posicao = value; }
        }
        
        public int QuantidadeCartas
        {
            get { return quantidadeCartas; }
            set { quantidadeCartas = value; }
        }

        public Queue<int> UltimasPosicoes
        {
            get { return ultimasPosicoes; }
            set {  ultimasPosicoes = value;}
        }

        public Stack<Carta> MonteDoJogador
        {
            get { return monteDoJogador; }
            set { monteDoJogador = value; }
        }

        public Jogador(string nome)
        {
            this.nome = nome;
            posicao = 0;
            quantidadeCartas = 0;
            ultimasPosicoes = new Queue<int>(5);
            monteDoJogador = new Stack<Carta>();
        }    

        public void roubaOutroJogador(Jogador outroJogador)
        {
            Carta temp = outroJogador.MonteDoJogador.Pop();

            foreach(Carta carta in outroJogador.MonteDoJogador)
            {
                MonteDoJogador.Push(carta);
            }

            Console.WriteLine($"{nome} roubou {outroJogador.Nome}");
        }
    }
}
