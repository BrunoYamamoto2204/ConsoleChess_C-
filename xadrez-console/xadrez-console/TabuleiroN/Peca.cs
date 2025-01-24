

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

        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();

            for(int l = 0; l < Tabuleiro.Linhas; l++) {
                for (int c = 0; c < Tabuleiro.Colunas; c++) {
                    if (mat[l,c] == true){
                        return true;
                    }
                }
            }
            return false; 
        }

        // Posicao True = pode mover 
        public bool podeMoverPara (Posicao pos) {
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
