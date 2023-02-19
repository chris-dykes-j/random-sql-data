namespace RandomSqlData;

public class FigureBuilder
{
    private readonly Random _random;
    private readonly List<string> _characterOptions;
    private readonly List<string> _brandOptions;

    public FigureBuilder()
    {
        _random = new Random();
        _characterOptions = new List<string> { "Miku", "Snow Miku", "Cherry Miku", "Ryza" };
        _brandOptions = new List<string> { "Good Smile", "Alter", "Broccoli" };
    }

    public FigureModel CreateRandomFigure()
    {
        return new FigureModel
        {
            Name = CreateRandomString(_random.Next(0, 30)),
            Character = SelectRandomCharacter(),
            Brand = SelectRandomBrand(), /*
            ReleaseDate = CreateRandomDate(),
            ReleasePrice = CreateRandomPrice(),
            JanCode = CreateUniqueJanCode(),
            Series = CreateRandomSeries(),
            ProductLine = CreateRandomProductLine(),
            Sculptor = CreateRandomSculptor() */
        };
    }

    private string CreateRandomString(int stringLength)
    {
        var result = "";
        for (var i = 0; i < stringLength; i++)
        {
            result += Convert.ToChar(_random.Next(0, 26) + 65);
        }
        return result;
    }

    private string SelectRandomCharacter()
    {
        return _characterOptions[_random.Next(0, _characterOptions.Count - 1)];
    }

    private string SelectRandomBrand()
    {
        return _brandOptions[_random.Next(0, _brandOptions.Count - 1)];
    }
}