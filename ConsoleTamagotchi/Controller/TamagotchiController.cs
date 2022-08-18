using System;
using System.Collections.Generic;
using Tamagotchi;
using System.Diagnostics;

namespace Tamagotchi
{
    public class TamagotchiControler
    {
        private static List<Pokedex> MascotesAdotados {get; set; }
    
        public TamagotchiControler()
        {
            MascotesAdotados = new List<Pokedex>();

        }

        public static void StartGame()
        {
            string opcaoUsuario;
            int jogar = 1;

            while (jogar == 1)
            {
                TamagotchiInterface.TelaInicial();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        novaAdocao();
                        break;

                    case "2":
                        break;

                    case "3":
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente. ");
                        break;
                }
            }
        }

        public static void novaAdocao()
        {
            string opcaoUsuario = "1", especieMascote;
            Pokedex pokemon;

            TamagotchiInterface.SelecaodePokemon();
            especieMascote = Console.ReadLine();


            while (opcaoUsuario != "3")
            {
                TamagotchiInterface.MenudeAdocao(especieMascote);
                Console.WriteLine();
                string opcaoUsuarioSubMenu = Console.ReadLine();

                switch (opcaoUsuarioSubMenu)
                {
                    case "1":
                        pokemon = PokedexSeach.BuscarCaracteristicasPorEspecie(especieMascote);
                        TamagotchiInterface.HabilidadesdoPokemon(pokemon);
                        break;

                    case "2":
                        pokemon = PokedexSeach.BuscarCaracteristicasPorEspecie(especieMascote);
                        MascotesAdotados.Add(pokemon);
                        TamagotchiInterface.MensagemdeAdocao();
                        opcaoUsuario = "3";
                        break;

                    case "3":
                        opcaoUsuario = "3";
                        break;

                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente: ");
                        break;
                }
            }
        }
    }
}