using AutoMapper;
using Day64MiniProject.DTOs;
using Day64MiniProject.Models;

namespace Day64MiniProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAccountdto, Account>()
                .ForMember(dest => dest.Balance,
                           opt => opt.MapFrom(src => src.InitialDeposit));

            CreateMap<Account, AccountDto>();
        }
    }
}