    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Interfaces;
    using WebApplication1.Model;
    using WebApplication1.Services;
using WebApplication1.Services.users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddScoped<VerificarUsuario>(); 
    builder.Services.AddScoped<IUsers, UserRepository>();



    //inyeccion de db 

    builder.Services.AddDbContext<ContextoDB>(opctions =>
    {
        opctions.UseSqlServer(builder.Configuration.GetConnectionString("db"));
    }); 
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("local",
            builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()); 
 
                              
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("local"); 
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
