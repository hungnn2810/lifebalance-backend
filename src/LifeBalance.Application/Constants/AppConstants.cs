using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LifeBalance.Application.Constants;

public static class AppConstants
{
    public const string DEFAULT_DATE_TIME_FORMAT = "yyyy-MM-ddTHH:mm:ss.ffff";
    
    public static JsonSerializerSettings JsonSerializerSetting { get; } = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DateFormatString = DEFAULT_DATE_TIME_FORMAT,
        DateParseHandling = DateParseHandling.None,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
}