using System;
using System.Linq;
using System.Text;

public static class CsvUtils
{
    // Original implementation
    public static string SanitizeCsvValueV1(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var values = input.Split(',');
        return string.Join(",", values.Select(v => v.Trim()).Where(v => !string.IsNullOrEmpty(v)));
    }

    // Improved implementation with fast path to avoid allocations
    public static string SanitizeCsvValueV2(string input)
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
   

    // v3: Use StringBuilder, but check if sanitization is needed first
    public static string SanitizeCsvValueV3(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var values = input.Split(',');
        bool needsSanitizing = false;
        for (int i = 0; i < values.Length; i++)
        {
            var trimmed = values[i].Trim();
            if (values[i] != trimmed || string.IsNullOrEmpty(trimmed))
            {
                needsSanitizing = true;
                break;
            }
        }

        if (!needsSanitizing)
            return string.Join(",", values);

        var sb = new StringBuilder();
        bool first = true;
        foreach (var v in values)
        {
            var trimmed = v.Trim();
            if (!string.IsNullOrEmpty(trimmed))
            {
                if (!first)
                    sb.Append(',');
                sb.Append(trimmed);
                first = false;
            }
        }
        return sb.ToString();
    }

    // v4: Use Span<char> for allocation-free trimming and splitting, check if sanitization is needed
    public static string SanitizeCsvValueV4(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        ReadOnlySpan<char> span = input.AsSpan();
        int length = span.Length;
        bool needsSanitizing = false;
        int start = 0;

        // Check if sanitization is needed
        for (int i = 0; i <= length; i++)
        {
            if (i == length || span[i] == ',')
            {
                var segment = span.Slice(start, i - start);
                var trimmed = segment.Trim();
                if (!segment.SequenceEqual(trimmed) || trimmed.IsEmpty)
                {
                    needsSanitizing = true;
                    break;
                }
                start = i + 1;
            }
        }

        if (!needsSanitizing)
            return input;

        // Build sanitized string
        var sb = new StringBuilder();
        start = 0;
        bool first = true;
        for (int i = 0; i <= length; i++)
        {
            if (i == length || span[i] == ',')
            {
                var segment = span.Slice(start, i - start).Trim();
                if (!segment.IsEmpty)
                {
                    if (!first)
                        sb.Append(',');
                    sb.Append(segment);
                    first = false;
                }
                start = i + 1;
            }
        }
        return sb.ToString();
    }
}