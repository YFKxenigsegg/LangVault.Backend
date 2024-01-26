using LangVault.Management.Application.Words.Commands;

namespace LangVault.Management.Application.Words;
public partial class WordInfo
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Word, WordInfo>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations.Select(x => x.Value)))
            .ReverseMap()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedUtc, opt => opt.Ignore());

        profile.CreateMap<string, Translation>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));

        profile.CreateMap<CreateRequest, Word>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, Word>()
            .IgnoreAllMembers()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        profile.CreateMap<UpdateRequest, WordInfo>();
    }
}
