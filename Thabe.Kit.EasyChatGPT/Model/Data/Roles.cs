using System.Runtime.Serialization;

namespace Thabe.Kit.EasyChatGPT.Model.Data;


/// <summary>
/// 角色
/// </summary>
public enum Roles
{
    /// <summary>
    /// 系统
    /// </summary>
    [EnumMember(Value = "system")] System,

    /// <summary>
    /// 助手
    /// </summary>
    [EnumMember(Value = "assistant")] Assistant,

    /// <summary>
    /// 用户
    /// </summary>
    [EnumMember(Value = "user")] User,
}
