using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieTV
{
    internal class Program
    {
        //RICERCA
        static int ricerca(string nome, SerieTV[] obj, int dim)
        {
            for (int i = 0; i < dim; i++)
            {
                if (obj[i].Nome == nome)
                    return i;
            }
            return -1;
        }

        //AGGIUNGI
        static void AggiungiSerie(SerieTV[] serie, ref int dim, SerieTV obj)
        {
            serie[dim] = new SerieTV();
            serie[dim].Nome = obj.Nome;
            serie[dim].Episodi = obj.Episodi;
            serie[dim].Voto = obj.Voto;
            dim++;
        }

        //VISUALIZZA
        static string VisualizzaSerie(SerieTV[] obj, int dim)
        {
            string result = "";
            for (int i = 0; i < dim; i++)
            {
                result += obj[i].ToString() + "\n";
            }
            return result;
        }

        //MODIFICA
        static void ModificaSerie(SerieTV[] serie, int dim, int pos, SerieTV obj)
        {
            if (pos != -1)
            {
                serie[pos].Nome = obj.Nome;
                serie[pos].Episodi = obj.Episodi;
                serie[pos].Voto = obj.Voto;
            }
        }

        //ELIMINA

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
            SerieTV[] serie = new SerieTV[10];//istanziamento dell'array di oggetti
            SerieTV serie_mod = new SerieTV();//istanziamento dell'oggetto per aggiungi e modifica serie

            int n = 0;//variabile per tenere traccia del numero di serie inserite

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
                        serie_mod.Nome = Console.ReadLine();
                        Console.WriteLine("inserisci il numero di episodi");
                        serie_mod.Episodi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il il voto di serie");
                        serie_mod.Voto = Convert.ToInt32(Console.ReadLine());

                        //func
                        AggiungiSerie(serie, ref n, serie_mod);
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
                        serie_mod.Nome = Console.ReadLine();
                        Console.WriteLine("inserisci la quantita di episodi nuova");
                        serie_mod.Episodi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il voto nuovo");
                        serie_mod.Voto = Convert.ToInt32(Console.ReadLine());

                        //func
                        ModificaSerie(serie, n, pos, serie_mod);
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
            while (scelta != 0);//uscita con zero
        }
    }
}