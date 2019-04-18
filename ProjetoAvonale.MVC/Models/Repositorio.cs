using System;
using Newtonsoft.Json;

namespace ProjetoAvonale.MVC.Models
{
    public class Repositorio
    {
        public Repositorio()
        {
        }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
