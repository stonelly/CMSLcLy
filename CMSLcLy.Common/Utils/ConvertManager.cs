using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Collections;

namespace CMSLcLy.Common.Utils
{
    public static class ConvertManager
    {
        public static string ConvertTo(this object value)
        {
            return value.ConvertTo<string>();
        }
        public static T ConvertTo<T>(this object value)
        {
            var result = value.ConvertToTargetTypeValue(typeof(T));
            if (result == null)
                return default(T);
            else
                return (T)result;
        }

        public static object ConvertToTargetTypeValue(this object value, Type targetType)
        {
            if (value != null)
            {
                if (targetType.IsAssignableFrom(value.GetType()))
                    return value;
                if (!(value is string) && value.GetType().IsClass && !targetType.IsClass)
                    value = value.ConvertTo<string>().ConvertToTargetTypeValue(targetType);
            }

            if (value == null ||
                (string.Equals(value, "") &&
                 (typeof(decimal?).IsAssignableFrom(targetType) ||
                  typeof(ushort?).IsAssignableFrom(targetType) ||
                  typeof(uint?).IsAssignableFrom(targetType) ||
                  typeof(ulong?).IsAssignableFrom(targetType) ||
                  typeof(short?).IsAssignableFrom(targetType) ||
                  typeof(int?).IsAssignableFrom(targetType) ||
                  typeof(long?).IsAssignableFrom(targetType) ||
                  typeof(byte?).IsAssignableFrom(targetType) ||
                  typeof(sbyte?).IsAssignableFrom(targetType) ||
                  typeof(float?).IsAssignableFrom(targetType) ||
                  typeof(bool?).IsAssignableFrom(targetType) ||
                  typeof(double?).IsAssignableFrom(targetType) ||
                  typeof(DateTime?).IsAssignableFrom(targetType) ||
                  //typeof(Time?).IsAssignableFrom(targetType) ||
                  //typeof(Currency?).IsAssignableFrom(targetType) ||
                  typeof(Guid?).IsAssignableFrom(targetType))))
                return null;

            if (targetType.IsValueType && value is string)
                value = value.ConvertTo<string>().Trim();

