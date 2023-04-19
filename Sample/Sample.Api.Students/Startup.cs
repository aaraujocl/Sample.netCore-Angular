using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sample.Application.Student.Commands.Create;
using Sample.Repository;
using System.Reflection;
using MediatR;
using Sample.Core.Domain;
using AutoMapper;
using Sample.Api.Students.Services;
using Sample.Application.Behavior;
using FluentValidation;
using Sample.Application.Student.Commands.Query.GetStudent;
using Sample.Application.Student.Commands.Query.GetStudents;
using Sample.Repository.Domain;
using Sample.Application.User.Commands.Query;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Student.Commands.Update;
using Sample.Application.Student.Commands.Delete;

namespace Sample.Api.Students
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddControllers();

            // Add Cors
            services.AddCors(o => o.AddPolicy("AccessPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

    
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //DB Config
            services.AddDbContext<ContextDB>(
                options =>
                {
                    options.UseSqlite(Configuration.GetConnectionString("CleanArchConnectionString"));
                }
            );
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStudentCommand).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<CreateStudentValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateStudentCommand).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<UpdateStudentValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteStudentCommand).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<DeleteStudentValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetStudentValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetStudentsValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetUserValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.Api.Students", Version = "v1" });
            });

            services.AddScoped<IStudentCommandRepository, StudentCommandRepository>();
            services.AddScoped<IStudentQueryRepository, StudentQueryRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        }

   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.Api.Students v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AccessPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
