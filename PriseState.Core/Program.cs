using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Interfaces;
using PriceState.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddDbContext < DataContext > (options => options.UseNpgsql("Host=localhost;Port=5432;Database=PriceState;Username=postgres;Password=123"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7275",
                    "http://www.contoso.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Service Injected

builder.Services.AddScoped < IFullProductService, FullProductService > ();
builder.Services.AddScoped < IOrganizationService, OrganizationService > ();
builder.Services.AddScoped < IPriceOrganizationService, PriceOrganizationService > ();
builder.Services.AddScoped < IUserService, UserService > ();
builder.Services.AddScoped < IUnitService, UnitService > ();
builder.Services.AddScoped < IProductGroupService, ProductGroupService > ();
builder.Services.AddScoped < IProductService, ProductService > ();
builder.Services.AddScoped < IRegionService, RegionService > ();
builder.Services.AddScoped < IProductTypeService, ProductTypeService > ();


#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(x => { x.SerializeAsV2 = true; });
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //x.RoutePrefix = "atashol";
    });

}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();