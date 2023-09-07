﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class DVD
    {
        public int Matricola;

        public string Titolo { get; set; }
        public int Anno { get; set; }

        public string Settore { get; set; }

        public bool Disponile = true;

        public int Scaffale { get; set; }

        public DVD() { }
        public DVD(int matricola, string titolo, int anno, string settore, int scaffale)
        {
            Matricola = matricola;
            Titolo = titolo;
            Anno = anno;
            Settore = settore;
            Scaffale = scaffale;
        }
    }
}
