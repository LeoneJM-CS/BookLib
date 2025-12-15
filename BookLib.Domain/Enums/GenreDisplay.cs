using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLib.Domain.Enums
{
    public class GenreDisplay
    {
        public static string GetGenreName(Enum enumValue)
        {
            var displayAttribute = enumValue.GetType().GetField(enumValue.ToString());
            if (displayAttribute == null) 
            {
                return enumValue.ToString();
            }
            var attribute = displayAttribute.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            return attribute?.Name ?? enumValue.ToString();
        }
    }
}
