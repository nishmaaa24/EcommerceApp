namespace EcommerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Important for production / Docker
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllers();   // keeps your attribute routes working

            // Optional: redirect root to the product list
            app.MapGet("/", () => Results.Redirect("/product"));

            app.Run();
        }
    }
}