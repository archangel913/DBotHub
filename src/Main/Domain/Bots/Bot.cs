namespace DBotHub.Domain.Bots;
/// <summary>
/// ボットの接続、切断を管理するクラス
/// </summary>
public class Bot
{
    /// <summary>
    /// ボットを接続、切断するためのオブジェクト
    /// </summary>
    private IBotConnector BotConnector { get; }

    /// <summary>
    /// 起動構成
    /// </summary>
    private LaunchConfiguration LaunchConfiguration { get; }

    /// <summary>
    /// ボットの内部的な識別子
    /// </summary>
    public BotId Id { get; }

    /// <summary>
    /// ボットの名前
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// コンストラクタ<br/>
    /// 接続する直前にインスタンス化すること。(インスタンス化時は不変にしたい。)
    /// </summary>
    /// <param name="launchConfiguration">起動構成</param>
    /// <param name="id">ボットの識別子</param>
    /// <param name="name">ボットの名前</param>
    /// <param name="connector">実際に接続するための処理を持つオブジェクト</param>
    public Bot(LaunchConfiguration launchConfiguration, BotId id, string name, IBotConnector connector)
    {
        this.LaunchConfiguration = launchConfiguration;
        this.Id = id;
        this.Name = name;
        this.BotConnector = connector;
    }

    /// <summary>
    /// 接続するメソッド。
    /// </summary>
    /// <returns>成功時: true</returns>
    public async Task<bool> ConnectAsync()
    {
        return await this.BotConnector.ConnectAsync(this.LaunchConfiguration);
    }

    /// <summary>
    /// 切断するメソッド。
    /// </summary>
    /// <returns>成功時: true</returns>
    public async Task<bool> DisconnectAsync()
    {
        return await this.BotConnector.DisconnectAsync();
    }

    /// <summary>
    /// 再接続する。
    /// </summary>
    /// <returns>タスク</returns>
    public async Task<bool> ReconnectAsync()
    {
        var result = await DisconnectAsync();
        result &= await ConnectAsync();
        return result;
    }
}
