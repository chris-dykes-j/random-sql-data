namespace RandomSqlData;

public class FigureBuilder
{
    private readonly Random _random;
    private readonly string[] _nameOptions;
    private readonly List<string> _characterOptions;
    private readonly List<string> _brandOptions;
    private readonly List<string> _seriesOptions;
    private readonly string[] _monthOptions;
    private readonly JanCodeBuilder _janCodeBuilder;
    
    public FigureBuilder()
    {
        _random = new Random();
        _nameOptions = File.ReadAllLines("/home/chris/RiderProjects/RandomSqlData/english-adjectives.txt");
        _characterOptions = new List<string> { "Miku", "Rem", "Sonico", "Ryza" };
        _brandOptions = new List<string> { "Good Smile", "Alter", "Broccoli" };
        _seriesOptions = CreateRandomSeriesOptions();
        _monthOptions = new[]
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December"
        };
        _janCodeBuilder = new JanCodeBuilder();
    }

    public FigureModel CreateRandomFigure()
    {
        var character = SelectRandomCharacter();
        return new FigureModel
        {
            Name = CreateRandomName(character),
            Character = character,
            Brand = SelectRandomBrand(),
            ReleaseYear = CreateRandomDate(),
            ReleaseMonth = ChooseRandomMonth(),
            JanCode = _janCodeBuilder.CreateJanCode(),
            Series = ChooseRandomSeries(),
            ReleasePrice = CreateRandomPrice(),
            ProductLine = CreateRandomString(_random.Next(0, 20)),
            Sculptor = CreateRandomString(_random.Next(0, 15))
        };
    }

    private string CreateRandomName(string character)
    {
        var name = _nameOptions[_random.Next(0, _nameOptions.Length - 1)];
        return char.ToUpper(name[0]) + name[1..] + " " + character;
    }

    private string CreateRandomString(int stringLength)
    {
        var result = Convert.ToChar(_random.Next(0, 26) + 65).ToString();
        for (var i = 0; i < stringLength - 1; i++)
        {
            result += Convert.ToChar(_random.Next(0, 26) + 65 + 6 + 26);
        }
        return result;
    }
    
    private string SelectRandomCharacter() => _characterOptions[_random.Next(0, _characterOptions.Count - 1)];

    private string SelectRandomBrand() => _brandOptions[_random.Next(0, _brandOptions.Count - 1)];
    
    private int CreateRandomDate() => _random.Next(2005, 2024);

    private string ChooseRandomMonth() => _monthOptions[_random.Next(0, _monthOptions.Length - 1)];

    private string ChooseRandomSeries() => _seriesOptions[_random.Next(0, _seriesOptions.Count - 1)];

    private int CreateRandomPrice() => _random.Next(10_000, 50_000);
    
    private List<string> CreateRandomSeriesOptions()
    {
        var options = new List<string>();
        using (var reader = new StreamReader("/home/chris/RiderProjects/RandomSqlData/series.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line!.Split(",");
                options.Add(values[1]);
            }
        }
        return options;
    }
}