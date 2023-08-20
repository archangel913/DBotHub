namespace DBotHub.Domain.Bots;
public static class BotFactory
{
    public static Bot Generate(LaunchConfiguration config, BotId id, string name, IBotConnector conn)
    {
        return new Bot(config, id, name, conn);
    }
}
