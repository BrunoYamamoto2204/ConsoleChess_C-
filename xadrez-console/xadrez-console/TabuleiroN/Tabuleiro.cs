

namespace xadrez_console.TabuleiroN
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro (int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas,Colunas];
        }

        public Peca LocalPeca(int linha, int coluna){
            return Pecas[linha, coluna];
        }
        public Peca LocalPeca(Posicao posicao) {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public void colocarPeca (Peca peca, Posicao posicao){
            if (existePeca(posicao)){
                throw new TabuleiroException("Já existe uma peça nessa posição");    
            }

            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool existePeca(Posicao pos){
            posicaoValida(pos);     
            if (LocalPeca(pos) != null) {
                return true;
            }
            return false;
        }

        public bool posicaoValida(Posicao pos){ // Validar se a posição existe
            if (pos.Linha < 0 || pos.Coluna < 0 || pos.Linha >= Linhas || pos.Coluna >= Colunas) {
                throw new TabuleiroException("Posição inválida");
            }
            return true;
        }

        //public void validarPosicao(Posicao pos)
        //{ // Verifica a exceção
        //    if (!posicaoValida(pos))
        //    {
        //        throw new TabuleiroException("Posição inválida");
        //    }
        //}
    }
}
