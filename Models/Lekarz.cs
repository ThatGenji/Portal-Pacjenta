using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Pacjenta.Models
{
    public class Lekarz
    {
        private int id;
        private string imie;
        private string nazwisko;
        private string spec;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }

        public Lekarz()
        {

        }

        public Lekarz(int idlek, string Imie, string Nazwisko, string Spec)
        {
            id = idlek;
            imie = Imie;
            nazwisko = Nazwisko;
            spec = Spec;
        }

     //   public dostepnoscLekarza(int id)
     //   {
     //       return;
     //   }
    }
}
