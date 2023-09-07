using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Biblioteca
    {
        public static List<Libro> Libri = new List<Libro>();
        public static List<DVD> DVDs = new List<DVD>();
        public static List<Prestito> Prestiti = new List<Prestito>();

        public static void AggiungiLibri()
        {
            Libro libro = new Libro(1, "HP e la pietra filosofale", 1997, "Fantasy",102);
            Libro libro2 = new Libro(2, "HP e la camera dei segreti", 1998, "Fantasy", 103);
            Libro libro3 = new Libro(3, "HP e il prigioniero di Azkaban", 1999, "Fantasy", 75);
            Libro libro4 = new Libro(4, "HP e il calice di fuoco", 2000, "Fantasy", 53);
            Libro libro5 = new Libro(5, "HP e l'Ordine della Fenice", 2003, "Fantasy", 158);
            Libro libro6 = new Libro(6, "HP e il principe mezzosangue", 2005, "Fantasy", 34);
            Libro libro7 = new Libro(7, "HP e i Doni della Morte", 2007, "Fantasy", 12);
            Libri.Add(libro);
            Libri.Add(libro2);
            Libri.Add(libro3);
            Libri.Add(libro4);
            Libri.Add(libro5);
            Libri.Add(libro6);
            Libri.Add(libro7);

        }

        public static void AggiungiDVD()
        {
            DVD dvd = new DVD(8, "HP e la pietra filosofale", 2001, "Fantasy", 102);
            DVD dvd2 = new DVD(9, "HP e la camera dei segreti", 2002, "Fantasy", 103);
            DVD dvd3 = new DVD(10, "HP e il prigioniero di Azkaban", 2004, "Fantasy", 75);
            DVD dvd4 = new DVD(11, "HP e il calice di fuoco", 2005, "Fantasy", 53);
            DVD dvd5 = new DVD(12, "HP e l'Ordine della Fenice", 2007, "Fantasy", 158);
            DVD dvd6 = new DVD(13, "HP e il principe mezzosangue", 2009, "Fantasy", 34);
            DVD dvd7 = new DVD(14, "HP e i Doni della Morte - Parte 1", 2010, "Fantasy", 12);
            DVD dvd8 = new DVD(15, "HP e i Doni della Morte - Parte 2", 2011, "Fantasy", 12);
            DVDs.Add(dvd);
            DVDs.Add(dvd2);
            DVDs.Add(dvd3);
            DVDs.Add(dvd4);
            DVDs.Add(dvd5);
            DVDs.Add(dvd6);
            DVDs.Add(dvd7);
            DVDs.Add(dvd8);
        }
            
        public static void Menu()
        {
            Console.WriteLine("===============MENU===============");
            Console.WriteLine("1. Registra un prestito");
            Console.WriteLine("2. Elimina un prestito");
            Console.WriteLine("3. Elenco dei prestiti");
            Console.WriteLine("4. Elenco dei materiali disponibili");
            Console.WriteLine("5. ESCI");
            Console.WriteLine("===============MENU===============");

            try
            {
                int option = Convert.ToInt16(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        RegistraPrestito();
                        Menu();
                        break;

                    case 2:
                        EliminaPrestito();
                        Menu();
                        break;

                    case 3:
                        ElencoPrestiti();
                        Menu();
                        break;

                    case 4:
                        ElencoDisponibili();
                        Menu();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opzione non disponibile");
                        Menu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Inserito un valore non valido");
                Menu();
            }

        }

        public static void RegistraPrestito()
        {
            Console.WriteLine("Inserisci il cognome dello studente");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci il nome dello studente");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci l'email dello studente");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di cellulare dello studente");
            int cellulare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cosa prendi?");
            Console.WriteLine("1. LIBRO");
            Console.WriteLine("2. DVD");
            int option = Convert.ToInt16(Console.ReadLine());
            switch(option)
            {
                case 1:
                    Console.WriteLine("Abbiamo questi libri disponibili:");
                    foreach(Libro libro in Libri)
                    {
                        if(libro.Disponile)
                        Console.WriteLine($"Nr {libro.Matricola} {libro.Titolo}");
                    }
                    Console.WriteLine("Inserisci il Nr del libro desiderato");
                    int nrLibro = Convert.ToInt16(Console.ReadLine());
                    foreach(Libro libro in Libri)
                    {
                        if( libro.Matricola == nrLibro)
                        {
                            libro.Disponile = false;
                            Prestito prestito = new Prestito(cognome, nome, email, cellulare, nrLibro);
                            Prestiti.Add(prestito);
                            Console.WriteLine("Prestito Inserito");
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Abbiamo questi DVD disponibili:");
                    foreach (DVD dvd in DVDs)
                    {
                        if(dvd.Disponile)
                        Console.WriteLine($"Nr {dvd.Matricola} {dvd.Titolo}");
                    }
                    Console.WriteLine("Inserisci il Nr del DVD desiderato");
                    int nrDVD = Convert.ToInt16(Console.ReadLine());
                    foreach (DVD dvd in DVDs)
                    {
                        if (dvd.Matricola == nrDVD)
                        {
                            dvd.Disponile = false;
                            Prestito prestito = new Prestito(cognome, nome, email, cellulare, nrDVD);
                            Prestiti.Add(prestito);
                            Console.WriteLine("Prestito Inserito");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Opzione non valida");
                    break;
            }
        }

        public static void EliminaPrestito()
        {
            ElencoPrestiti();

            Console.WriteLine("Inserisci il Nr del materiale restituito");
            int nr = Convert.ToInt16(Console.ReadLine());
            foreach (Libro libro in Libri)
            {
                if (libro.Matricola == nr)
                {
                    libro.Disponile = true;         
                    Console.WriteLine("Libro Restituito e Prestito Eliminato");
                }
            }
            foreach (DVD dvd in DVDs)
            {
                if (dvd.Matricola == nr)
                {
                    dvd.Disponile = true;
                    Console.WriteLine("DVD Restituito e Prestito Eliminato");
                }
            }
            foreach (Prestito prestito in Prestiti)
            {
                if (prestito.nrMateriale == nr) Prestiti.Remove(prestito);
            }
        }

        public static void ElencoPrestiti()
        {
            if (Prestiti.Count == 0) Console.WriteLine("Non sono presenti prestiti");
            else
            {
                Console.WriteLine("I materiali attualmente in prestito sono");
                Console.WriteLine("LIBRI:");
                foreach (Libro libro in Libri)
                {
                    if (libro.Disponile == false)
                    {
                        Console.WriteLine($"Nr {libro.Matricola} {libro.Titolo}");
                        foreach (Prestito prestito in Prestiti)
                        {
                            if (libro.Matricola == prestito.nrMateriale)
                            {
                                Console.WriteLine($"Preso in prestito da {prestito.Cognome} {prestito.Nome}");
                                Console.WriteLine();
                            }


                        }
                    }
                }

                Console.WriteLine("DVD:");
                foreach (DVD dvd in DVDs)
                {
                    if (dvd.Disponile == false)
                    {
                        Console.WriteLine($"Nr {dvd.Matricola} {dvd.Titolo}");
                        foreach (Prestito prestito in Prestiti)
                        {
                            if (dvd.Matricola == prestito.nrMateriale)
                            {
                                Console.WriteLine($"Preso in prestito da {prestito.Cognome} {prestito.Nome}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        public static void ElencoDisponibili()
        {
            if(Libri.Count == 0 && DVDs.Count == 0) Console.WriteLine("Tutti i materiali sono in presito");
            else
            {
                Console.WriteLine("I materiali ancora dispobili sono");
                Console.WriteLine("LIBRI:");
                foreach (Libro libro in Libri)
                {
                    if (libro.Disponile)
                        Console.WriteLine($"Nr {libro.Matricola} {libro.Titolo} Anno:{libro.Anno} {libro.Settore}");
                }

                Console.WriteLine("DVD:");
                foreach (DVD dvd in DVDs)
                {
                    if (dvd.Disponile)
                        Console.WriteLine($"Nr {dvd.Matricola} {dvd.Titolo} Anno:{dvd.Anno} {dvd.Settore}");
                }
            }     
        }
    }
}
