using xadrez_console.TabuleiroN;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro (Tabuleiro Tabuleiro)
        {
            for (int l = 0; l < Tabuleiro.Linhas; l++) {
               Console.Write(8-l + " ");
               for (int c = 0; c < Tabuleiro.Colunas; c++){
                        ImprimirPeca(Tabuleiro.LocalPeca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleiro Tabuleiro, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int l = 0; l < Tabuleiro.Linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < Tabuleiro.Colunas; c++)
                {
                    if (posicoesPossiveis[l, c])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(Tabuleiro.LocalPeca(l, c));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez (){
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+"");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca (Peca peca)
        {
            if (peca == null){
                Console.Write("-" + " ");
            }
            else{
                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else{
                    ConsoleColor Atual = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = Atual;
                }
                Console.Write(" ");
            }
        }

    }
}
