using AutoMapper;
using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.UseCases.Commons.Mappings
{
    public class CustomerMapper: Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
