using Agenda.Application.Dto.DataProfile;
using Agenda.Application.Interface.IAuthRepository;
using Agenda.Infrastructure.Data;
using Agenda.Infrastructure.Repository;
using Agenda.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg3MDExMjAwIiwiaWF0IjoiMTc1NTU0NjUxOSIsImFjY291bnRfaWQiOiIwMTk4YmViODQxYmE3ZmE1OTE3MzZiODM2NzI1NWM0NyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazJ6Ym0yMTAwamZrdzFzenN3NTFnY3Y5Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.HMXF26w-M1VZDmhCi98_-7A5TFhtZxPe3g7M85zbxug58LokvzjCjwBSrUfGB88zl1S-s2l-libsd_nfvKqn6QGX7yi86NQt-xJ0ukqLwvpGDQNZvsblYU6XOiIlOk7f0GfzTiIBU0yz6Z4AsYF8ubGc3UAPByGY7ZEHWJKxDdwy8a0mtSjceceiJBfx7kkvjUJyUqFuA_HH-vBiWMiIVgAbc7uHMKcr0mLutHjH43GAHbo9nFjCVulxVU6bUTzC4_gvE4m7IDWihMHKQakvVcGORfZfjtDiihwX6OV0e9I06zW-yg34ZirU5Kvvtu3HQPfILYtRE8h1Xh6jN7-LaA", AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<TokenJwt>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));


builder.Services.AddDbContext<AgendaAppContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //options.RequireHttpsMetadata = false; // só pra dev!
      
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "AgendaApp.Securiry.Bearer",
            ValidIssuer = "AgendaApp.Securiry.Bearer",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
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
