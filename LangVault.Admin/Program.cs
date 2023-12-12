using Application;
using Application.Common.Exceptions.Filter;
using Infrastructure;
using Infrastructure.Migrations;
using LangVault.Admin;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddApplication();
    builder.Services.AddAdmin();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddMigrations(builder.Configuration);

    builder.Services.AddControllers(options => options.Filters.Add(new ApiExceptionFilter()));
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin", builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(optioins => optioins.CustomSchemaIds(type => type.ToString()));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowOrigin");
    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{

}
finally
{

}