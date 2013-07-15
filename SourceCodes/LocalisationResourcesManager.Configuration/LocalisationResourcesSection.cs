using System.Configuration;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This represents the localisation resources configuration section entity.
    /// </summary>
    public class LocalisationResourcesSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the default resource elements collection.
        /// </summary>
        [ConfigurationProperty("resources")]
        [ConfigurationCollection(typeof(ResourceElementCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public ResourceElementCollection Resources
        {
            get { return (ResourceElementCollection)this["resources"]; }
            set { this["resources"] = value; }
        }
    }
}
