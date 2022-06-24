var input = args[0];
string revertedInput = new(input.Reverse().ToArray());
int[] mask = new int[input.Length];
mask[^1] = 1;
var stringifiedControlMask = StringifyMask();

while(true)
{
    PrintMaskedString();
    ShiftMask();

    var stringifiedMask = StringifyMask();
    if(stringifiedMask.Equals(stringifiedControlMask))
    {
        if(MaskContainsOnlyOnes())
            break;

        int sumOfOnes = mask.Sum() + 1;
        mask = new int[mask.Length];

        for(int i = 0; i < sumOfOnes; i++)
            mask[mask.Length - i - 1] = 1;

        stringifiedControlMask = StringifyMask();
    }
}

string StringifyMask()
    => string.Join("", mask);

void PrintMaskedString()
{
    Console.WriteLine(new string(MaskedString().Reverse().ToArray()));
}

string MaskedString()
{
    string result = "";

    for(int i = 0; i < mask.Length; i++)
    {
        if(mask[i] == 1)
            result += revertedInput[i];
    }

    return result;
}

void ShiftMask()
{
    var first = mask[0];

    for(int i = 0; i < mask.Length - 1; i++)
    {
        mask[i] = mask[i + 1];
    }

    mask[^1] = first;
}

bool MaskContainsOnlyOnes()
    => mask.Sum() == mask.Length;
