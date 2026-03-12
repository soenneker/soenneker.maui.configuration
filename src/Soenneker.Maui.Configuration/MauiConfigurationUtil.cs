using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Maui.Storage;
using Soenneker.Extensions.String;
using Soenneker.Extensions.Task;

namespace Soenneker.Maui.Configuration;

/// <summary>
/// A utility library for MAUI configuration related operations
/// </summary>
public static class MauiConfigurationUtil
{
    /// <summary>
    /// Loads the application configuration from JSON files (appsettings.json, appsettings.debug.json, appsettings.release.json).
    /// </summary>
    /// <param name="isDebug">Specifies whether to load debug or release configuration. Defaults to auto-detection.</param>
    /// <returns>An <see cref="IConfiguration"/> instance.</returns>
    public static IConfiguration Load(bool isDebug)
    {
        var configBuilder = new ConfigurationBuilder();

        // Load base and environment-specific settings
        AddJsonFile(configBuilder, "appsettings.json");

        if (isDebug)
            AddJsonFile(configBuilder, "appsettings.debug.json");
        else
            AddJsonFile(configBuilder, "appsettings.release.json");


        return configBuilder.Build();
    }

    /// <summary>
    /// Attempts to add a JSON configuration file from the app package or local storage.
    /// </summary>
    /// <param name="builder">The configuration builder.</param>
    /// <param name="fileName">The JSON file name.</param>
    private static void AddJsonFile(ConfigurationBuilder builder, string fileName)
    {
        try
        {
            using Stream? stream = FileSystem.OpenAppPackageFileAsync(fileName).AwaitSyncSafe();

            if (stream != null)
            {
                using var reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                byte[] jsonBytes = json.ToBytes();

                builder.AddJsonStream(new MemoryStream(jsonBytes));
            }
        }
        catch (FileNotFoundException)
        {
            // Replace with proper logging if available
            Debug.WriteLine($"{fileName} not found. Skipping...");
        }
    }
}