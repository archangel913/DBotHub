namespace DBotHub.Domain.Bots;
/// <summary>
/// 起動構成を持つクラス
/// </summary>
public class LaunchConfiguration
{
    /// <summary>
    /// 起動時に使うトークン
    /// </summary>
    public string Token { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="token">起動時に使うトークン</param>
    public LaunchConfiguration(string token)
    {
        this.Token = token;
    }
}

