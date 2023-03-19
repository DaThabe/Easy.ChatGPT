using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Thabe.Kit.EasyChatGPT.Model.Data;

/// <summary>
/// 消息内容
/// </summary>
public class Message
{
    /// <summary>
    /// 消息所属角色
    /// </summary>
    [JsonProperty("role")]
    [JsonConverter(typeof(StringEnumConverter))]
    public required Roles Role { get; init; }


    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("content")]
    public required string Content { get; init; }
}