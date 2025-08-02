using System;
using System.Linq;

public static class CsvUtils
{
    public static string SanitizeCsvValue(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Fast path: if no commas and no leading/trailing whitespace, return as-is
        if (!input.Contains(",") && input == input.Trim())
            return input;

        var values = input.Split(',');
        bool needsSanitizing = false;

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != values[i].Trim() || string.IsNullOrEmpty(values[i].Trim()))
            {
                needsSanitizing = true;
                break;
            }
        }

        if (!needsSanitizing)
            return string.Join(",", values);

        return string.Join(",", values.Select(v => v.Trim()).Where(v => !string.IsNullOrEmpty(v)));
    }
}