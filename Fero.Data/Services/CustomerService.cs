using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Fero.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Reso.Core.Custom;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface ICustomerService:IBaseService<Customer>
    {
        Task<CustomerProfileViewModel> GetCustomerById(string customerId);
        Task<UpdateCustomerViewModel> UpdateCustomer(string customerId, UpdateCustomerViewModel updateProfile);
        Task<IQueryable<GetCastingViewModel>> GetCasting(string customerId);
    }
    public partial class CustomerService:BaseService<Customer>,ICustomerService
    {
        private readonly ICastingRepository _castingRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper,
            ICastingRepository castingRepository) : base(customerRepository)
        {
            _castingRepository = castingRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetCastingViewModel>> GetCasting(string customerId)
        {
            if(await Get(x => x.Id == customerId).FirstOrDefaultAsync() == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not found");
            var customerCasting = _castingRepository.Get(x => x.CustomerId == customerId)
                .ProjectTo<GetCastingViewModel>(_mapper.ConfigurationProvider);
            if (customerCasting == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "Not have casting");
            return customerCasting;
        }

        public async Task<CustomerProfileViewModel> GetCustomerById(string customerId)
        {
            var customer = await Get(x => x.Id == customerId).FirstOrDefaultAsync();
            if (customer == null)
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            return _mapper.Map<CustomerProfileViewModel>(customer);
        }

        public async Task<UpdateCustomerViewModel> UpdateCustomer(string customerId, UpdateCustomerViewModel updateProfile)
        {
            if (_mapper.Map<UpdateCustomerViewModel>(await GetAsyn(customerId)) == null)
                throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            var customer = await Get(x => x.Id == customerId).FirstOrDefaultAsync();
            customer = _mapper.Map(updateProfile, customer);
            await UpdateAsync(customer);
            return updateProfile;
        }

         
    }
}
