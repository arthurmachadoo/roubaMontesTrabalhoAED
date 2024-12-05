using System.ComponentModel.Design;
using trabalhoAed;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Baralho baralho = new Baralho();
        Stack<Carta> monteDeCompra;
        List<Carta> areaDeDescarte = new List<Carta>();
        Carta cartaDaVez;
        int opcao = 1;
        Jogador[] jogadores;


        while (true)
        {
            Console.WriteLine("BEM VINDO AO JOGO ROUBA MONTES");
            Console.WriteLine("Digite o número de jogadores: ");
            int n = int.Parse(Console.ReadLine());
            jogadores = new Jogador[n];
            CadastroJogadores(jogadores);
            Console.WriteLine("Digite quantas cartas terá o baralho inicial: **LEMBRE-SE QUE O MÁXIMO DE CARTAS É 52**");
            int tamanho = int.Parse(Console.ReadLine());
            monteDeCompra = baralho.BaralhoInicial(tamanho);

            Console.Clear();

            Console.WriteLine($"Jogadores Cadastrados:");
            foreach (Jogador jogador in jogadores)
            {
                Console.WriteLine(jogador.Nome);
            }
            Console.WriteLine("Quantidade de Cartas: " + monteDeCompra.Count());

            cartaDaVez = monteDeCompra.Pop();
            Console.WriteLine($"A carta da vez é: {cartaDaVez.Numero}");

            for (int i = 0; i < jogadores.Length; i++)
            {
                foreach (Jogador outroJogador in jogadores)
                {
                    if (jogadores[i] != outroJogador
                        && outroJogador.MonteDoJogador.Count > 0
                        && cartaDaVez.Numero == outroJogador.MonteDoJogador.Peek().Numero)
                    {
                        jogadores[i].roubaOutroJogador(outroJogador);
                        break;
                    }
                    else if (PegaDaAreaDeDescarte(areaDeDescarte, cartaDaVez, jogadores[i]) == true)
                    {
                        Console.WriteLine("Pegou da área de descarte");
                        break;
                    }
                }
            }
            foreach (Jogador jogador in jogadores)
            {
                Console.WriteLine(jogador.MonteDoJogador.Count);
            }

        }




    }
    public static void CadastroJogadores(Jogador[] jogadores)
    {
        int n = 1;
        for (int i = 0; i < jogadores.Length; i++)
        {
            Console.WriteLine($"Digite o nome do jogador número {n}: ");
            string nome = Console.ReadLine();
            jogadores[i] = new Jogador(nome);
        }
    }

    public static bool PegaDaAreaDeDescarte(List<Carta> descarte, Carta cartaDaVez, Jogador jogador)
    {
        bool verificacao = false;

        foreach(Carta carta in descarte)
        {
            if (carta.Numero == cartaDaVez.Numero)
            {
                jogador.MonteDoJogador.Push(carta);
                descarte.Remove(carta);
                verificacao = true;
            }
            else
            {
                verificacao = false;
            }
        }
        return verificacao;
    }

}