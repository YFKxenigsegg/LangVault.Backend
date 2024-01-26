namespace LangVault.Management.Tests;
public class AutoMapperTests
{
    [Test]
    public void Should_Mapper_ConfigurationValid()
    {
        var mapper = new Mapper(new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
            config.Internal().AllowAdditiveTypeMapCreation = true;
        }));

        var act = () => mapper.ConfigurationProvider.AssertConfigurationIsValid();

        act.Should().NotThrow();
    }
}
