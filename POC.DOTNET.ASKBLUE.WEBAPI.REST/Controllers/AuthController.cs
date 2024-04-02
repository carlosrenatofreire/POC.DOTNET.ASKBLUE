using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using POC.ASKBLUE.LIBRARY.CORE.Controllers;
using POC.ASKBLUE.LIBRARY.CORE.Identity;
using POC.DOTNET.ASKBLUE.WEBAPI.REST.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace POC.DOTNET.ASKBLUE.WEBAPI.REST.Controllers
{
    [Route("api/identity")]
    public class AuthController : MainController
    {

        #region Variables

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructors

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        #endregion

        #region Methods Publics

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(UserRegistration userRegistration)
        {
            //return new StatusCodeResult(401); // Simulation of return status code error 401 (not authenticated)
            //return new StatusCodeResult(403); // Simulation of return status code error 403 (access denied)
            //return new StatusCodeResult(404); // Simulation of return status code error 404 (not found)
            //return new StatusCodeResult(408); // Simulation of return status code error 408 (timeout)

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (result.Succeeded)
            {
                // Send integration message to Collaborator API
                //var collaboratorResult = await RegisterCollaborator(userRegistration);

                //if (!collaboratorResult.ValidationResult.IsValid)
                //{
                //    await _userManager.DeleteAsync(user);
                //    return CustomResponse(collaboratorResult.ValidationResult);
                //}

                return CustomResponse(await GenerateJwt(userRegistration.Email));
            }

            foreach (var error in result.Errors)
            {
                AddErrorProcessing(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJwt(userLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddErrorProcessing("User temporarily blocked for invalid attempts");
                return CustomResponse();
            }

            AddErrorProcessing("Incorrect username or password");

            return CustomResponse();
        }

        #endregion

        #region Methods Private

        private async Task<UserResponseLogin> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var identityClaims = await GetClaimsUser(claims, user);
            var encodedToken = EncodeToken(identityClaims);

            return GetResponseToken(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> GetClaimsUser(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string EncodeToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidOn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours)
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            });

            return tokenHandler.WriteToken(token);
        }

        private UserResponseLogin GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            return new UserResponseLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpirationHours).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        //private async Task<ResponseMessage> RegisterCollaborator(UserRegistration userRegistration)
        //{
        //    var user = await _userManager.FindByEmailAsync(userRegistration.Email);

        //    var userRegistered = new RegisteredUserIntegrationEvent(Guid.Parse(user.Id),
        //                                                                    userRegistration.Name,
        //                                                                    userRegistration.Email,
        //                                                                    userRegistration.Nif);

        //    try
        //    {
        //        return await _bus.RequestAsync<RegisteredUserIntegrationEvent, ResponseMessage>(userRegistered);
        //    }
        //    catch
        //    {
        //        await _userManager.DeleteAsync(user);
        //        throw;
        //    }
        //}

        #endregion
    }

}
