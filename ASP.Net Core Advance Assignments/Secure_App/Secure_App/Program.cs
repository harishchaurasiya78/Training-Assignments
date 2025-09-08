using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SecureApp.Data;


var builder = WebApplication.CreateBuilder(args);


// Add services
builder.Services.AddControllers();


// DbContext (reads connection string from configuration)
var conn = builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new InvalidOperationException("Missing connection string");


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(conn));


// JWT Auth
var jwtKey = builder.Configuration["Jwt:Key"] ?? string.Empty;
if (string.IsNullOrEmpty(jwtKey))
{
// In dev it's okay; in prod throw or require Key Vault
}


builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
options.RequireHttpsMetadata = true;
options.SaveToken = true;
options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateIssuerSigningKey = true,
ValidIssuer = builder.Configuration["Jwt:Issuer"],
ValidAudience = builder.Configuration["Jwt:Audience"],
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
};
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Middleware
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.UseSwagger();
app.UseSwaggerUI();


app.Run();