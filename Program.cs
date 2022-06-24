var input = args.Length == 0 ? "xyz" : string.Concat(args);
string revertedInput = new(input.Reverse().ToArray());
int mask = 0b1;
var words = new List<string>();
var control = StringifyBinaryMask();

while(mask < (int)Math.Pow(2, input.Length))
{
    words.Add(new string(MaskedString().Reverse().ToArray()));
    mask++;

    var stringifiedMask = StringifyBinaryMask();
    if(stringifiedMask.Equals(control))
    {
        control = StringifyBinaryMask();
    }
}

foreach(var word in words.OrderBy(x => x.Length).Distinct())
    Console.WriteLine(word);

string StringifyBinaryMask()
    => Convert.ToString(mask, toBase: 2).PadLeft(input.Length, '0');

string MaskedString()
{
    string result = "";
    var maskString = StringifyBinaryMask();
    for(int i = 0; i < maskString.Length; i++)
    {
        if(maskString[i].Equals('1'))
            result += revertedInput[i];
    }

    return result;
}