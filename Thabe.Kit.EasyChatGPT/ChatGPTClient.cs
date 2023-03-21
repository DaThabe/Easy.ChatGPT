using Flurl.Http;
using Thabe.Kit.EasyChatGPT.Model;
using Thabe.Kit.EasyChatGPT.Model.Data;
using Thabe.Kit.EasyChatGPT.Model.Http;
using Thabe.Kit.EasyChatGPT.Util;

namespace Thabe.Kit.EasyChatGPT;



/// <summary>
/// ChatGPT 3.5 Turbo API 调用<br/>
/// <a href="https://platform.openai.com/docs/api-reference/chat/create">官方 API 调用教程</a>
/// </summary>
public class ChatGPTClient
{
    /// <summary>
    /// Api host
    /// </summary>
    private static readonly string _API_HOST = "https://api.openai.com/v1/chat/completions";

    /// <summary>
    /// 使用Flurl库发送请求
    /// </summary>
    private readonly IFlurlRequest _flurlRequest;


    /// <summary>
    /// 语言模型
    /// </summary>
    public string ModelName { get; private set; }

    /// <summary>
    /// 请求超时时常 默认30秒
    /// </summary>
    public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(30);


    /// <summary>
    /// 初始化ChatGPT客户端
    /// </summary>
    /// <param name="apiKey">api key</param>
    public ChatGPTClient(string apiKey, ModelVersion model = ModelVersion.GPT_3_5_TURBO)
    {
        ModelName = model.GetEnumMemberValue()
            ?? throw new ArgumentException("模型名称错误", nameof(model));


        _flurlRequest = _API_HOST
            .WithHeader("Authorization", $"Bearer {apiKey}")
            .WithHeader("Content-Type", "application/json");
    }


    /// <summary>
    /// 发送一些消息并获取助手回复
    /// </summary>
    /// <param name="msgs">消息内容</param>
    public async Task<string> SendMessagesAsync(IEnumerable<Message> msgs)
    {
        RequestContent data = new() { Messages = msgs, Model = ModelName };
        var resp = await Request(data);

        return resp.Choices.First().Message.Content;
    }

    /// <summary>
    /// 发送一个消息并获取助手回复
    /// </summary>
    /// <param name="content">消息内容</param>
    public async Task<string> SendMessageAsync(string content, Roles role)
        => await SendMessagesAsync(new Message[] { new() { Content = content, Role = role } });

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="data">请求内容</param>
    private async Task<ResponseContent> Request(RequestContent data)
    {
        var resp = await _flurlRequest
            .WithTimeout(Timeout)
            .PostJsonAsync(data);

        return await resp.GetJsonAsync<ResponseContent>();
    }
}