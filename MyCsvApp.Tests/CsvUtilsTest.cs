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
    public void SanitizeCsvValueV1_VariousInputs_ReturnsExpected(string input, string expected)
    {
        var result = CsvUtils.SanitizeCsvValueV1(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("  apple , , banana ,  orange  ,", "apple,banana,orange")]
    [TestCase(",,,", "")]
    [TestCase("  grape  ", "grape")]
    [TestCase(", lemon , lime ,", "lemon,lime")]
    [TestCase("   ,   ,  ", "")]
    [TestCase("a,b,c", "a,b,c")]
    public void SanitizeCsvValueV2_VariousInputs_ReturnsExpected(string input, string expected)
    {
        var result = CsvUtils.SanitizeCsvValueV2(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("  apple , , banana ,  orange  ,", "apple,banana,orange")]
    [TestCase(",,,", "")]
    [TestCase("  grape  ", "grape")]
    [TestCase(", lemon , lime ,", "lemon,lime")]
    [TestCase("   ,   ,  ", "")]
    [TestCase("a,b,c", "a,b,c")]
    public void SanitizeCsvValueV3_VariousInputs_ReturnsExpected(string input, string expected)
    {
        var result = CsvUtils.SanitizeCsvValueV3(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("  apple , , banana ,  orange  ,", "apple,banana,orange")]
    [TestCase(",,,", "")]
    [TestCase("  grape  ", "grape")]
    [TestCase(", lemon , lime ,", "lemon,lime")]
    [TestCase("   ,   ,  ", "")]
    [TestCase("a,b,c", "a,b,c")]
    public void SanitizeCsvValueV4_VariousInputs_ReturnsExpected(string input, string expected)
    {
        var result = CsvUtils.SanitizeCsvValueV4(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}