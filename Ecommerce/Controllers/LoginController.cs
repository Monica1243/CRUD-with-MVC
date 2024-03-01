using Ecommerce.Models;
using Ecommerce.Models.Domain;
using Ecommerce.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Numerics;
using WebAPI.Models;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ecommerce.Controllers
{
    [Route("api/moni")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EComContext eCommerceContext;
        public LoginController(EComContext eCommerceContext)
        {
            this.eCommerceContext = eCommerceContext;
        }

        /* [HttpPost]
         public async Task<IActionResult> PostUserDetails([FromBody] UserDetailsDTO userDetail)
         {
             var newUser = new UserDetail
             {
                 Username = userDetail.Username,
                 Password = userDetail.Password,
                 FirstName = userDetail.FirstName,
                 LastName = userDetail.LastName,
                 MembershipType = userDetail.MembershipType,
                 Role = userDetail.Role,
                 Address = userDetail.Address,
                 Phone = userDetail.Phone,
                 Email = userDetail.Email,
                 ModifiedAt = userDetail.ModifiedAt
             };

             eCommerceContext.UserDetails.Add(newUser);
             await eCommerceContext.SaveChangesAsync();

             return new JsonResult("Success");
         }*/
        [HttpGet]
        [Route("{IdOrEmail}/{value}/{Password}")]
        public async Task<IActionResult> GetByNumberOrEmail([FromRoute] string IdOrEmail, string value, string Password)
        {
            var user = value.Equals("email", StringComparison.OrdinalIgnoreCase) ?
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Email == IdOrEmail) :
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Phone == IdOrEmail);
            if (user == null)
            {
                return NotFound();
            }

            var pass = HashPassword(user.UserId.ToString(), Password);
            if (pass.Equals(user.Password)){
                return new JsonResult(user.FirstName);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet]
        [Route("{IdOrEmail}/{value}")]
        public async Task<IActionResult> VerifyNumber([FromRoute] string IdOrEmail, string value)
        {
            var user = value.Equals("email", StringComparison.OrdinalIgnoreCase) ?
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Email == IdOrEmail) :
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Phone == IdOrEmail);
            
            if (user == null)
            {
                return NotFound();
            }
            else if (IdOrEmail.Equals(user.Phone))
            {
                return new JsonResult(user.Phone);
            }
            else if (IdOrEmail.Equals(user.Email))
            {
                return new JsonResult(user.Email);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPatch("{IdOrEmail}/{value}")]
        public async Task<IActionResult> ChangePassword([FromBody] JsonPatchDocument<ChangePassDTO> changePass, [FromRoute] string IdOrEmail, string value)
        {
            var user = value.Equals("email", StringComparison.OrdinalIgnoreCase) ?
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Email == IdOrEmail) :
                await eCommerceContext.UserDetails.FirstOrDefaultAsync(u => u.Phone == IdOrEmail);

            if (user == null)
            {
                return NotFound();
            }

            var passModel = new ChangePassDTO();
            changePass.ApplyTo(passModel, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Password = HashPassword(user.UserId.ToString(),passModel.Password);
            try
            {
                await eCommerceContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the password: {ex.Message}");
            }

            return new JsonResult(200); ;
        }

        private string HashPassword(string key, string password)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Encoding.UTF8.GetBytes(password);
            using (var sha256 = SHA256.Create())
            {
                using (var hmac = new HMACSHA256(keyBytes))
                {
                    byte[] hashBytes = hmac.ComputeHash(dataBytes);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }


    }

}
