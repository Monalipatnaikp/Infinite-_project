using System.Linq;
using System.Web.Http;
using YourProjectName.Models;

namespace YourProjectName.Controllers
{
    public class CountryController : ApiController
    {
        private YourDbContext db = new YourDbContext();

       
        public IHttpActionResult GetCountries()
        {
            var countries = db.Countries.ToList();
            return Ok(countries);
        }

     
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Countries.Add(country);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = db.Countries.Find(id);
            if (existing == null)
                return NotFound();

            existing.CountryName = country.CountryName;
            existing.Capital = country.Capital;
            db.SaveChanges();

            return Ok(existing);
        }

        public IHttpActionResult DeleteCountry(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok($"Deleted country with ID {id}");
        }
    }
}
