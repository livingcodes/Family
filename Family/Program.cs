var builder = WebApplication.CreateBuilder(args);
var svc = builder.Services;
svc.AddRazorPages();
svc.AddScoped<Family.Data.Db>();

var app = builder.Build();
if (!app.Environment.IsDevelopment()) {
   app.UseExceptionHandler("/error");
   app.UseHsts();
}
app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseAuthorization()
   .UseRouting()
   .UseEndpoints(x => { x.MapControllers(); x.MapRazorPages(); });
app.Run();