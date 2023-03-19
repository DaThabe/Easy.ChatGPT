using System.Runtime.Serialization;

namespace Thabe.Kit.EasyChatGPT.Model.Data;



/// <summary>
/// 结束原因
/// </summary>
public enum FinishReasons
{
    /// <summary>
    /// API 返回完整的模型输出
    /// </summary>
    [EnumMember(Value = "stop")]  Stop,

    /// <summary>
    /// 由于<a href="https://platform.openai.com/docs/api-reference/chat/create#chat/create-max_tokens"> max_tokens参数</a>或令牌限制，模型输出不完整
    /// </summary>

    [EnumMember(Value = "length")]  Length,

    /// <summary>
    /// 内容过滤器中的标记而省略了内容
    /// </summary>
    [EnumMember(Value = "content_filter")] ContentFilter,

    /// <summary>
    /// API 响应仍在进行中或不完整
    /// </summary>
    [EnumMember(Value = "null")] Null
}
