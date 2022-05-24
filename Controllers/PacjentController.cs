using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portal_Pacjenta.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Portal_Pacjenta.Controllers
{
    public class PacjentController : Controller
    {
        private List<Models.Wizyta> listaWizyt = new List<Models.Wizyta>();
        private List<Models.Lekarz> lista = new List<Models.Lekarz>();

        private readonly IConfiguration _configuration;
        private string _connectionString;
        DbContextOptionsBuilder<DatabaseContext> _optionsBuilder;

        public PacjentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _optionsBuilder.UseSqlServer(_connectionString);
        }

        public IActionResult Pacjent()
        {
            return View();
        }

        public IActionResult DostepnoscLekarza()
        {
            return View();
        }

        public IActionResult Dostepnosc(int Lekarz, DateTime Data)
        {
            listaWizyt = WczytajWizyta(listaWizyt);
            // lista = WczytajLekarz(lista);
            using (DatabaseContext _context = new DatabaseContext(_optionsBuilder.Options))
            {
                lista = _context.Lekarze.ToList();

                // if (listaWizyt.Exists(x => x.Data == Data) == false) return View(Jest = false);
                if (listaWizyt.Exists(x => x.Lekarz == Lekarz && x.Data == Data) == false) return View("Dostepny");
               // lista.RemoveAt(listaWizyt.FindIndex(x => x.Lekarz == Lekarz));
                //  if (listaWizyt.Exists(x => x.Data == Data) == true) listaWizyt.Find(x => x.Lekarz != Lekarz).Where(x => x.Data == Data);
                return View("Niedostepny", lista);
            }

            /*  private List<Models.Lekarz> WczytajLekarz(List<Models.Lekarz> lista)
              {
                  XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Lekarz>));
                  FileStream fileStream = new FileStream("D:\\lekarze.xml", FileMode.Open);

                  List<Models.Lekarz> lekarzReturn = (List<Models.Lekarz>)serializer.Deserialize(fileStream);

                  fileStream.Close();

                  return lekarzReturn;
              }*/
        }

        private static List<Wizyta> WczytajWizyta(List<Wizyta> listaWizyt)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Wizyta>));
            FileStream fileStream = new FileStream("D:\\wizyty.xml", FileMode.Open);

            List<Models.Wizyta> wizytaReturn = (List<Models.Wizyta>)serializer.Deserialize(fileStream);

            fileStream.Close();

            return wizytaReturn;
        }
    }
}
