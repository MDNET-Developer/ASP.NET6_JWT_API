using AutoMapper;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Application.Mappings;
using MD.JWTApp.Back.Infrastructure.Tool;
using MD.JWTApp.Back.Persistance.Context;
using MD.JWTApp.Back.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add JWT Confugration

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = JwtSettingsDefault.ValidIssuer,
        ValidAudience = JwtSettingsDefault.ValidAudience,
        //ValidateIssuer = true - bunu yazsaq ValidIssuer de yazdigimiz kodun yoxlanmasini tetbiq edecyeik.
        //ValidateAudience = true - bunu yazsaq ValidAudience de yazdigimiz kodun yoxlanmasini tetbiq edecyeik.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(JwtSettingsDefault.SigningKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,//Token-nin zamanini yoxlayir ki, vaxti kecibmi ya yox ?
        ClockSkew = TimeSpan.Zero, //server ile müştəri arasında gecikməni sıfır edir.
    };
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MuradJwtContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//builder.Services.AddMediatR(typeof(Program));
//Bu cur yazmaqlada oldugu yeri avtomatik almaq olar.
//Burada olann assembly c# da olan exe ve ddl fayllarinin umumi adidir. Burada umumi olaraq bu fayllar icinden bizim hal hazirda oldugumuz faylin yerini alir GetExecutingAssembly();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//builder.Services.AddAutoMapper(opt =>
//{
//    opt.AddProfile(new ProductProfile());
//    opt.AddProfile(new CategoryProfile());
//});
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {

    new ProductProfile(),
    new CategoryProfile()

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
