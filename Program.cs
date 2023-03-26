using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using Project.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ass2_PRN221Context") ?? throw 
    new InvalidOperationException("Connection string 'Ass2_PRN221Context' not found.")));
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProjectContext>();
    context.Database.EnsureCreated();
    
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapHub<SignalrServer>("/SignalrServer");
app.Map("/Admin", (app1) =>
{
    app1.UseStaticFiles();
    app1.Use(async (context, next) =>
    {
        // Do work that can write to the Response.
            var acc = context.Session.GetString("account") ?? "";
            Console.WriteLine(acc);
            if (String.IsNullOrEmpty(acc.ToLower()))
            {
                Console.WriteLine("Cannot find acc");
        }
        else
        {
            await next.Invoke();
        }


        // Do logging or other work that doesn't write to the Response.
    });
    // Execute the endpoint selected by the routing middleware
    app1.UseEndpoints(endpoints =>
        {
        endpoints.MapDefaultControllerRoute();
    });
});

app.Map("/Staff", (app1) =>
{
    app1.UseStaticFiles();
    app1.Use(async (context, next) =>
    {
        // Do work that can write to the Response.
            var acc = context.Session.GetString("account") ?? "";
            Console.WriteLine(acc);
            if (String.IsNullOrEmpty(acc.ToLower()))
            {
                Console.WriteLine("Cannot find acc");
        }
        else
            {
            await next.Invoke();
            }


        // Do logging or other work that doesn't write to the Response.
    });
    // Execute the endpoint selected by the routing middleware
    app1.UseEndpoints(endpoints =>
        {
        endpoints.MapDefaultControllerRoute();
    });
});

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=GetProducts}");
app.Run();
