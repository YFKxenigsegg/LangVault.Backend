using LangVault.Management.Application.Constructs.Commands;

namespace LangVault.Management.Application.Constructs;
public partial class ConstructInfo
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Construct, ConstructInfo>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations.Select(x => x.Value)))
            .ReverseMap()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedUtc, opt => opt.Ignore());

        profile.CreateMap<string, Translation>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

        profile.CreateMap<CreateRequest, Construct>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, Construct>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, ConstructInfo>();
    }
}
