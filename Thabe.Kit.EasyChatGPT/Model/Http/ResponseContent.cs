using Newtonsoft.Json;
using Thabe.Kit.EasyChatGPT.Model.Data;

namespace Thabe.Kit.EasyChatGPT.Model.Http;


/// <summary>
/// ChatGTP 响应内容
/// </summary>
public class ResponseContent
{
    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("choices")]
    public required IEnumerable<Choice> Choices { get; init; }
}


//{
//    "id": "chatcmpl-6vVdBFMou74rvEL0lgYbkwgBsX3o7",
//    "object": "chat.completion",
//    "created": 1679164305,
//    "model": "gpt-3.5-turbo-0301",
//    "usage": {
//        "prompt_tokens": 10,
//        "completion_tokens": 18,
//        "total_tokens": 28
//    },
//    "choices": [
//        {
//            "message": {
//                "role": "assistant",
//                "content": "\n\n您好，有什么可以帮助您的吗？"
//            },
//            "finish_reason": "stop",
//            "index": 0
//        }
//    ]
//}