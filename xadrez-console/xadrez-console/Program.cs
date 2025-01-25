using System;
using xadrez_console.TabuleiroN;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args) 
        {
            try{
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {

                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.LocalPeca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tabuleiro,posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeDestino(origem,destino);

                        partida.realizaJogada(origem,destino);
                    }
                    catch (TabuleiroException e){
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partida);

            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
