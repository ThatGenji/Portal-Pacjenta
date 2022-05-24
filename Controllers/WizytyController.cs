using Microsoft.AspNetCore.Mvc;
using Portal_Pacjenta.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Portal_Pacjenta.Controllers
{
    public class WizytyController : Controller
    {
        private List<Models.Wizyta> listaWizyt = new List<Models.Wizyta>();

        public IActionResult ListaWizyt()
        {
            listaWizyt = WczytajZXML(listaWizyt);
            //listaWizyt.Add(new Wizyta(1, 1, 1, new DateTime(2022, 12, 11)));
            // ViewData["Wizyta"] = new Models.Wizyta(1, 1, 1, 12-12-2022);

            return View(listaWizyt);
        }

        private List<Models.Wizyta> WczytajZXML(List<Models.Wizyta> listaLekarzy)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Wizyta>));
            FileStream fileStream = new FileStream("D:\\wizyty.xml", FileMode.Open);

            List<Models.Wizyta> wizytaReturn = (List<Models.Wizyta>)serializer.Deserialize(fileStream);

            fileStream.Close();

            return wizytaReturn;
        }


    }
}
