using Microsoft.AspNetCore.Mvc;
using Profil.Models.KullaniciProfili.cs;
using Profil.Services.ProfileService.cs;

namespace Profil.Controllers.ProfilDenetleyicisi.cs
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfilDenetleyicisi :ControllerBase
    {
        private readonly ProfilServis _profilservis;

        public ProfilDenetleyicisi(ProfilServis profilservis)
        {
            _profilservis = profilservis;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var profil =_profilservis.GetKullaniciProfili();
            return Ok(profil);
        }

        [HttpPut]
        public IActionResult Guncelleme([FromBody] KullaniciProfili profilGuncelleme)
        {
            _profilservis.ProfilGuncelleme(profilGuncelleme);
            return Ok();
        }

        [HttpPost("deneyim")]
        public IActionResult DeneyimEkleme([FromBody] Deneyim newDeneyim) 
        
       {
        _profilservis.deneyimEkleme(newDeneyim);
            return CreatedAtAction(nameof(Get), new { id = newDeneyim.Id },newDeneyim);
       }

        [HttpDelete("deneyim/{id}")]
        public IActionResult DeneyimSilme(int id) 
        {
            _profilservis.DeneyimSilme(id);
            return NoContent();
        }


        [HttpPost("eğitim")]
        public IActionResult EgitimEkleme([FromBody] Egitim eğitim)
        {
            _profilservis.EgitimEkleme(eğitim);
            return CreatedAtAction(nameof(Get), new { }, eğitim);
        }

        [HttpDelete("eğitim/{id}")]
        public IActionResult EgitimSilme(int id)
        {
            _profilservis.EgitimSilme(id);
            return NoContent();
        }


        [HttpPost("skills")]

        public IActionResult AddSkills([FromBody] string skills)
        {
            _profilservis.AddSkills(skills);
            return Ok(new { message = "Yetenek Başarıyla Eklendi." });
        }

        [HttpDelete("skills/{skills}")]
        public IActionResult DeleteSkills(string skills) 
        {
            _profilservis.DeleteSkills(skills); 
            return NoContent();
        }

    }
}
