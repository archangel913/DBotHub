using Microsoft.Extensions.DependencyInjection;
using DBotHub.Domain.Bots;
using DBotHub.Application.Bots;

namespace Application.Bots;
public class BotConnectionUC
{
    private IBotConnector BotConnector { get; }

    private IBotRepository BotRepository { get; }

    private Bot? Bot { get; set; }

    public BotConnectionUC(IServiceProvider services)
    {
        this.BotRepository = services.GetRequiredService<IBotRepository>();
        this.BotConnector = services.GetRequiredService<IBotConnector>();
    }

    public async Task<bool> ConnectAsync(BotId id, string name)
    {
        var launchConfiguration = this.BotRepository.GetLaunchConfiguration(id);
        this.Bot = BotFactory.Generate(launchConfiguration, id, name, this.BotConnector);
        return await this.Bot.ConnectAsync();
    }

    public async Task<bool> DisconnectAsync()
    {
        if(this.Bot is not null)
        {
            return await this.Bot.DisconnectAsync();
        }
        return false;
    }
}
