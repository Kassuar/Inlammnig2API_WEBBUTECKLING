using Inlammnig2API_WEBBUTECKLING.Core.Services;
using Inlammnig2API_WEBBUTECKLING.Data;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Inlammnig2API_WEBBUTECKLING.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5234",
        ValidAudience = "http://localhost:5234",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("mykey1234567&%%485734579453%&//1255362"))
    };
});

// Dependency Injection
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// CORS
app.UseCors(options =>
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Controllers
app.MapControllers();

app.Run();
