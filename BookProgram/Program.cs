using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookProgram.Data;
namespace BookProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookProgramContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookProgramContext") ?? throw new InvalidOperationException("Connection string 'BookProgramContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}