using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAvonale.Console
{
    public class TesteRecursividade
    {
        public TesteRecursividade()
        {
        }

        public double Media(List<int> list, int posInicial)
        {
            var posicao = Convert.ToDouble(list[posInicial]);
            var contador = Convert.ToDouble(list.Count);
            var media = posicao / contador;
            if ((list.Count - 1) != posInicial)
            {
                return media + Media(list, posInicial+1);
            }
                
            return media;
        }

        public int QuantidadeItensMaioresMedia(List<int> list, double media, int pos) 
        {
            if(list.Count-1 == pos)
            {
                if (list[pos] > media)
                    return 1;

                return 0;
            }

            if (list[pos] > media)
                return QuantidadeItensMaioresMedia(list, media, pos+1) + 1;

            return QuantidadeItensMaioresMedia(list, media, pos+1);
        }

        public List<int> InverterLista(List<int> list, int pos) 
        {
            if(pos < list.Count / 2)
            {
                int tmp = list[pos];
                int novoLocal = (list.Count-1) - pos;
                list[pos] = list[novoLocal];
                list[novoLocal] = tmp;
                InverterLista(list, pos+1);
            }
            return list;
        }
    }
}
