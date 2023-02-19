using RandomSqlData;

var script = "";

var figureBuilder = new FigureBuilder();
for (var i = 0; i < 50; i++)
{
    script += AppendToScript(figureBuilder.CreateRandomFigure());
}
string AppendToScript(FigureModel figure) => $"{figure.Name}, {figure.Character}, etc...\n";

await File.WriteAllTextAsync("/home/chris/RiderProjects/RandomSqlData/random-figure.sql", script);

/*
var nameOptions = new List<string>() { "Miku", "Snow Miku", "Cherry Miku", "Ryza" };
var characterOptions = new List<string>() { "Miku", "Snow Miku", "Cherry Miku", "Ryza" };
var brandOptions = new List<string>() { "Good Smile", "Alter", "Broccoli" };
var dateOptions = new List<DateTime>();
var priceOptions = new List<int>();
var janCodeOptions = new List<long>();
var seriesOptions = new List<string>();
var productLineOptions = new List<string>();
var sculptorOptions = new List<string>();
*/