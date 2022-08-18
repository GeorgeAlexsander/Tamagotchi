using System;
using System.Collections.Generic;
using Tamagotchi;

namespace Tamagotchi
{
    public static class TamagotchiInterface
    {
        public static void TelaInicial()
        {
            Console.WriteLine("1 - Adotar um pokemon");
            Console.WriteLine("2 - Ver seus pokemons");
            Console.WriteLine("3 - Sair");
        }
        public static void SelecaodePokemon()
        {
            Console.WriteLine($"Escolha seu pokemon:");
            Console.WriteLine();
        }

        public static void MenudeAdocao(string especieMascote)
        {
            Console.WriteLine($"1 - SABER MAIS SOBRE O {especieMascote}");
            Console.WriteLine($"2 - ADOTAR {especieMascote}");
            Console.WriteLine($"3 - VOLTAR");
            Console.WriteLine();
        }
        
        public static void HabilidadesdoPokemon(Pokedex pokemon)
        {
            Console.WriteLine("Nome: " + pokemon.name.ToUpper());
            Console.WriteLine("Altura: " + pokemon.height / 10 + " m");
            Console.WriteLine("Peso: " + pokemon.weight / 10 + " kg");
            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidade in pokemon.abilities)
                Console.WriteLine(habilidade.ability.name.ToUpper());
            Console.WriteLine();
        }

        public static void MensagemdeAdocao()
        {
            Console.WriteLine($"Mascote adotado com sucesso, boa sorte na sua jornada pokemon!");
            Console.WriteLine();
        }
    }
}