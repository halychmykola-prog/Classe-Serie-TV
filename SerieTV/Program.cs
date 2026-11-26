using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieTV
{
    internal class Program
    {
        static int ricerca(string nome, SerieTV[] serie, int dim)
        {
            for (int i = 0; i < dim; i++)
            {
                if (serie[i].Nome == nome)
                    return i;
            }
            return -1;
        }

        static void AggiungiSerie(SerieTV[] serie, ref int dim, string nome, int episodi, int voto)
        {
            serie[dim] = new SerieTV();
            serie[dim].Nome = nome;
            serie[dim].Episodi = episodi;
            serie[dim].Voto = voto;
            dim++;
        }

        static string VisualizzaSerie(SerieTV[] serie, int dim)
        {
            string result = "";
            for (int i = 0; i < dim; i++)
            {
                result += serie[i].ToString() + "\n";
            }
            return result;
        }

        static void ModificaSerie(SerieTV[] serie, int dim, string nome, string nuovoNome, int nuoviEpisodi, int nuovoVoto)
        {
            int pos = ricerca(nome, serie, dim);
            if (pos != -1)
            {
                serie[pos].Nome = nuovoNome;
                serie[pos].Episodi = nuoviEpisodi;
                serie[pos].Voto = nuovoVoto;
            }
        }

        static void EliminaSerie(SerieTV[] serie, ref int dim, string nome)
        {
            int pos = ricerca(nome, serie, dim);
            if (pos != -1)
            {
                for (int i = pos; i < dim - 1; i++)
                {
                    serie[i] = serie[i + 1];
                }
                dim--;
            }
        }

        static void Main(string[] args)
        {

            int scelta;
            SerieTV[] serie = new SerieTV[10];
            SerieTV serie_mod = new SerieTV();

            int n = 0;
            do
            {
                //menù
                Console.WriteLine("1 - aggiungi serie");
                Console.WriteLine("2 - Visualizza serie");
                Console.WriteLine("3 - modifica serie");
                Console.WriteLine("4 - elimina serie");
                Console.WriteLine("0 -USCITA\n");
                Console.WriteLine("INSERISCI LA SCELTA:");
                scelta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (scelta)
                {
                    case 1://aggiungi serie
                        //parte inserimento dati
                        Console.WriteLine("inserisci il nome della serie");
                        string nome = Console.ReadLine();
                        Console.WriteLine("inserisci il numero di episodi");
                        int num_episodi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il il voto di serie");
                        int voto = Convert.ToInt32(Console.ReadLine());

                        //func
                        AggiungiSerie(serie, ref n, nome, num_episodi, voto);
                        break;

                    case 2://visualizza serie
                        Console.WriteLine(VisualizzaSerie(serie, n));
                        break;

                    case 3://modifica serie
                        //parte ricerca 
                        Console.WriteLine("inserisci il nome della serie che vorrei modificare");
                        string imya = Console.ReadLine();
                        int pos = ricerca(imya, serie, n);

                        //parte inserimento dati nuovi
                        Console.WriteLine("inserisci il nome nuovo");
                        nome = Console.ReadLine();
                        Console.WriteLine("inserisci la quantita di episodi nuova");
                        num_episodi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il voto nuovo");
                        voto = Convert.ToInt32(Console.ReadLine());

                        //func
                        ModificaSerie(serie, n, imya, nome, num_episodi, voto);
                        break;

                    case 4://elimina serie
                        //parte ricerca
                        Console.WriteLine("inserisci il nome della serie che vorrei eliminare");
                        string nome1 = Console.ReadLine();
                        int pos1 = ricerca(nome1, serie, n);

                        //parte eliminazione
                        EliminaSerie(serie, ref n, nome1);
                        break;
                }
            }
            while (scelta != 0);
        }
    }
}