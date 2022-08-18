﻿using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    public class Pokedex
    {
        public List<Abilities> abilities { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string name { get; set; }
        public int Alimentacao { get; set; }
        public int Humor { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}