using LifeBalance.Application.Constants;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Abstractions;
using LifeBalance.Application.Workouts.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace LifeBalance.Application.Services;

public class WorkoutLocalizationService : IWorkoutLocalizationService
{
    private readonly Dictionary<string, WorkoutLocale> _workouts;

    public WorkoutLocalizationService(IUserContext userContext, IWebHostEnvironment env)
    {
        var lang = string.IsNullOrWhiteSpace(userContext.Language) ? "en" : userContext.Language;
        var path = Path.Combine(env.ContentRootPath, "Resources", $"{lang}.json");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Localization file not found: {path}");
        }

        var json = File.ReadAllText(path);
        var root = JsonConvert.DeserializeObject<JsonRoot>(json, AppConstants.JsonSerializerSetting);

        _workouts = root.Workout;
    }

    public WorkoutLocale Get(string code)
    {
        return _workouts.GetValueOrDefault(code);
    }

    private class JsonRoot
    {
        public Dictionary<string, WorkoutLocale> Workout { get; set; }
    }
}