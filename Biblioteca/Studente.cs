using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Prestito
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public int Cellulare { get; set; }

        public int nrMateriale { get; set; }

        public Prestito() { }

        public Prestito(string cognome, string nome, string email, int cellulare, int nr)
        {
            Cognome = cognome;
            Nome = nome;
            Email = email;
            Cellulare = cellulare;
            nrMateriale = nr;
        }
    }
}
