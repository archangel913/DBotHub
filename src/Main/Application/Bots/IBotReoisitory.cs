using DBotHub.Domain.Bots;

namespace DBotHub.Application.Bots;
public interface IBotRepository
{
    /// <summary>
    /// すべてのボットの識別子と名前のリストを返す。
    /// </summary>
    /// <returns>すべてのボットの識別子と名前のリスト</returns>
    public List<(BotId id, string name)> FindAll();

    /// <summary>
    /// 起動構成を取得する。
    /// </summary>
    /// <param name="id">ボットの識別子</param>
    /// <returns>起動構成</returns>
    public LaunchConfiguration GetLaunchConfiguration(BotId id);

    /// <summary>
    /// ボットを削除する。
    /// </summary>
    /// <param name="id">ボットの識別子</param>
    public void Delete(BotId id);

    /// <summary>
    /// ボットの情報を更新する。
    /// </summary>
    /// <param name="bot">ボット</param>
    public void Update(Bot bot);

    /// <summary>
    /// ボットを新規作成する。
    /// </summary>
    /// <param name="name">ボットの名前</param>
    /// <param name="launchConfiguration">ボットの起動構成</param>
    public void Create(string name, LaunchConfiguration launchConfiguration);
}