﻿using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public bool existeInimigo(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p.cor != cor;
        }

        public bool livre(Posicao pos)
        {
            return tab.Peca(pos) == null;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if(cor == Cor.Branca)
            {
                pos.definirValores(posicao.Linha - 1, posicao.Coluna);
                if(tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha - 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }
            else
            {
                pos.definirValores(posicao.Linha + 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha + 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;

        }
    }
}
