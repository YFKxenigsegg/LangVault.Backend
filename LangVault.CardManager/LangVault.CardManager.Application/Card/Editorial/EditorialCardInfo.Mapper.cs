using LangVault.CardManager.Application.Card.Editorial.Commands;

namespace LangVault.CardManager.Application.Card.Editorial;
public partial class EditorialCardInfo
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<EditorialCard, EditorialCardInfo>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations.Select(x => x.Value)))
            .ReverseMap()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedUtc, opt => opt.Ignore());

        profile.CreateMap<string, Translation>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

        profile.CreateMap<CreateRequest, EditorialCard>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, EditorialCardInfo>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, EditorialCardInfo>();
    }
}
