using System.Runtime.Serialization;

namespace Thabe.Kit.EasyChatGPT.Model;


/// <summary>
/// 语言模型版本
/// </summary>
public enum ModelVersion
{
    /// <summary>
    /// "gpt-3.5-turbo"
    /// </summary>
    [EnumMember(Value = "gpt-3.5-turbo")]  GPT_3_5_TURBO
}
