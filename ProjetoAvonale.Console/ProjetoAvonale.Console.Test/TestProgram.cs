using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjetoAvonale.Console.Test
{
    public class TestProgram
    {
        [Fact]
        public void DeveSerDouble()
        {
            var program = new TesteRecursividade();
            Type type = typeof(double);
            Assert.True(type == program.Media(new List<int> { 5,5},0).GetType());
        }

        [Fact]
        public void DeveSerUmaMedia()
        {
            var program = new TesteRecursividade();
            var list = new List<int>() { 5, 5,35,4,7 };
            var result = program.Media(list,0);
            Assert.Equal(list.Average(), result);
        }

        [Fact]
        public void ElementosMaioresMedia()
        {
            var program = new TesteRecursividade();
            var list = new List<int>() { 5, 5, 35, 4, 7 };
            var result = program.QuantidadeItensMaioresMedia(list, list.Average(), 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void ReverterLista()
        {
            var program = new TesteRecursividade();
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var result = program.InverterLista(list,0);
            Assert.Equal(new List<int> { 5,4,3,2,1}, result);
        }
    }
}
