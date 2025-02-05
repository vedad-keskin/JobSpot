using System.Text;
using api.Models;
using api.Services.CategoryService;
using api.Services.CityService;
using api.Services.CountryService;
using api.Services.EmailService;
using api.Services.ListingTypeService;
using api.Services.PostingService;
using api.Services.UserServices;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
Env.Load($".env.{env}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    string key = Environment.GetEnvironmentVariable("jwt_secret") ?? "";
    byte[] keyBytes = Encoding.ASCII.GetBytes(key);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin",policy =>
    {
        policy.RequireClaim("isAdmin","True");
    });
});



builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<ICityService,CityService>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ITypeService,TypeService>();
builder.Services.AddScoped<IPostingService,PostingService>();




var dbConnString = Environment.GetEnvironmentVariable("db_connection_string");
builder.Services.AddDbContext<DBContext>(opts => opts.UseSqlServer(dbConnString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

