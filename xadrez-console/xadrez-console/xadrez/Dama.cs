using System.Security.Cryptography.X509Certificates;
using xadrez_console.TabuleiroN;

namespace xadrez_console.xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro Tabuleiro, Cor Cor) : base(Tabuleiro, Cor) { }

        public override string ToString()
        {
            return "D";
        }

        // Conferir se é possível mover p/ posição desejada 
        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.LocalPeca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha -= 1;
            }
            // abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha += 1;
            }
            // direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna += 1;
            }
            // esquerda
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna -= 1; ;
            }
            // no
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            }

            // ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            }
            // se
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            }
            // so
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.LocalPeca(pos) != null && Tabuleiro.LocalPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            }


            return mat;
        }
    }
}
