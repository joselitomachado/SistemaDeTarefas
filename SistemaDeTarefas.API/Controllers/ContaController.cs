using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaDeTarefas.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeTarefas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContaController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] LoginModel login)
    {
        if (login.Login == "admin" && login.Senha == "admin")
        {
            var token = GerarTokenJWT();
            return Ok(new { token });
        }

        return BadRequest(new { message = "Credencias inválidas. Por favor, verique seu nome de usuário e senha." });
    }

    private string GerarTokenJWT()
    {
        string chaveSecreta = "7d15ec12-c554-4e06-98ec-9a26a8262aee";

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
        var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("login", "admin"),
            new Claim("nome", "Administrador do Sistema")
        };

        var token = new JwtSecurityToken(
            issuer: "sua_empresa",
            audience: "sua_aplicacao",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credencial
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
