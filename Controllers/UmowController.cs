using Microsoft.AspNetCore.Mvc;
using Portal_Pacjenta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Portal_Pacjenta.Controllers
{
    public class UmowController : Controller
    {
        private List<Models.Wizyta> listaWizyt = new List<Models.Wizyta>();

        public IActionResult Umow()
        {

            return View();
        }

        public IActionResult Anuluj()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Anulowanie(int Lekarz, int Pacjent, DateTime Data)
        {
            listaWizyt = WczytajZXML(listaWizyt);
            if (listaWizyt.Exists(x => x.Lekarz == Lekarz && x.Pacjent == Pacjent && x.Data == Data) == false) return View("Brak");
            listaWizyt.RemoveAt(listaWizyt.FindIndex(x => x.Lekarz == Lekarz && x.Pacjent == Pacjent && x.Data == Data));
            ZapiszDoXML(listaWizyt);
            return View("Anulowano");
        }

        [HttpPost]
        public IActionResult OnPost(int Lekarz, int Pacjent, DateTime Data)
        {
            listaWizyt = WczytajZXML(listaWizyt);
            var id = listaWizyt.Count+1;
            listaWizyt.Add(new Wizyta(id, Lekarz, Pacjent, Data));
            ZapiszDoXML(listaWizyt);
            return View();
        }


        private List<Models.Wizyta> WczytajZXML(List<Models.Wizyta> listaWizyt)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Wizyta>));
            FileStream fileStream = new FileStream("D:\\wizyty.xml", FileMode.Open);

            List<Models.Wizyta> wizytaReturn = (List<Models.Wizyta>)serializer.Deserialize(fileStream);

            fileStream.Close();

            return wizytaReturn;
        }
        private void ZapiszDoXML(List<Models.Wizyta> listaWizyt)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Wizyta>));
            TextWriter writer = new StreamWriter("D:\\wizyty.xml");

            serializer.Serialize(writer, listaWizyt);
            writer.Close();

        }
    }
}
