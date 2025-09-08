var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap["guid"] = typeof(AdvancedRoutingDemo.Helpers.GuidConstraint);
});


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    // Complex route: Products
    endpoints.MapControllerRoute(
        name: "productRoute",
        pattern: "Products/{category}/{id:int}",
        defaults: new { controller = "Products", action = "Details" });

    // Complex route: Users
    endpoints.MapControllerRoute(
        name: "userOrders",
        pattern: "Users/{username}/Orders",
        defaults: new { controller = "Users", action = "Orders" });

    // Default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "guidRoute",
    pattern: "Products/Details/{id:guid}",
    defaults: new { controller = "Products", action = "ByGuid" });

});


app.Run();



