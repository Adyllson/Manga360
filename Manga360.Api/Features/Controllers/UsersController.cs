namespace Manga360.Api.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public UsersController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration)
        {   
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        #region CreateUser
        [HttpPost("Register"), EndpointSummary("Registar um novo usuário")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserEntity model)
        {
            var user = new ApplicationUser{UserName = model.Email, Email = model.Email};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return  Ok(model);
            }
            else
            {
                return BadRequest("Usuário ou senha inválida!");
            }
        }
        #endregion

        #region Login
        [HttpPost("Login"), EndpointSummary("Fazer Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserEntity userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,isPersistent:false, lockoutOnFailure: false);
            
            if(result.Succeeded)
            {
                return BuildToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "login inválido");
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region BuildToken
        private UserToken BuildToken(UserEntity userInfo)
        {
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("nascimento", "https://www.nascimento.net"),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
        #endregion
    }
}