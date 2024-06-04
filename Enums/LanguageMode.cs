using System.ComponentModel;
using System.Reflection;

namespace Arcaim.Mail.Enums;

public static class LanguageMode
{
    public const string None = nameof(Enum.None);
    public const string EnUs = "en-US";
    public const string Pl = "pl";

    public enum Enum
    {
        [Description(LanguageMode.None)]
        None = 0,
        [Description(LanguageMode.EnUs)]
        EnUs,
        [Description(LanguageMode.Pl)]
        Pl
    }

    public static string ValueOf(int value) => ValueOf((Enum)value);

    public static string ValueOf(Enum value)
    {
        return value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description ?? value.ToString();
    }
}