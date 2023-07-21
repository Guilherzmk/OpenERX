using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenERX.Core.Customers;
using OpenERX.Core.Profiles;
using OpenERX.Core.SignIns;
using OpenERX.Core.Users;
using OpenERX.Repositories.Customers;
using OpenERX.Repositories.Shared.Entities.Addresses;
using OpenERX.Repositories.Shared.Entities.Emails;
using OpenERX.Repositories.Shared.Entities.Fields;
using OpenERX.Repositories.Shared.Entities.Phones;
using OpenERX.Repositories.Shared.Entities.Profiles;
using OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths;
using OpenERX.Repositories.Shared.Entities.Sites;
using OpenERX.Repositories.Shared.Sql;
using OpenERX.Repositories.SignIns;
using OpenERX.Repositories.Users;
using OpenERX.Services.Credentials;
using OpenERX.Services.Customers;
using OpenERX.Services.Profiles;
using OpenERX.Services.SignIns;
using OpenERX.Services.Users;
using OpenERX.WebAPI.Credentials;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.IncludeXmlComments(xmlPath);

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                    }
                });
});
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=DESKTOP-UJHJIPK\\SQLEXPRESS;database=db_openerx;user=sa;password=123456"));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IEmailRepository, EmailRepository>();
builder.Services.AddTransient<IPhoneRepository, PhoneRepository>();
builder.Services.AddTransient<ISiteRepository, SiteRepository>();
builder.Services.AddTransient<IFieldsRepository, FieldsRepository>();
builder.Services.AddTransient<IProfileAuthRepository, ProfileAuthRepository>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddTransient<ISignInService, SignInService>();
builder.Services.AddTransient<ISignInRepository, SignInRepository>();
builder.Services.AddTransient<ICredentialService, CredentialService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProfileService, ProfileService>();


var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
 
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints
        .MapControllers()
        .RequireAuthorization();
});
 
app.Run();
