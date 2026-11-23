using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieTV
{
    internal class SerieTV
    {
        private string _nome;
        private int _episodi;
        private int _voto;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Episodi
        {
            get { return _episodi; }
            set
            {
                if (value >= 0)
                    _episodi = value;
                else
                    throw new Exception("valore non consentito");
            }

        }
        public int Voto
        {
            get { return _voto; }
            set
            {
                if (value >= 0)
                    _voto = value;
                else
                    throw new Exception("voto non valido");
            }
        }
        public SerieTV() {
            Nome = "";
            Episodi = 0;
            Voto = 0;   
        }
        public SerieTV(string n,int e,int v)
        {
            Nome = n;
            Episodi = e;
            Voto = v;
        }
        public SerieTV(string n, int e)
        {
            Nome = n;
            Episodi = e;
        }
        public SerieTV(int v,string n)
        {
            Nome = n;
            Voto = v;
        }
        //metodi 
        public override string ToString()
        {
            return Nome + "," + Episodi + "," + Voto;
        }
    }
}
