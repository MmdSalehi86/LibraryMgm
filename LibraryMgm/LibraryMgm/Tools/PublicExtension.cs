// version 2
// update date : 1403/08/29

using System;
using System.Windows.Forms;

public static class PublicExtension
{
    public static bool IsNull(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static string Separate(this string number, int separateNum = 3)
    {
        if (number == "" || number == "0" || number == null)
            return "0";
        decimal price;
        price = decimal.Parse(number, System.Globalization.NumberStyles.Currency);
        number = price.ToString("#,#");
        if (number == "")
            number = "0";
        return number;

        //string temp;
        //temp = number.Replace(",", "");

        //for (int index = temp.Length - separateNum; index >= 1; index -= separateNum)
        //{
        //    temp = temp.Insert(index, ",");
        //}
        //return temp;
    }

    public static bool ToBool(this object obj)
    {
        return Convert.ToBoolean(obj);
    }

    public static int ToInt32(this object obj)
    {
        return Convert.ToInt32(obj);
    }

    public static bool TryToInt32(this object obj, out int number)
    {
        return int.TryParse(obj.ToString(), out number);
    }
    public static int TryToInt32(this object obj)
    {
        try
        {
            return Convert.ToInt32(obj);
        }
        catch
        {
            return 0;
        }
    }
}
