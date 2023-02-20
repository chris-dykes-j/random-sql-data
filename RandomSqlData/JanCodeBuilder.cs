namespace RandomSqlData;

public class JanCodeBuilder
{
    private readonly Random _random = new (); 
    
    // Not accurate, but looks enough to an EAN-13 Code.
    // Chance for duplication, but it does not matter for fake data.
    public long CreateJanCode()
    {
        var countryCode = (_random.NextInt64(0, 2) == 0 ? 45 : 49) * 10_000_000_000;
        var randomDigits = _random.NextInt64(0, 9_999_999_999);
        var code = countryCode + randomDigits;
        var codeDigits = code.ToString()
            .Select(x => int.Parse(x.ToString()))
            .ToArray();

        var checksum = codeDigits.Select((k, i) => 
            k * (i % 2 == 0 ? 1 : 3))
            .Sum();

        var checkDigit = (10 - (checksum % 10)) % 10;
        return code * 10 + checkDigit;
    }
}