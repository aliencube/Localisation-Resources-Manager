using System.Configuration;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This represents the resource element entity.
    /// </summary>
    public class ResourceElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        [ConfigurationProperty("locale", DefaultValue = "en", IsRequired = true)]
        [StringValidator(InvalidCharacters = "`~!@#$%^&*()=_+[]{}\\|;:'\",.<>/?1234567890", MinLength = 2, MaxLength = 8)]
        public string Locale
        {
            get { return (string)this["locale"]; }
            set { this["locale"] = value; }
        }

        /// <summary>
        /// Gets or sets the source file path or URL.
        /// </summary>
        [ConfigurationProperty("src", DefaultValue = "/localisation/Resource.en.xml", IsRequired = true)]
        [StringValidator(InvalidCharacters = "`!@#$%^*()=+[]{}|;:'\",<>", MinLength = 0, MaxLength = 256)]
        public string Src
        {
            get { return (string)this["src"]; }
            set { this["src"] = value; }
        }
    }
}