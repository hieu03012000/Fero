using AutoMapper;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Fero.Data.Commons;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fero.Data.Services
{
    public partial interface IStaffService:IBaseService<Staff>
    {
        Task<StaffViewModel> LoginStaff(string mail, string pass);
    }
    public partial class StaffService:BaseService<Staff>,IStaffService
    {
        IMapper _mapper;
        public StaffService(IStaffRepository repository,
            IMapper mapper):base(repository)
        {
            _mapper = mapper;
        }

        public async Task<StaffViewModel> LoginStaff(string mail, string pass)
        {
            string hashPass = Encryptor.MD5Hash(pass);
            var staff = await Get(s => s.Email == mail && s.Password == hashPass).FirstOrDefaultAsync();
            if (staff == null) return null;
            var dto = _mapper.Map<StaffViewModel>(staff);
            var authToken = GenerateJWTToken(staff);
            dto.AuthToken = authToken;
            return dto;
        }

        private string GenerateJWTToken(Staff entity)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.Role, "staff"),
                    new Claim("StaffId", entity.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constant.SECRECT_KEY));
            var token = new JwtSecurityToken(
                issuer: Constant.ISSUE_KEY,
                audience: Constant.ISSUE_KEY,
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
