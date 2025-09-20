using _23WebC_Nhom4.Middleware;

namespace _23WebC_Nhom4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Configuration.AddJsonFile("myappsetting.json", optional: false, reloadOnChange: true); //add file myappsetting.json vào

            // Lấy section "myAppSettings"
            builder.Services.Configure<MyAppSetting>
                (builder.Configuration.GetSection("MyAppSettings"));
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

            app.UseMiddleware<RequestLog>(); // Thêm middleware RequestLog
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapGet("/", (IConfiguration config) =>
            {
                var maxFileSize = config["MyAppSettings:MaxFileSize"];
                return $"MaxFileSize = {maxFileSize}"; //in ra man hinh max file size
            });
app.Run();

            app.Run();
        }
    }
}
