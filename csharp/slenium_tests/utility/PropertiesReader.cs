using System.Collections.Generic;
using System.IO;

public static class PropertiesReader
{
    private static readonly Dictionary<string, string> _properties = new Dictionary<string, string>();

    static PropertiesReader()
    {
        // Use relative path to the 'properties' folder from the output directory
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "properties");
        string filePath = Path.Combine(folderPath, "config.properties");

        // Verify that the directory and file exist
        if (Directory.Exists(folderPath) && File.Exists(filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var parts = line.Split('=', 2); // Split on the first '=' only
                    if (parts.Length == 2)
                    {
                        _properties[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }
        else
        {
            // Handle file not found scenario
            throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");
        }
    }

    public static string GetProperty(string key)
    {
        return _properties.TryGetValue(key, out var value) ? value : string.Empty; // Default to an empty string
    }
}