            if (targetType.IsAssignableFrom(value.GetType()))
                return value;
            else if (typeof(decimal?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToDecimal(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                //else if (value is Currency)
                //{
                //	decimal? returnValue = (Currency?)value;
                //	return returnValue;
                //}
                else
                    return Convert.ToDecimal(value);
            }
            else if (typeof(ushort?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToUInt16(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToUInt16(value);
            }
            else if (typeof(uint?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToUInt32(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToUInt32(value);
            }
            else if (typeof(ulong?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToUInt64(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToUInt64(value);
            }
            else if (typeof(short?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToInt16(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToInt16(value);
            }
            else if (typeof(int?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToInt32(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToInt32(value);
            }
            else if (typeof(long?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToInt64(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToInt64(value);
            }
            else if (typeof(sbyte?).IsAssignableFrom(targetType))
                return Convert.ToSByte(value);
            else if (typeof(byte?).IsAssignableFrom(targetType))
                return Convert.ToByte(value);
            else if (typeof(float?).IsAssignableFrom(targetType))
                return Convert.ToSingle(value);
            else if (typeof(bool?).IsAssignableFrom(targetType))
            {
                if (value is string)
                {
                    var text = value.ConvertTo<string>();
                    if (text.Contains(","))
                        text = text.Split(',').First();
                    text = text.ToLower();

                    value = text;
                    if (string.Equals(value, "yes"))
                        return true;
                    else if (string.Equals(value, "no"))
                        return false;

                    if (!object.Equals(value, bool.TrueString.ToLower()) &&
                        !object.Equals(value, bool.FalseString.ToLower()))
                        return Convert.ToBoolean(Convert.ToByte(value));
                }
                return Convert.ToBoolean(value);
            }
            else if (typeof(double?).IsAssignableFrom(targetType))
            {
                if (value is string && value.ConvertTo<string>().StartsWith("("))
                    return Convert.ToDouble(value.ConvertTo<string>().Replace("(", "-").Replace(")", ""));
                else
                    return Convert.ToDouble(value);
            }
            else if (typeof(DateTime?).IsAssignableFrom(targetType))
            {
                try
                {
                    DateTime? result;
                    var cultureInfo = new CultureInfo("en-US");
                    cultureInfo.DateTimeFormat.ShortDatePattern = ConfigurationManager.AppSettings["SystemDateFormat"];
                    result = Convert.ToDateTime(value.ToString(), cultureInfo);
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            //else if (typeof(Currency?).IsAssignableFrom(targetType))
            //{
            //	if (value is string && value.ConvertTo<string>().StartsWith("("))
            //		value = value.ConvertTo<string>().Replace("(", "-").Replace(")", "");
            //	var result = value.ConvertTo<decimal?>();
            //	if (result.HasValue)
            //		return new Currency(result.Value);
            //	else
            //		return null;
            //}
            else if (typeof(Enum).IsAssignableFrom(targetType) ||
                     (targetType.IsGenericType && typeof(Enum).IsAssignableFrom(targetType.GetGenericArguments().First())))
            {
                try
                {
                    if (targetType.IsGenericType)
                    {
                        if (value is Enum)
                            return Enum.Parse(targetType.GetGenericArguments().First(), value.ConvertTo<byte>().ConvertTo<string>());
                        else if (string.IsNullOrEmpty(value.ConvertTo<string>()))
                            return null;
                        else
                            return Enum.Parse(targetType.GetGenericArguments().First(), Convert.ToString(value).Trim());
                    }
                    else
                    {
                        if (value is Enum)
                            return Enum.Parse(targetType, value.ConvertTo<byte>().ConvertTo<string>());
                        else if (string.IsNullOrEmpty(value.ConvertTo<string>()))
                            return Enum.Parse(targetType, "0");
                        else
                            return Enum.Parse(targetType, Convert.ToString(value).Trim());
                    }
                }
                catch
                {
                    foreach (var field in targetType.GetFields())
                    {
                        var description = field.GetCustomAttributes(typeof(DescriptionAttribute), true).OfType<DescriptionAttribute>().FirstOrDefault();
                        if (description != null && string.Equals(description.Description, value))
                            return Enum.Parse(targetType, field.Name);
                    }
                    throw new ArgumentOutOfRangeException("value");
                }
            }
            else if (typeof(Type).IsAssignableFrom(targetType))
            {
                try
                {
                    return Type.GetType(value.ConvertTo<string>());
                }
                catch
                {
                    return null;
                }
            }
            else if (typeof(Guid?).IsAssignableFrom(targetType))
            {
                return Guid.Parse(value.ConvertTo<string>());
            }
            else if (typeof(string).IsAssignableFrom(targetType))
            {
                if (value is DateTime?)
                {
                    DateTime date = (value as DateTime?).Value;
                    if (date.Hour > 0 || date.Minute > 0 || date.Second > 0)
                        return date.ToString(ConfigurationManager.AppSettings["SystemDateTimeFormat"]);
                    else
                        return date.ToString(ConfigurationManager.AppSettings["SystemDateFormat"]);
                }
                //else if (value is Currency?)
                //{
                //	var result = value.ConvertTo<Currency>().ToThousand();
                //	return result;
                //}
                else if (value is IEnumerable)
                {
                    var list = new List<string>();
                    foreach (var val in (value as IEnumerable))
                        list.Add(val.ConvertTo());
                    var result = string.Join(",", list);
                    return result;
                }
                else if (value is bool)
                {
                    if ((bool)value)
                        return "Yes";
                    else
                        return "No";
                }
                else
                {
                    string result = Convert.ToString(value);
                    return result;
                }
            }
            else
                return Convert.ToString(value);
        }

        //public static string ToThousand(this Currency? value)
        //{
        //	return (value ?? 0).ToThousand();
        //}
        //public static string ToThousand(this Currency value)
        //{
        //	return value.OriginalValue.ToThousand();
        //}
        public static string ToThousand(this decimal? value)
        {
            return (value ?? 0).ToThousand();
        }
        public static string ToThousand(this decimal value)
        {
            return String.Format("{0:#,0.00}", value);
        }

        public static decimal ToFeet(this decimal valueInInch)
        {
            return Math.Round(valueInInch / 12, 3);
        }
        public static decimal ToInch(this decimal valueInFeet)
        {
            return Math.Round(valueInFeet * 12, 3);
        }
        public static decimal ToSQFT(this decimal valueInInch)
        {
            return Math.Round(valueInInch / 144, 3);
        }

    }
}
