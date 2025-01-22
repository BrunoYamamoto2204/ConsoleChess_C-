using System.Security.Cryptography.X509Certificates;
using xadrez_console.TabuleiroN;

namespace xadrez_console.xadrez
{
    class Rei : Peca
    {
        public Rei (Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
