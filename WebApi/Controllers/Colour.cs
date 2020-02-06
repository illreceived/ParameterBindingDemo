using System;
using System.ComponentModel;
using System.Globalization;


namespace WebApi.Controllers
{
    [TypeConverter(typeof(ColourTypeConvertor))]
    public class Colour
    {
    
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public override string ToString()
        {
            return $"R:{Red}, G:{Green}, B:{Blue}";
        }
    }

    public class ColourTypeConvertor : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                try
                {
                    var c = System.Drawing.ColorTranslator.FromHtml(stringValue);
                    return new Colour() { Red = c.R, Green = c.G, Blue = c.B };
                }
                catch(Exception ex)
                {
                    return new Colour();
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}