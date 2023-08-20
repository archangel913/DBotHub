using System.Reflection;
using DBotHub.Domain.Bots;
using Discord;
using Discord.WebSocket;

namespace Experimental;
public class Program
{
    static async Task Main()
    {
        var tokenNullable = GetExperimentalBotToken() ?? throw new Exception();

        var config = new LaunchConfiguration(tokenNullable);
        var bot = new Bot(config, new BotId(Guid.NewGuid()), "sunrise fucking old man", new DiscordConnector());
        var connectOk = await bot.ConnectAsync();
        if (connectOk)
        {
            Console.WriteLine("接続にせいこうしました。");
        }
        else
        {
            Console.WriteLine("接続に失敗しました。");
        }

        await Task.Delay(10000);

        var disconnectOk = await bot.DisconnectAsync();
        if (disconnectOk)
        {
            Console.WriteLine("切断にせいこうしました。");
        }
        else
        {
            Console.WriteLine("切断に失敗しました。");
        }
    }


    private static string? GetExperimentalBotToken() => Environment.GetEnvironmentVariable("EXPERIMENTAL_DISCORD_BOT_TOKEN", EnvironmentVariableTarget.User);
}

public class DiscordConnector : IBotConnector
{
    private DiscordSocketClient Client { get; } = new DiscordSocketClient();

    public DiscordConnector()
    {
        this.Client.Log += WriteLog;
    }

    public async Task<bool> ConnectAsync(LaunchConfiguration config)
    {
        try
        {
            await this.Client.LoginAsync(Discord.TokenType.Bot, config.Token);
            await this.Client.StartAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        return true;
    }

    public async Task<bool> DisconnectAsync()
    {
        try
        {
            await this.Client.StopAsync();
            await this.Client.LogoutAsync();
            this.Client.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        return true;
    }

    private Task WriteLog(LogMessage message)
    {
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
}