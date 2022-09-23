using System.Xml.Linq;

namespace IxMilia.ThreeMf.Extensions
{
    internal static class XmlExtensions
    {
        public static string AttributeValueOrThrow(this XElement element, string attributeName, string errorMessage)
        {
            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                throw new ThreeMfParseException(errorMessage);
            }

            return attribute.Value;
        }

        public static string AttributeValueOrThrow(this XElement element, string attributeName)
        {
            return element.AttributeValueOrThrow(attributeName, $"Expected attribute '{attributeName}'.");
        }

        public static int AttributeIntValueOrThrow(this XElement element, string attributeName)
        {
            if (!int.TryParse(element.AttributeValueOrThrow(attributeName), out var value))
            {
                throw new ThreeMfParseException($"Unable to parse attribute '{attributeName}' as an int.");
            }

            return value;
        }

        public static double AttributeDoubleValueOrThrow(this XElement element, string attributeName)
        {
            var svalue = element.AttributeValueOrThrow(attributeName);
            if (!double.TryParse(svalue, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                throw new ThreeMfParseException($"Unable to parse  attribute '{attributeName}'={svalue} as a double.");
            }

            return value;
        }
    }
}
