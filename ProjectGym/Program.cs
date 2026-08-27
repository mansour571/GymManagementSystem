using GymManagementSystem.DataAccess.Data.Contexts;
using GymManagementSystem.DataAccess.Data.Seeder;
using GymManagementSystem.DataAccess.InterceptorsSENTINEL;
using GymManagementSystem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IPlanRepository, PlanRepository>();
//builder.Services.AddKeyedScoped<PlanRepository>("PlanRepo");


builder.Services.AddSingleton<AuditSaveChangesInterceptor>();

builder.Services.AddDbContext<GymDbContext>((sp,options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .AddInterceptors(sp.GetRequiredService<AuditSaveChangesInterceptor>());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
} 

app.MapStaticAssets();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await using var scope = app.Services.CreateAsyncScope();

var dbContext = scope.ServiceProvider
    .GetRequiredService<GymDbContext>();

await DataBaseSeeder.SeedAllAsync(dbContext);

app.Run();
