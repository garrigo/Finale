using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection.Metadata;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeedController : Controller
    {
        public virtual void method() { }
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        public DeedController(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings= databaseSettings;
        }
        [HttpGet("deeds", Name = nameof(GetAll))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Deed>))]
        public IActionResult GetAll()
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Deeds.Include(deed => deed.Client).Include(deed => deed.Notary).Include(deed => deed.RealEstate);
            return Ok(content);
        }

        [HttpGet("deeds/{id}", Name = nameof(GetDeedById))]
        [ProducesResponseType(200, Type = typeof(Deed))]
        public IActionResult GetDeedById(int id)
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Deeds.Where(c => c.DeedId == id).Include(deed => deed.Client).Include(deed => deed.Notary).Include(deed => deed.RealEstate).FirstOrDefault();
            return Ok(content);
        }

        [HttpGet("clients", Name = nameof(GetClients))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public IActionResult GetClients()
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Clients.ToList();
            return Ok(content);
        }

        [HttpGet("clients/{id}", Name = nameof(GetClientById))]
        [ProducesResponseType(200, Type = typeof(Client))]
        public IActionResult GetClientById(int id)
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Clients.Where(c => c.ClientId == id).FirstOrDefault();
            return Ok(content);
        }

        [HttpGet("notaries", Name = nameof(GetNotaries))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Notary>))]
        public IActionResult GetNotaries()
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Notaries.ToList();
            return Ok(content);
        }

        [HttpGet("notaries/{id}", Name = nameof(GetNotaryById))]
        [ProducesResponseType(200, Type = typeof(Notary))]
        public IActionResult GetNotaryById(int id)
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.Notaries.Where(c => c.NotaryId == id).FirstOrDefault();
            return Ok(content);
        }

        [HttpGet("estates", Name = nameof(GetRealEstates))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RealEstate>))]
        public IActionResult GetRealEstates()
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.RealEstates.ToList();
            return Ok(content);
        }

        [HttpGet("estates/{id}", Name = nameof(GetRealEstateById))]
        [ProducesResponseType(200, Type = typeof(RealEstate))]
        public IActionResult GetRealEstateById(int id)
        {
            MyContext db = new MyContext(_databaseSettings.Value.ConnectionString);
            var content = db.RealEstates.Where(c => c.RealEstateId == id).FirstOrDefault();
            return Ok(content);
        }

        [HttpPut("", Name = nameof(PopulateDb))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Deed>))]
        public IActionResult PopulateDb()
        {
            using (MyContext db = new MyContext(_databaseSettings.Value.ConnectionString))
            {
                foreach (var item in db.Clients)
                    db.Clients.Remove(item);
                foreach (var item in db.Notaries)
                    db.Notaries.Remove(item);
                foreach (var item in db.RealEstates)
                    db.RealEstates.Remove(item);
                foreach (var item in db.Deeds)
                    db.Deeds.Remove(item);
                db.Database.ExecuteSqlRaw("UPDATE `sqlite_sequence` SET `seq` = 0");
                db.SaveChanges();


                CultureInfo provider = CultureInfo.InvariantCulture;
                // It throws Argument null exception  
                db.RealEstates.AddRange(
                    new RealEstate() { City = "Toronto", Address = "Via xxx", Mq = 60, Price = 1100 },
                    new RealEstate() { City = "Milan", Address = "Via yyy", Mq = 75, Price = 1241},
                    new RealEstate() { City = "Rome", Address = "Via zzz", Mq = 80, Price = 989 }
                 );
                db.Notaries.AddRange(
                    new Notary() {  Name = "Joseph", Surname = "Joestar", City = "Milan", DateOfBirth = DateTime.ParseExact("10/05/1975", "dd/mm/yyyy", provider) },
                    new Notary() {  Name = "Paolo", Surname = "Bianchi", City = "Toronto", DateOfBirth = DateTime.ParseExact("29/03/1979", "dd/mm/yyyy", provider) },
                    new Notary() {  Name = "Angela", Surname = "Neri", City = "Rome", DateOfBirth = DateTime.ParseExact("04/11/1986", "dd/mm/yyyy", provider) }
                );
                db.Clients.AddRange(
                    new Client() { Name = "Giovanni", Surname = "Manesco", City = "Milan", DateOfBirth = DateTime.ParseExact("18/07/1996", "dd/mm/yyyy", provider) },
                    new Client() { Name = "Tommaso", Surname = "Salvi", City = "Toronto", DateOfBirth = DateTime.ParseExact("04/12/1996", "dd/mm/yyyy", provider) },
                    new Client() { Name = "Veronica", Surname = "Mars", City = "Rome", DateOfBirth = DateTime.ParseExact("31/10/1997", "dd/mm/yyyy", provider) }
                );
                db.SaveChanges();

                for (int i = 0; i < 10; i++)
                {
                    db.Deeds.Add(new Deed()
                    {
                        Notary = db.Notaries.Where(stud => stud.NotaryId == (i % 3) + 1).First(),
                        Client = db.Clients.Where(subj => subj.ClientId == (i % 3) + 1).First(),
                        RealEstate = db.RealEstates.Where(teac => teac.RealEstateId == (i % 3) + 1).First(),
                        Date = DateTime.Now
                    });

                }
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
