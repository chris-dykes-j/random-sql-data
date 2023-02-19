using RandomSqlData;

var script = "";

var figureBuilder = new FigureBuilder();
for (var i = 0; i < 50; i++)
{
    script += AppendToScript(figureBuilder.CreateRandomFigure());
}

string AppendToScript(FigureModel figure)
{
    return $"{figure.Name}, {figure.Character}, {figure.Brand}, {figure.Series}, {figure.JanCode}, {figure.ReleaseYear}, {figure.ReleaseMonth}, {figure.ProductLine}, {figure.Sculptor}\n";
}

await File.WriteAllTextAsync("/home/chris/RiderProjects/RandomSqlData/random-figure.sql", script);
