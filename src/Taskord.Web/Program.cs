using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Taskord.Data;
using Taskord.Services.Teams;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskordDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TaskordDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITeamService, TeamService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "chat",
    pattern: "chats/@me/{chat}",
    defaults: new { controller = "Chats", action = "Personal" });

app.MapControllerRoute(
    name: "chat",
    pattern: "chats/{team}/{chat}",
    defaults: new { controller = "Chats", action = "ById" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
