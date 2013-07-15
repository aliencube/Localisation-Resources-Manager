using System.Configuration;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This represents the resource element collection entity.
    /// </summary>
    public class ResourceElementCollection : ConfigurationElementCollection
    {
        #region Properties
        /// <summary>
        /// Gets the type of the ConfigurationElementCollection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        /// <summary>
        /// Gets or sets the resource element at the specified index location.
        /// </summary>
        /// <param name="index">The index location of the resource element to remove.</param>
        /// <returns>Returns the resource element at the specified index location.</returns>
        public ResourceElement this[int index]
        {
            get
            {
                return (ResourceElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Gets or sets the resource element having the specified key.
        /// </summary>
        /// <param name="locale">Key value.</param>
        /// <returns>Returns the resource element having the specified key.</returns>
        public new ResourceElement this[string locale]
        {
            get
            {
                return (ResourceElement)BaseGet(locale);
            }
            set
            {
                var item = (ResourceElement)BaseGet(locale);
                if (item != null)
                {
                    var index = BaseIndexOf(item);
                    BaseRemoveAt(index);
                    BaseAdd(index, value);
                }
                BaseAdd(value);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new ConfigurationElement.
        /// </summary>
        /// <returns>Returns a new ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ResourceElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">ConfigurationElement to return for.</param>
        /// <returns>Returns an Object that acts as the key for the specified ConfigurationElement.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ResourceElement)element).Locale;
        }

        /// <summary>
        /// Adds an resource element to the ConfigurationElementCollection.
        /// </summary>
        /// <param name="element">Resource element.</param>
        public void Add(ResourceElement element)
        {
            BaseAdd(element);
        }

        /// <summary>
        /// Removes all resource element objects from the collection.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Removes an resource element from the collection.
        /// </summary>
        /// <param name="element">Resource element.</param>
        public void Remove(ResourceElement element)
        {
            BaseRemove(element.Locale);
        }

        /// <summary>
        /// Removes an resource element from the collection.
        /// </summary>
        /// <param name="name">Locale.</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// Removes the resource element at the specified index location.
        /// </summary>
        /// <param name="index">The index location of the resource element to remove.</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        #endregion
    }
}