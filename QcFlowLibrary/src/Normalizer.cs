namespace QcFlowLibrary;

public static class Normalizer
{
    public static bool FromLimsA(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        char ch = str[0];
        return char.IsUpper(ch);
    }
}
