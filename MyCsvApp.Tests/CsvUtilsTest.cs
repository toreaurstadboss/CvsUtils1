using NUnit.Framework;

namespace CsvUtilsTest;

[TestFixture]
public class CsvUtilsTest
{
    [Test]
    public void SanitizeCsvValue_RemovesExtraSpacesAndEmptyValues()
    {
        var input = "  apple , , banana ,  orange  ,";
        var expected = "apple,banana,orange";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SanitizeCsvValue_OnlyCommas_ReturnsEmptyString()
    {
        var input = ",,,";
        var expected = "";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }       

    [Test]
    public void SanitizeCsvValue_NoCommas_ReturnsTrimmedValue()
    {
        var input = "  grape  ";
        var expected = "grape";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SanitizeCsvValue_LeadingAndTrailingCommas()
    {
        var input = ", lemon , lime ,";
        var expected = "lemon,lime";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SanitizeCsvValue_AllWhitespaceValues_ReturnsEmptyString()
    {
        var input = "   ,   ,  ";
        var expected = "";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SanitizeCsvValue_NormalValues()
    {
        var input = "a,b,c";
        var expected = "a,b,c";
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}