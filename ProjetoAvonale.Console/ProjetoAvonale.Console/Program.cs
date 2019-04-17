using System;
using System.Collections.Generic;
using static System.Console;

namespace ProjetoAvonale.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /////////////////   Edite os itens da lista aqui  //////////////////////////
            var list = new List<int>{ 1, 2, 3, 4, 5 };
            ////////////////////////////////////////////////////////////////////////////

            var result = new TesteRecursividade();
            WriteLine("Resultado da média: "+ result.Media(list,0));
            WriteLine("Quantidade de valores maiores que a média: " + result.QuantidadeItensMaioresMedia(list, result.Media(list, 0), 0));

            WriteLine("Lista normal: ");
            list.ForEach(x => Write(string.Format(" {0} ", x)));

            WriteLine();

            WriteLine("Lista invertida: ");
            result.InverterLista(list,0).ForEach(x => Write(string.Format(" {0} ",x)));
            ReadLine();
        }
    }
}
