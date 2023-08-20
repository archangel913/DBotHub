using DBotHub.Domain.Bots;

namespace DBotHub.TestDomain.Bots;
public class TestBot 
{
    /// <summary>
    /// モックオブジェクト
    /// </summary>
    private class Connector : IBotConnector
    {
        public Task<bool> ConnectAsync(LaunchConfiguration config)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DisconnectAsync()
        {
            return Task.FromResult(true);
        }
    }

    [Fact(DisplayName = "Connectorを使って接続されるかのテスト")]
    public async Task TestConnectAsync()
    {
        var bot = new Bot(new LaunchConfiguration("token"), new BotId(Guid.NewGuid()), "sunrise fucking old man", new Connector());
        Assert.True(await bot.ConnectAsync());
    }

    [Fact(DisplayName = "Connectorを使って切断されるかのテスト")]
    public async Task TestDisconnect()
    {
        var bot = new Bot(new LaunchConfiguration("token"), new BotId(Guid.NewGuid()), "sunrise fucking old man", new Connector());
        Assert.True(await bot.DisconnectAsync());
    }

    [Fact(DisplayName = "Connectorを使って再接続されるかのテスト")]
    public async Task TestReconnect()
    {
        var bot = new Bot(new LaunchConfiguration("token"), new BotId(Guid.NewGuid()), "sunrise fucking old man", new Connector());
        Assert.True(await bot.ReconnectAsync());
    }
}