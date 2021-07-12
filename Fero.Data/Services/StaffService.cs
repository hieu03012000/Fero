using AutoMapper;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Fero.Data.Commons;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            return _mapper.Map<StaffViewModel>(staff);
        }
    }
}
