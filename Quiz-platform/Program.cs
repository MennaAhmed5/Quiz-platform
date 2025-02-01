using Microsoft.EntityFrameworkCore;
using Quiz_platform.BL.Managers.Questions;
using Quiz_platform.BL.Managers.Quizes;
using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.DAL.Data.Context;
using Quiz_platform.DAL.Repositories.Questions;
using Quiz_platform.DAL.Repositories.Quizzes;
using Quiz_platform.DAL.UnitOfWork;

namespace Quiz_platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("QuizDb");

            // Register Custom Services to the container.
            builder.Services.AddDbContext<QuizContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<IQuizManager, QuizManager>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();

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

            app.Run();
        }
    }
}
