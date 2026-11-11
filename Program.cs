using Company.Data;
using Company.Mapping;
using Company.Services;
using CompanyWebApp.Mapping;
using CompanyWebApp.Middleware;
using CompanyWebApp.Services.Company;
using CompanyWebApp.Services.Depatment;
using CompanyWebApp.Services.Employee;
using CompanyWebApp.Services.LeaveRequest;
using CompanyWebApp.Services.Position;
using CompanyWebApp.Services.Role;
using CompanyWebApp.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.ParameterLocation.Header,
            Description = "Enter your JWT access token."
        });

    options.AddSecurityRequirement(document => new()
    {
        [new Microsoft.OpenApi.OpenApiSecuritySchemeReference(
            "Bearer", document)] = new List<string>()
    });
});
builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<EmployeeProfile>();
});

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CompanyProfile>();
});
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<DepartmentProfile>();
});

builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<LeaveRequestProfile>();
});

builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PositionProfile>();
});

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RoleProfile>();
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserProfile>();
});

builder.Services.AddScoped<
    IPasswordHasher<Users>,
    PasswordHasher<Users>>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();