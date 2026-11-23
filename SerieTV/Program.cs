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

        static void Main(string[] args)
        {
            
            int scelta;
            SerieTV[] serie=new SerieTV[10];
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
                        serie[n]=new SerieTV();
                        Console.WriteLine("inserisci il nome della serie");
                        serie[n].Nome=Console.ReadLine();
                        Console.WriteLine("inserisci numero di episodi");
                        serie[n].Episodi=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il voto");
                        serie[n].Voto= Convert.ToInt32(Console.ReadLine());
                        n++;
                        Console.WriteLine();
                    break;

                    case 2://visualizza serie
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine(serie[i]);
                        }
                        Console.WriteLine("\n");
                    break;

                    case 3://modifica serie
                        Console.WriteLine("inserisci il nome della serie che vorrei modificare");
                        string imya = Console.ReadLine();
                        int pos = ricerca(imya, serie, n);

                        Console.WriteLine("inserisci il nome nuovo");
                        serie[pos].Nome = Console.ReadLine();
                        Console.WriteLine("inserisci la quantita di episodi nuova");
                        serie[pos].Episodi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il voto nuovo");
                        serie[pos].Voto = Convert.ToInt32(Console.ReadLine());
                    break;

                    case 4://elimina serie
                        Console.WriteLine("inserisci il nome della serie che vorrei eliminare");
                        string nome1 = Console.ReadLine();
                        int pos1 = ricerca(nome1, serie, n);
                        if (pos1 != -1)
                        {
                            for (int i = pos1; i < n - 1; i++)
                            {
                                serie[i] = serie[i + 1];
                            }
                            n--;
                        }
                        else
                        {
                            Console.WriteLine("Serie non trovata");
                        }
                    break;
                }
            }
            while (scelta != 0);