using System.Data;
using TesteProjetoBack.Infrastructure.Data;
using ApplicationProjetoBack.Interfaces;
using ApplicationProjetoBack.Services;
using DomainProjetoBack.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddScoped<IDbConnection>(provider =>
        {
            var connectionString = Configuration.GetConnectionString("ConnectionDb");
            return new SqlConnection(connectionString);
        });

        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddScoped<IAlunoService, AlunoService>();
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ICursoService, CursoService>();
        services.AddScoped<ITurmaRepository, TurmaRepository>();
        services.AddScoped<ITurmaService, TurmaService>();
        services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
        services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Projeto Back", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Projeto Back");
        });


    }
}
