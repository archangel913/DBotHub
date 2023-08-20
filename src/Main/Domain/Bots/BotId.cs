namespace DBotHub.Domain.Bots;
public class BotId
{
    /// <summary>
    /// 識別子
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">識別子</param>
    public BotId(Guid value)
    {
        this.Value = value;
    }
}
