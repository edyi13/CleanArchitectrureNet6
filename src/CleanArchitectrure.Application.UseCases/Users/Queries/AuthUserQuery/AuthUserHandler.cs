using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Application.UseCases.Commons.Bases;
using CleanArchitectrure.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.AuthUserQuery
{
    public class AuthUserHandler : IRequestHandler<AuthUserQuery, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthUserHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<BaseResponse<string>> Handle(AuthUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();
            try
            {
                var user = await _unitOfWork.Users.GetAsync(request.Client);
                if (user is not null)
                {
                    if (BC.Verify(request.Secret, user.Secret))
                    {
                        response.Data = GenerateToken(user);
                        response.Success = true;
                        response.Message = "Token Exitoso";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Abbreviation),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Company),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Client),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["jwt:Issuer"],
                audience: _configuration["jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

