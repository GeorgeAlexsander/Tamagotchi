using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public static class PokedexSeach
    {
        // execução do método GET
        public static Pokedex BuscarCaracteristicasPorEspecie(string pokedexEspecie)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokedexEspecie.ToLower()}");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            return JsonSerializer.Deserialize<Pokedex>(response.Content);
        }
    }
}
