using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Profil.Models.GirisModeli.cs;


namespace Profil.Controllers.KimlikDogrulamaDenetleyicisi.cs
{

    
     [Microsoft.AspNetCore.Mvc.Route("api/auth")] 
    [Microsoft.AspNetCore.Mvc.ApiController]   
    public class KimlikDogrulamacs : ControllerBase
    {
       [Microsoft.AspNetCore.Mvc.HttpPost("giris")]
        public IActionResult Giris([FromBody] Giris model)
        {
            if (model.Username == "user" && model.Password == "password")
            {
                return Ok(new { message = "Giriş Başarılı." });
            }
            return Unauthorized(new { message = "Geçersiz Kullanıcı adı veya şifre" });
        }



    }

    
    
    
}
