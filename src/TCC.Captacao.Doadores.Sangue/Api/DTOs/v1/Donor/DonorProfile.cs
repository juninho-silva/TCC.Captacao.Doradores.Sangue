using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Data.Repositories.User;
using AutoMapper;
using entity = Api.Infrastructure.Data.Repositories.Donor.Entities;

namespace Api.DTOs.v1.Donor
{
    /// <summary>
    /// Classe responsavel por mapper os contratos (requests e responses) do Doador
    /// </summary>
    public class DonorProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public DonorProfile()
        {
            CreateMap<DonorRequest, DonorEntity>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(source => source.BirthDate.ToShortDateString()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<UpdateDonorRequest, DonorEntity>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(source => source.BirthDate.ToShortDateString()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // novo usuario doador
            CreateMap<DonorUserRequest, UserEntity>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email));

            CreateMap<DonorEntity, DonorResponse>();

            // request
            CreateMap<DonorFullNameRequest, entity.FullName>();
            CreateMap<DonorContactRequest, entity.Contact>();
            CreateMap<DonorAddressRequest, entity.Address>();

            // response
            CreateMap<entity.FullName, DonorFullNameResponse>();
            CreateMap<entity.Contact, DonorContactResponse>();
            CreateMap<entity.Address, DonorAddressResponse>();
        }
    }
}
