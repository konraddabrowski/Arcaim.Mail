using System.ComponentModel;
using System.Reflection;

namespace Arcaim.Mail.Enums;

public static class HtmlTemplateTypeMode
{
  public const string None = nameof(Enum.None);
  public const string Registration = nameof(Enum.Registration);
  public const string ReportPasswordReset = nameof(Enum.ReportPasswordReset);

  public enum Enum
  {
    [Description(HtmlTemplateTypeMode.None)]
    None = 0,
    [Description(HtmlTemplateTypeMode.Registration)]
    Registration,
    [Description(HtmlTemplateTypeMode.ReportPasswordReset)]
    ReportPasswordReset
  }

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