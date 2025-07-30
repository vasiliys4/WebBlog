using Microsoft.EntityFrameworkCore;
using PaswordHasher;
using WebBlog.Application.Interfaces;
using WebBlog.Persistance;
using WebBlog.Server.Data;
using WebBlog.Server.RepositoryModel;
using WebBlog.Server.RepositoryModel.IdentityRepository;
using WebBlog.Server.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection(nameof(JwtOption)));

// Add services to the container.

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
string? connectionUser = builder.Configuration.GetConnectionString("ConnectionUser");
builder.Services.AddDbContext<WebBlogDBContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionUser));

builder.Services.AddControllers();

builder.Services.AddScoped<IRepositoryPost, RepositoryPost>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<PostServices>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddAutoMapper(cfg => { }, typeof(DataBaseMapping));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithMethods("DELETE","POST","GET","PATCH"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("/index.html");

app.Run();