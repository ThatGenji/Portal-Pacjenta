using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Pacjenta.Models
{
    public class Pacjent
    {
        private int id_pacjenta;
        private string imie;
        private string nazwisko;
        private string telefon;
        private string email;
        public int ID_Pacjenta
        {
            get { return id_pacjenta; }
            set { id_pacjenta = value; }
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

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Pacjent()
        {

        }

        public Pacjent(int id, string Imie, string Nazwisko, string Tel, string Mail)
        {
            id_pacjenta = id;
            imie = Imie;
            nazwisko = Nazwisko;
            telefon = Tel;
            email = Mail;
        }
    }
}
