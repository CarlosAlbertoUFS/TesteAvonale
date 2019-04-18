using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjetoAvonale.MVC.Models;

namespace ClienteHttp
{
    public class RepositorioService
    {
        public static readonly string uri_base = "https://api.github.com"; 
        public async Task<List<Repositorio>> GetRepositoriosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try	
                {
                    var uri = new Uri(String.Format("{0}{1}",uri_base, "users/CarlosAlbertoUFS/repos"));
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if(response.IsSuccessStatusCode)
                    {
                        var dados = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Repositorio>>(dados);
                    }else
                    {
                        throw new Exception("Não foi possível obter o usuário: " + response.StatusCode);
                    }
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException capturada!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }
            return new List<Repositorio>();
        }
        public async Task<Repositorio> GetRepositorioAsync(int id)
        {
          using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try	
                {
                    var uri = new Uri(String.Format("{0}{1}{2}",uri_base, "api/usuarios/", id));
                    HttpResponseMessage response = await client.GetAsync(uri);
                    
                    if(response.IsSuccessStatusCode)
                    {
                        var dados = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Repositorio>(dados);
                    }else
                    {
                        throw new Exception("Não foi possível obter o usuário: " + response.StatusCode);
                    }
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException capturada!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }
            return new Repositorio();
        }

        public async void AddRepositorioAsync(Repositorio user) 
        {
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try	
                {
                    var uri = String.Format("{0}{1}",uri_base, "api/usuarios/");
                    var usuarioSerialized = JsonConvert.SerializeObject(user);
                    var content = new StringContent(usuarioSerialized, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(uri, content);
                    if(response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("O usuário foi criado!");
                    }else
                    {
                        throw new Exception("A adição não foi bem sucessida.");
                    }
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException capturada!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }
        }

        public async void UpdateRepositorioAsync(Repositorio user)
        {
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try	
                {
                    var uri = String.Format("{0}{1}{2}",uri_base, "api/usuarios/", user.RepositorioId);
                    var usuarioSerialized = JsonConvert.SerializeObject(user);
                    var content = new StringContent(usuarioSerialized, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(uri, content);
                    if(response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Usuário atualizado com sucesso!!");
                    }else
                    {
                        throw new Exception("A atualização falhou.");
                    }
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException capturada!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }
        }

          public async void DeleteRepositorioAsync(long id)
          {
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try	
                {
                    var uri = String.Format("{0}{1}{2}", uri_base, "api/usuarios/", id);
                    HttpResponseMessage response = await client.DeleteAsync(uri);

                    if(response.IsSuccessStatusCode)
                    {    
                        Console.WriteLine("Usuário removido com sucesso!");
                    }else
                    {
                        throw new Exception("Não foi possível remover o usuário.");
                    }
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException capturada!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }
        }
    }
}