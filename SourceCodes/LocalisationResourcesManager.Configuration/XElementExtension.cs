using System.Xml;
using System.Xml.Linq;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This extends the XElement related methods.
    /// </summary>
    public static class XElementExtension
    {
        /// <summary>
        /// Converts XElement to XmlNode.
        /// </summary>
        /// <param name="element">XElement instance.</param>
        /// <returns>Returns the XmlNode converted from XElement.</returns>
        public static XmlNode ToXmlNode(this XElement element)
        {
            if (element == null)
                return null;

            var xml = new XmlDocument();
            using (var reader = element.CreateReader())
            {
                xml.Load(reader);
            }
            XmlNode node = xml.DocumentElement;
            return node != null ? node : null;
        }
    }
}
