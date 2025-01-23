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
                    if (Tabuleiro.LocalPeca(l,c) == null){
                        Console.Write("-" + " ");
                    }
                    else {
                        ImprimirPeca(Tabuleiro.LocalPeca(l, c));
                        Console.Write(" ");
                    }
               }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerPosicaoXadrez (){
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+"");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca (Peca peca)
        {
            if (peca.Cor == Cor.Branca) {
                Console.Write(peca);
            }
            else{
                ConsoleColor Atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = Atual;
            }
        }
    }
}
