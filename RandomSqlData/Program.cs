using RandomSqlData;

var script =
    "DROP TABLE IF EXISTS figures;\n\n" +
    "CREATE TABLE figures(" +
    "id SERIAL PRIMARY KEY, " +
    "name TEXT, " +
    "character TEXT, " +
    "brand TEXT, " +
    "year SMALLSERIAL, " +
    "month TEXT, " +
    "releasePrice SERIAL, " +
    "janCode BIGSERIAL, " +
    "series TEXT, " +
    "productLine TEXT, " +
    "sculptor TEXT" +
    ");\n\n";

var figureBuilder = new FigureBuilder();
for (var i = 0; i < 500; i++)
{
    script += AppendToScript(figureBuilder.CreateRandomFigure());
}

string AppendToScript(FigureModel figure)
{
    return $"INSERT INTO figures (name, character, brand, releasePrice, series, janCode, year, month, productLine, sculptor) " +
           $"VALUES ('{figure.Name}', '{figure.Character}', '{figure.Brand}', '{figure.ReleasePrice}','{figure.Series}', {figure.JanCode}, {figure.ReleaseYear}, '{figure.ReleaseMonth}', '{figure.ProductLine}', '{figure.Sculptor}');\n";
}

await File.WriteAllTextAsync("/home/chris/RiderProjects/RandomSqlData/random-figure.sql", script);
