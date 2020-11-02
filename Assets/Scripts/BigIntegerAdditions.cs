using System.Globalization;
using System.Numerics;

public static class BigIntegerAdditions
{
    public static string ToString(BigInteger val, int maxDigits, int totalPad = 1, int expPadd = 1)
    {
        if (BigInteger.Log10(val) > maxDigits)
        {
            // char[] valueStr = val.ToString().PadRight(3, '0').ToCharArray();
            // return (valueStr[0] + "." + valueStr[1] + valueStr[2] + "E" + (Digits(val)).ToString().PadLeft(expPadd, '0')).PadLeft(totalPad);

            string str = val.ToString("E", CultureInfo.CreateSpecificCulture("en-US"));
            str = str.Remove(4, 4).Remove(5, 1);
            return str;
        }   
        else
        {
            return val.ToString().PadLeft(totalPad);
        }
    }

    public static int Digits(BigInteger val)
    {
        int ret = 0;
        for(;;)
        {
            ret++;
            if (val == 0)
            {
                return ret;
            }
            else if (val % 10 == 0)
            {
                return ret + 1;
            }
            val /= 10;
        }
    }
}
