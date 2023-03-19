using Newtonsoft.Json;
using Thabe.Kit.EasyChatGPT.Model.Data;

namespace Thabe.Kit.EasyChatGPT.Model.Http;


/// <summary>
///  ChatGTP 请求内容
/// </summary>
public class RequestContent
{
    /// <summary>
    /// 语言模型
    /// </summary>
    [JsonProperty("model")]
    public required string Model { get; init; }


    /// <summary>
    /// 消息列表
    /// </summary>
    [JsonProperty("messages")]
    public required IEnumerable<Message> Messages { get; init; }
}