using AutoMapper;
using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using Reso.Core.Custom;
using System.Net;
using System.Threading.Tasks;

namespace Fero.Data.Services
{
    public partial interface ICustomerService:IBaseService<Customer>
    {
    }
    public partial class CustomerService:BaseService<Customer>,ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> GetCustomerById(string customerId)
        {
            var customer = await Get(x => x.Id == customerId).FirstOrDefaultAsync();
            if (customer == null)
            {
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            }
            else
            {
                return customer;
            }  
        }

        public async Task<Customer> UpdateCustomer(string customerId, Customer updateProfile)
        {
            //if (await GetAsyn(updateProfile.Id) == null)
            //    throw new ErrorResponse((int)HttpStatusCode.BadRequest, "Not found");
            // var customer = await Get(x => x.Id == customerId).FirstOrDefaultAsync();
            await UpdateAsync(updateProfile);
            return updateProfile;
        }


    }
}
