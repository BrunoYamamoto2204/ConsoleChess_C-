

namespace xadrez_console.TabuleiroN
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QntdMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca (Posicao posicao, Cor cor, int qntdMovimentos, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            QntdMovimentos = qntdMovimentos = 0;
            Tabuleiro = tabuleiro;  
        }
    }
}
