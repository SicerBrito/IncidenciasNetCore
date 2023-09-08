using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using API.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;
public class UserService : IUserServiceInterface
{
    private readonly JWT ? _jwt;
    private readonly IUnitOfWork ? _unitOfWork;
    private readonly IPasswordHasher<Usuario> ? _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<Usuario> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var usuario = new Usuario
        {
            Email = registerDto.Email,
            Pk_IdUser = registerDto.Pk_IdUser,
        };

        usuario.Password = _passwordHasher!.HashPassword(usuario, registerDto.Password!);

        var usuarioExiste = _unitOfWork!.Usuarios!
                                            .Find(u => u.Pk_IdUser == registerDto.Pk_IdUser)
                                            .FirstOrDefault();
        
        if (usuarioExiste == null)
        {
            Rol? rolPredeterminado = null;
            try
            {
            rolPredeterminado = _unitOfWork.Roles!
                                                .Find(u => u.Pk_Id == Autorizacion.rol_predeterminado.ToString())
                                                .First();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            try
            {
                usuario.Roles!.Add(rolPredeterminado);
                _unitOfWork.Usuarios.Add(usuario);
                await _unitOfWork.SaveAsync();

                return $"El Usuario {registerDto.Pk_IdUser} ha sido registrado exitosamente";
            }

            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else{
            
            return $"El usuario con {registerDto.Pk_IdUser} ya se encuentra resgistrado.";
        }

    }

    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        Usuario? usuario = null;
        try
        {
            usuario = await _unitOfWork!.Usuarios!
                                                .GetByUsernameAsync(model.Username!);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");            
        }
        
        if (usuario == null)
        {
            return $"No exixte algun usuario registrado con la cuenta {model.Username}.";
        }

        var resultado = _passwordHasher!.VerifyHashedPassword(usuario, usuario.Password!, model.Password!);

        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles!
                                            .Find(u => u.Pk_Id!.ToLower() == model.Role!.ToLower())
                                            .FirstOrDefault();
            
            if (rolExiste !=null)
            {
                var usuarioTieneRol = usuario.Roles!
                                                .Any(u => u.Pk_Id == rolExiste.Pk_Id);
                
                if (usuarioTieneRol == false)
                {
                    usuario.Roles!.Add(rolExiste);
                    _unitOfWork.Usuarios.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }

                return $"Rol {model.Role} agregado a la cuenta {model.Username} de forma exitosa.";
            }

            return $"Rol {model.Role} no encontrado.";
        }

        return $"Credenciales incorrectas para el ususario {usuario.Pk_IdUser}.";
    }

    public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
    {
        DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
        var usuario = await _unitOfWork!.Usuarios!
                                                .GetByUsernameAsync(model.Username!);

        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningun usuario con el username {model.Username}.";
            return datosUsuarioDto;
        }

        var result = _passwordHasher!.VerifyHashedPassword(usuario, usuario.Password!, model.Password!);
        if (result == PasswordVerificationResult.Success)
        {
            datosUsuarioDto.Mensaje = "OK";
            datosUsuarioDto.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
            datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuarioDto.UserName = usuario.Nombres;
            datosUsuarioDto.Email = usuario.Email;
            //datosUsuarioDto.Token = _jwtGenerador.CrearToken(usuario);
            datosUsuarioDto.Roles = usuario.Roles!
                                                .Select(p => p.Pk_Id)
                                                .ToList()!;
           
            
            return datosUsuarioDto; 
        }

        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Pk_IdUser}.";

        return datosUsuarioDto;

    }

    // los siguientes metodos no hacen parte de la Interfaz no son necesarios

    private JwtSecurityToken CreateJwtToken(Usuario usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles!)
        {
            roleClaims.Add(new Claim("roles", role.Pk_Id!));
        }
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Nombres!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", usuario.Pk_IdUser.ToString())
        }
        .Union(roleClaims);
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt!.Key!));
        Console.WriteLine("", symmetricSecurityKey);

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var JwtSecurityToken = new JwtSecurityToken(
            issuer : _jwt.Issuer,
            audience : _jwt.Audience,
            claims : claims,
            expires : DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials : signingCredentials);

        return JwtSecurityToken;
    }

    //Editar el usuario registrado
    public async Task<Usuario> EditarUsuarioAsync(Usuario model)
    {
        Usuario usuario = new Usuario();
        usuario.Pk_IdUser = model.Pk_IdUser;
        usuario.Pk_IdUser = model.Pk_IdUser;
        usuario.Email = model.Email;
        usuario.Password = _passwordHasher!.HashPassword(usuario, model.Password!);
        _unitOfWork!.Usuarios!.Update(usuario);
        await _unitOfWork.SaveAsync();
        return usuario;
    }

    /*public async Task<LoginDto>  UserLogin(LoginDto model)
    {
        var usuario = await _unitOfWork.Usuarios.GetByUsernameAsync(model.Username);
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            return model;
        }
        return null;
    }*/




}