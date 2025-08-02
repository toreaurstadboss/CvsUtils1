using System;
using System.Linq;

public static class CsvUtils
{
    public static string SanitizeCsvValue(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var values = input.Split(',')
                          .Select(v => v.Trim())
                          .Where(v => !string.IsNullOrEmpty(v))
                          .ToArray();

        return string.Join(",", values);
    }
}