using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal_Pacjenta.Models
{
    public class Wizyta
    {
        private int id_wizyty;
        private int lekarz;
        private int pacjent;
        private DateTime data;
        [BindProperty]
        [Required]
        public int ID_Wizyty
        {
            get { return id_wizyty; }
            set { id_wizyty = value; }
        }
        [BindProperty]
        [Required]
        public int Lekarz
        {
            get { return lekarz; }
            set { lekarz = value; }
        }
        [BindProperty]
        [Required]
        public int Pacjent
        {
            get { return pacjent; }
            set { pacjent = value; }
        }
        [BindProperty]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime Data
        {
            get => data;
            set => data = value;
        }


        public Wizyta()
        {

        }

        public Wizyta(int Id, int Lekarz, int Pacjent, DateTime Data)
        {
            id_wizyty = Id;
            lekarz = Lekarz;
            pacjent = Pacjent;
            data = Data;
        }

    }
}
