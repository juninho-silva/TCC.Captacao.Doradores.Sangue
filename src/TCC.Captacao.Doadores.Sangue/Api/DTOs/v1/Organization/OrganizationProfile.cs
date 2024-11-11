using Api.Infrastructure.Data.Repositories.Organization;
using Api.Infrastructure.Data.Repositories.User;
using AutoMapper;
using entity = Api.Infrastructure.Data.Repositories.Organization.Entities;

namespace Api.DTOs.v1.Organization
{
    /// <summary>
    /// Classe responsavel por mapper os contratos (requests e responses) da Organizacao (Banco de Sangue)
    /// </summary>
    public class OrganizationProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public OrganizationProfile()
        {
            CreateMap<OrganizationRequest, OrganizationEntity>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<OrgUserRequest, UserEntity>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(source => DateTime.UtcNow))
                .ForMember(dest => dest.Email, opt => opt.Ignore());

            CreateMap<OrganizationEntity, OrganizationResponse>();

            // request
            CreateMap<OrgAddressRequest, entity.Address>();
            CreateMap<OrgContactRequest, entity.Contact>();
            CreateMap<OrgOperatingHoursRequest, entity.OperatingHours>();

            // response
            CreateMap<entity.Address, OrgAddressResponse>();
            CreateMap<entity.Contact, OrgContactResponse>();
            CreateMap<entity.OperatingHours, OrgOperatingHoursResponse>();
        }
    }
}
