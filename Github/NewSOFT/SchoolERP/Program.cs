using Microsoft.EntityFrameworkCore;
using SchoolERP.Data; // Fixes the 'SchoolContext' not found error
using SchoolERP.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// 1. ADD SERVICES TO THE CONTAINER
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SmartAssistantService>();

// CONFIGURE POSTGRESQL (Ensure your connection string name matches appsettings.json)
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. CONFIGURE THE HTTP REQUEST PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 3. DATABASE SEEDING LOGIC
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SchoolContext>();
        
        // This makes sure the DB exists before seeding
        context.Database.EnsureCreated(); 
        
        // Run the Seeder
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();