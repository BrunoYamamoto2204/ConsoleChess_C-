using System;
using xadrez_console.TabuleiroN;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args) 
        {
            Tabuleiro tablueiro = new Tabuleiro(8,8);

            Console.WriteLine(tablueiro);
        }
    }
}
