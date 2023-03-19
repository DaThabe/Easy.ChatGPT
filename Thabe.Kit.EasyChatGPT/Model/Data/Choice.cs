using Newtonsoft.Json;

namespace Thabe.Kit.EasyChatGPT.Model.Data;


/// <summary>
/// 响应选择?
/// </summary>
public class Choice
{
    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("message")]
    public required Message Message { get; init; }


    /// <summary>
    /// 消息结束原因
    /// </summary>
    [JsonProperty("finish_reasons")]
    public required FinishReasons FinishReasons { get; init; }
}
