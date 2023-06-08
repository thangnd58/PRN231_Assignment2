using AutoMapper;
using BookStoreAPI.BLL;
using BookStoreAPI.DAL;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BookStoreAPI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllers();
            builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100).AddRouteComponents("odata", GetEdmModel()));
            builder.Services.AddCors(
                    p => p.AddPolicy("MyCors", build =>
                    {
                        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                    })
                );
            builder.Services.AddEndpointsApiExplorer();//
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<BookStoreContext>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();//
            app.UseCors("MyCors");
            app.Run();
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var entitySet1 = builder.EntitySet<Publisher>("Publisher");
            entitySet1.EntityType.HasKey(entity => entity.PubId);
            var entitySet2 = builder.EntitySet<Author>("Author");
            entitySet2.EntityType.HasKey(entity => entity.AuthorId);
            var entitySet3 = builder.EntitySet<Book>("Book");
            entitySet3.EntityType.HasKey(entity => entity.BookId);
            return builder.GetEdmModel();
        }
    }

    
}