using Microsoft.Extensions.DependencyInjection;
using DBotHub.Domain.Bots;
using DBotHub.Application.Bots;

namespace Application.Bots;
public class BotConnectionUC
{
    private IBotConnector BotConnector { get; }

    private IBotRepository BotRepository { get; }

    private Bot? Bot { get; }

    public BotConnectionUC(IServiceProvider services)
    {
        this.BotRepository = services.GetRequiredService<IBotRepository>();
        this.BotConnector = services.GetRequiredService<IBotConnector>();
    }

    public async Task<bool> ConnectAsync(string id, string name)
    {
        
        // this.Bot = 　ファクトリーに任せる
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
