using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TicTacToe.Repositories;
using TicTacToe.Services;

namespace TicTacToe;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddMvcOptions(o => o.EnableEndpointRouting = false)
            .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IGameValidator, GameValidator>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
    }
}
