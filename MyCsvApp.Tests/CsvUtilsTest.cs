using NUnit.Framework;

namespace CsvUtilsTest;

[TestFixture]
public class CsvUtilsTest
{
    [TestCase("  apple , , banana ,  orange  ,", "apple,banana,orange")]
    [TestCase(",,,", "")]
    [TestCase("  grape  ", "grape")]
    [TestCase(", lemon , lime ,", "lemon,lime")]
    [TestCase("   ,   ,  ", "")]
    [TestCase("a,b,c", "a,b,c")]
    public void SanitizeCsvValue_VariousInputs_ReturnsExpected(string input, string expected)
    {
        var result = CsvUtils.SanitizeCsvValue(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}