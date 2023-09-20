using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuvar
{
    class Fuvar
    {
        int taxiazonosito;
        string indulas;
        int indotartam;
        double megtetttavolsag;
        double viteldij;
        double borravalo;
        string fizetesmod;

        public Fuvar(int taxiazonosito, string indulas, int indotartam, double megtetttavolsag, double viteldij, double borravalo, string fizetesmod)
        {
            this.Taxiazonosito = taxiazonosito;
            this.Indulas = indulas;
            this.Indotartam = indotartam;
            this.Megtetttavolsag = megtetttavolsag;
            this.Viteldij = viteldij;
            this.Borravalo = borravalo;
            this.Fizetesmod = fizetesmod;
        }

        public int Taxiazonosito { get => taxiazonosito; set => taxiazonosito = value; }
        public string Indulas { get => indulas; set => indulas = value; }
        public int Indotartam { get => indotartam; set => indotartam = value; }
        public double Megtetttavolsag { get => megtetttavolsag; set => megtetttavolsag = value; }
        public double Viteldij { get => viteldij; set => viteldij = value; }
        public double Borravalo { get => borravalo; set => borravalo = value; }
        public string Fizetesmod { get => fizetesmod; set => fizetesmod = value; }
    }
}
