using Thabe.Kit.EasyChatGPT.Model.Data;

namespace Thabe.Kit.EasyChatGPT;


/// <summary>
/// 消息构建器
/// </summary>
public class MessageBuilder : List<Message>
{
    /// <summary>
    /// 添加一个消息
    /// </summary>
    /// <param name="role">谁说的</param>
    /// <param name="content">说什么</param>
    public MessageBuilder AddMessage(Roles role, string content)
    {
        if (string.IsNullOrWhiteSpace(content)) return this;

        Add(new() { Role = role, Content = content });

        return this;
    }

    /// <summary>
    /// 添加一个用户消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public MessageBuilder AddUserMessage(string content)
        => AddMessage(Roles.User, content);

    /// <summary>
    /// 添加一个系统消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public MessageBuilder AddSystemMessage(string content)
        => AddMessage(Roles.System, content);

    /// <summary>
    /// 添加一个助手消息
    /// </summary>
    /// <param name="content">消息内容</param>
    public MessageBuilder AddAssistantMessage(string content)
        => AddMessage(Roles.Assistant, content);
}