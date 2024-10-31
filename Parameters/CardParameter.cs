namespace Demo.WebApi.Scalar.Parameters;

/// <summary>
/// 卡片參數
/// </summary>
public class CardParameter
{
    /// <summary>
    /// 卡片名稱
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 卡片描述
    /// </summary>
    public string Description { get; set; } = string.Empty;
}