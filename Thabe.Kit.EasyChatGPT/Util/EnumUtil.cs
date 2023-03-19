using System.Reflection;
using System.Runtime.Serialization;

namespace Thabe.Kit.EasyChatGPT.Util;


/// <summary>
/// 枚举帮助类
/// </summary>
public static class EnumUtil
{
    /// <summary>
    /// 获取枚举成员上的EnumMemberAttribute特性中Value的值
    /// </summary>
    public static string? GetEnumMemberValue(this Enum value)
    {
        try
        {
            //获取枚举成员
            var member = value.GetType().GetMember(value.ToString()).First();

            //获取成员上的EnumMemberAttribute特性中Value的值
            return member.GetCustomAttribute<EnumMemberAttribute>()?.Value;
        }
        catch
        {
            return null;
        }
    }
}
