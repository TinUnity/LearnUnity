using System;

public class EnumHelper
{
    public static T ConvertToEnum<T>(string valueString) where T: Enum
    {
        return (T)Enum.Parse(typeof(T), valueString, true);
    }
}
