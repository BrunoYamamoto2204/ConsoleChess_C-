

namespace xadrez_console.TabuleiroN
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QntdMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca (Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QntdMovimentos = 0;
            Tabuleiro = tabuleiro;  
        }

        public void incrementarQntdMovimentos()
        {
            QntdMovimentos ++;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
