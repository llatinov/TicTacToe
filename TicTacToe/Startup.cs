using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TicTacToe.Repositories;

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

        services.AddTransient<IGameRepository, GameRepository>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
    }
}
