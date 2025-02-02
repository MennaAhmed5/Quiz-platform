using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz_platform.BL.Managers.Answers;
using Quiz_platform.BL.Managers.Questions;
using Quiz_platform.BL.Managers.Quizes;
using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.DAL.Data.Context;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.Repositories.Answers;
using Quiz_platform.DAL.Repositories.Questions;
using Quiz_platform.DAL.Repositories.Quizzes;
using Quiz_platform.DAL.UnitOfWork;
using System.Security.Claims;

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

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<QuizContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Users/AccessDenied";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
                options.AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "User");
                });              
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<IQuizManager, QuizManager>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
            builder.Services.AddScoped<IAnswerManager, AnwserManager>();
            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Login}/{id?}");

            app.Run();


        }
    }
}
