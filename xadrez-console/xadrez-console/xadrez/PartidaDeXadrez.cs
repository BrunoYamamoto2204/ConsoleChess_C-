using xadrez_console.TabuleiroN;
using xadrez_console.xadrez;

namespace xadrez_console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro {get ; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez ()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(p, destino);

            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void desfazMovimento (Posicao origem, Posicao destino, Peca pecaCapturada){
            Peca p = Tabuleiro.retirarPeca (destino);
            p.decrementarQntdMovimentos();

            if (pecaCapturada != null) {
                Tabuleiro.colocarPeca (pecaCapturada, destino);
                Capturadas.Remove (pecaCapturada);
            }
            Tabuleiro.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento (origem, destino);

            if (estaEmXeque(JogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em posição de xeque!");
            }

            if (estaEmXeque(adversaria(JogadorAtual))){
                Xeque = true;
            }
            else{
                Xeque = false;
            }

            if (testeXequemate(adversaria(JogadorAtual))){
                Terminada = true;
            }
            else {
                Turno ++;
                mudaJogador();
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos){
            if (Tabuleiro.LocalPeca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.LocalPeca(pos).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua! ");
            }
            if (!Tabuleiro.LocalPeca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino){
            if (!Tabuleiro.LocalPeca(origem).movimentoPossivel(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else{
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas){
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        // Retorna todas as peças, menos as capturadas
        public HashSet<Peca> pecasEmJogo(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor)); 
            return aux;
        }

        private Cor adversaria (Cor cor)
        {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else{
                return Cor.Branca;
            }
        }

        private Peca rei (Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor)) {
                if (x is Rei){
                   return x; 
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor" + cor + " no tabuleiro");
            }

            foreach(Peca x in pecasEmJogo(adversaria(cor))){

                bool[,] mat = x.movimentosPossiveis();
                if(mat[R.Posicao.Linha, R.Posicao.Coluna] ==  true){ // Se for possível mover na posição do rei 
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate (Cor cor)
        {
            if (!estaEmXeque(cor)){
                return false;
            }
            foreach (Peca x in pecasEmJogo (cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int l =0; l < Tabuleiro.Linhas; l++) {
                    for (int c = 0; c < Tabuleiro.Colunas; c++) {
                        if (mat[l,c] == true){ // As matrizes que são possíveis 
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(l, c);
                            Peca pecaCapturada = executaMovimento(origem, destino); // Vai realmente andar com a peça para ver há possibilidades
                            bool testeXeque = estaEmXeque(cor); // Pega a posição do rei e checa com as outras peças 
                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque){
                                return false;
                            } 
                        }
                    }
                }
            }
            return true;
        }

        public void colocarNovaPeca (char coluna, int linha, Peca peca)
        {
            Tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna,linha).toPosicao());
            Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 7, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));
            
            colocarNovaPeca('a', 8, new Rei(Tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Torre(Tabuleiro, Cor.Preta));
            
            
        }
    }
}
