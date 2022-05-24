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
    public class LekarzController : Controller
    {
        private List<Models.Lekarz> lista = new List<Models.Lekarz>();


       
            private readonly IConfiguration _configuration;
            private string _connectionString;
            DbContextOptionsBuilder<DatabaseContext> _optionsBuilder;

            public LekarzController(IConfiguration configuration)
            {
                _configuration = configuration;
                _optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                _connectionString = _configuration.GetConnectionString("DefaultConnection");
                _optionsBuilder.UseSqlServer(_connectionString);
            }

            public IActionResult ListaLekarzy()
            {
                using (DatabaseContext _context = new DatabaseContext(_optionsBuilder.Options))
                {
                    lista = _context.Lekarze.ToList();
                    return View(lista);
                }
            }
        /*
                private DatabaseContext context = new DatabaseContext();

                public IActionResult ListaLekarzy()
                {
                    var lek = context.Lekarze;
                    return View(lek);
                    /*
                    lista = WczytajZXML(lista);


                    return View(lista);

                }
                 */
        /*
                    private List<Models.Lekarz> WczytajZXML(List<Models.Lekarz> listaLekarzy)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Lekarz>));
                    FileStream fileStream = new FileStream("D:\\lekarze.xml", FileMode.Open);

                    List<Models.Lekarz> lekarzReturn = (List<Models.Lekarz>)serializer.Deserialize(fileStream);

                    fileStream.Close();

                    return lekarzReturn;
                }

                private void ZapiszDoXML(List<Models.Lekarz> listaLekarzy)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Models.Lekarz>));
                    TextWriter writer = new StreamWriter("D:\\lekarze.xml");

                    serializer.Serialize(writer, listaLekarzy);
                    writer.Close();

                }
           */
    }
}
