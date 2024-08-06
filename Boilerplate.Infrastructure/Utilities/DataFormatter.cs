using Boilerplate.Data.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Boilerplate.Infrastructure.Utilities
{
    public static class DataFormatter
    {
        public static string DetectTypeAndFormatValue(dynamic value, CultureInfo userMachineCulture)
        {
            try
            {
                var valueType = value.GetType().Name.ToString();

                if(valueType == "DateTime")
                {
                    return Convert.ToDateTime(value.ToString()).ToString(userMachineCulture.DateTimeFormat.ShortDatePattern);
                }
                else  if(valueType == "String")
                {
                    return value;
                }
                else if (valueType == "Decimal")
                {
                    return Convert.ToDecimal(value.ToString()).ToString(userMachineCulture.NumberFormat);
                }
                return value;
            }
            catch (Exception ex)
            {
                return value;
            }
        }

        public static bool IsBoolean(string str)
        {
            if (str == "true" || str == "false")
            {
                return true;
            }
            return false;
        }

        public static bool IsDigitsOnly(string str)
        {
            if (str == "")
            {
                return false;
            }
            else
            {
                var valid = !str.Any(ch => ch < '0' || ch > '9') ? true : false;

                if (valid)
                {
                    try
                    {
                        int.Parse(str);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                    return true;
                }

                return valid;
            }
        }

        public static bool IsDecimal(string str, CultureInfo cultureInfo)
        {
            try
            {
                decimal number;
                if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint & NumberStyles.AllowThousands, cultureInfo, out number))
                {
                    return number % 1 > 0;
                }

                var va = decimal.Parse(str, cultureInfo.NumberFormat);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool IsOnlyDate(dynamic str)
        {
            try
            {
                DateTime dt2;
                bool status = DateTime.TryParse(str, out dt2);
                if (status)
                {
                    if (str.IndexOf(".") > -1)
                    {
                        return false;
                    }

                    return status;
                }
                return status;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool IsHtml(dynamic value)
        {
            Regex htmlRegex = new Regex(@"<[^>]+>");

            if (htmlRegex.Match(value))
            {
                return true;
            }

            return false;
        }
    }
}
