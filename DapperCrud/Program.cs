using DataAccess.Config;
using DataAccess.ConnectionFabrics;
using DataAccess.Contexts;
using DataAccess.Repositories.Authors;
using DataAccess.Repositories.Books;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<DbConfiguration>(x => new DbConfiguration()
    {
        ConnectionString = builder.Configuration.GetConnectionString("BookWikiConnection")
    });

builder.Services.AddScoped<IDbConnectionFabric, SqlConnectionFabric>();

builder.Services.AddScoped<DataAccessContext>();
builder.Services.AddScoped<IDataAccessContext>(x => x.GetService<DataAccessContext>());
builder.Services.AddScoped<IConnectionManager>(x => x.GetService<DataAccessContext>());

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
