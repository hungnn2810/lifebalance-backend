using System.Text.RegularExpressions;

namespace LifeBalance.Application.SharedKernel.Models;

public static partial class StringRegex
{
    public static readonly Regex EMAIL_REGEX = EmailRegex();

    [GeneratedRegex(@"^(?=.{1,250}@)[a-zA-Z0-9](?:(?:\.|_|-)?[a-zA-Z0-9])*@(?=.{1,250}$)[a-zA-Z0-9](?:(?:\.|-)?[a-zA-Z0-9])*\.[a-zA-Z]{2,}$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-VN")]
    private static partial Regex EmailRegex();
}