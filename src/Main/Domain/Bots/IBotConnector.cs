namespace DBotHub.Domain.Bots;
public interface IBotConnector
{
    /// <summary>
    /// 接続するメソッド
    /// </summary>
    /// <param name="config">起動構成</param>
    /// <returns>成功時: true</returns>
    public Task<bool> ConnectAsync(LaunchConfiguration config);

    /// <summary>
    /// 切断するメソッド
    /// </summary>
    /// <returns>成功時: true</returns>
    public Task<bool> DisconnectAsync();
}