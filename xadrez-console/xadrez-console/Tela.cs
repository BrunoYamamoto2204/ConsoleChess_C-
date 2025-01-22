﻿using xadrez_console.TabuleiroN;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro (Tabuleiro Tabuleiro)
        {
            for (int l = 0; l < Tabuleiro.Linhas; l++) {
               for (int c = 0; c < Tabuleiro.Colunas; c++){
                    if (Tabuleiro.LocalPeca(l,c) == null){
                        Console.Write("-" + " ");
                    }
                    else {
                        Console.Write(Tabuleiro.LocalPeca(l, c) + " ");
                    }
               }
                Console.WriteLine();
            }

        }
    }
}
