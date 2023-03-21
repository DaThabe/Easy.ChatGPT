using Thabe.Kit.EasyChatGPT;
using Thabe.Kit.EasyChatGPT.Model.Data;

namespace Thabe.Kit.EasyChatGPT;



/// <summary>
/// 使用
/// </summary>
public class ChatScene
{
    /// <summary>
    /// ChatGPT 客户端实例
    /// </summary>
    private readonly ChatGPTClient _chatGPTClient;

    /// <summary>
    /// 消息缓存
    /// </summary>
    private readonly MessageBuilder _messageBuilder = new();


    /// <summary>
    /// 创建一个对话情景
    /// </summary>
    /// <param name="client">ChatGPT客户端实例</param>
    public ChatScene(ChatGPTClient client)
        => _chatGPTClient = client;


    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="messageEditor">消息编辑</param>
    public async Task<string> SendMessageAsync(Action<MessageBuilder> messageEditor)
    {
        messageEditor.Invoke(_messageBuilder);

        var assistant_message = await _chatGPTClient.SendMessagesAsync(_messageBuilder);

        //添加助手消息
        _messageBuilder.AddAssistantMessage(assistant_message);

        return assistant_message;
    }

    /// <summary>
    /// 发送用户消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public async Task<string> SendUserMessageAsync(string content)
        => await SendMessageAsync(x => x.AddUserMessage(content));

    /// <summary>
    /// 发送系统消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public async Task<string> SendSystemMessageAsync(string content)
        => await SendMessageAsync(x => x.AddSystemMessage(content));

    /// <summary>
    /// 发送助手消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public async Task<string> SendAssistantMessageAsync(string content)
        => await SendMessageAsync(x => x.AddAssistantMessage(content));
}
