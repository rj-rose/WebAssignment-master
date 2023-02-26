using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Areas.Identity.Data;
using WebAssignment.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebAssignmentContextConnection") ?? throw new InvalidOperationException("Connection string 'WebAssignmentContextConnection' not found.");

builder.Services.AddDbContext<WebAssignmentContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WebAssignmentUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebAssignmentContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:Identity}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "item",
      pattern: "{controller=Item}/{action=Index}/{id?}");

});
app.Run();
