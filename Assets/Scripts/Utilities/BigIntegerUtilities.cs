using System.Globalization;
using System.Numerics;

public static class BigIntegerUtilities
{
    public static string ToString(BigInteger val, int maxDigits, int totalPad = 1)
    {
        if (BigInteger.Log10(val) > maxDigits)
        {
            string str = val.ToString("E", CultureInfo.CreateSpecificCulture("en-US"));
            str = str.Remove(4, 4).Remove(5, 1);
            return str;
        }   
        else
        {
            return val.ToString().PadLeft(totalPad);
        }
    }
}
