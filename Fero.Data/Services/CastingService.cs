using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Reso.Core.Custom;
using System.Net;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fero.Data.Services
{
    public partial interface ICastingService : IBaseService<Casting>
    {
        Task<List<Casting>> GetCasting(string customerId);
        Task<List<CustomerCasting>> ShowCasting(string customerId);
        Task<List<CustomerCasting>> ShowDetailCasting(string customerId);
    }
    public partial class CastingService : BaseService<Casting>, ICastingService
    {
        private readonly IMapper _mapper;
        private readonly ICastingRepository _castingRepository;

        public CastingService(ICastingRepository castingRepository, ICustomerRepository customerRepository, IMapper mapper) : base(castingRepository)
        {
            _mapper = mapper;
            _castingRepository = castingRepository;
        }

        public async Task<List<Casting>> GetCasting(string customerId)
        {
            var customerCasting = await _castingRepository.Get(x => x.CustomerId == customerId).ToListAsync();
            if (customerCasting == null)
            {
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            }
            else
            {
                return customerCasting;
            }
        }

        public async Task<List<CustomerCasting>> ShowCasting(string customerId)
        {
            var customerCasting = await _castingRepository.Get(x => x.CustomerId == customerId)
                .Select(x => new CustomerCasting
                {
                    Salary = x.Salary,
                    Description = x.Description,
                    CustomerName = x.Customer.Name
                }).ToListAsync();
            if (customerCasting == null)
            {
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            }
            else
            {
                return customerCasting;
            }
        }

        public async Task<List<CustomerCasting>> ShowDetailCasting(string customerId)
        {
            var customerCasting = await _castingRepository.Get(x => x.CustomerId == customerId)
                .Select(x => new CustomerCasting
                {
                    Salary = x.Salary,
                    OpenTime = x.OpenTime,
                    Description = x.Description,
                    CustomerName = x.Customer.Name
                }).ToListAsync();
            if (customerCasting == null)
            {
                throw new ErrorResponse((int)HttpStatusCode.NotFound, "User not found");
            }
            else
            {
                return customerCasting;
            }
        }
    }

    public class CustomerCasting
    {
        public decimal? Salary { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OpenTime { get; set; }
        public string Description { get; set; }
    }
}
