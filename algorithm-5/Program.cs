string[] input;
if(args is null || args.Length == 0)
    input = new string[] { "eat", "ate", "apt", "pat", "tea", "now" };
else
    input = args;

var result = new List<List<string>>()
{
    new List<string>()
    {
        input[0]
    }
};

for(int word = 1; word < input.Length; word++)
{
    var isWordInResult = result.Any(r => r.Any(x => x.Contains(input[word])));
    if(isWordInResult)
        continue;

    var encodedWord = string.Join("", input[word].OrderBy(x => x).ToArray());
    var wordBelongToGroup = result.Any(r => r.Any(x => string.Join("", x.OrderBy(w => w).ToArray()).Equals(encodedWord)));

    if(!wordBelongToGroup)
    {
        result.Add(new List<string>() { input[word] });
    }
    else
    {
        result.Find(r => string.Join("", r[0].OrderBy(x => x).ToArray()).Equals(encodedWord))?.Add(input[word]);
    }
}

PrintResult(result);

static void PrintResult(List<List<string>> input)
{
    Console.Write('[');
    foreach(var row in input)
    {
        var res = PrintRowResult(row);

        if(row.Equals(input.Last()))
            res = res.TrimEnd(new char[] { '\r', '\n', ',' }) + ']';
        Console.WriteLine(res);
    }
}

static string PrintRowResult(List<string> row)
{
    var line = "[";
    foreach(var value in row)
    {
        string rowResult = $"{value}, ";
        if(value.Equals(row.Last()))
            rowResult = rowResult.TrimEnd(new char[] { ' ', ',' });
        line += rowResult;
    }
    line += "],";

    return line;
}