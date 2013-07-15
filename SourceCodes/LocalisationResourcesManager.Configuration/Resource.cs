using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This represents the localisation resource.
    /// </summary>
    public class Resource : IResource
    {
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the Resource class.
        /// </summary>
        /// <param name="elements">List of resource items as XElement types.</param>
        public Resource(IList<XElement> elements)
        {
            if (elements == null || !elements.Any())
                return;

            this._items = elements.ToDictionary(p => p.Attribute("key").Value, p => p.Value);
        }

        /// <summary>
        /// Initialises an instance of the Resource class.
        /// </summary>
        /// <param name="nodes">List of resource items as XmlNodeList type.</param>
        public Resource(IEnumerable nodes)
            : this(nodes.Cast<XmlNode>().ToList())
        {
        }

        /// <summary>
        /// Initialises an instance of the Resource class.
        /// </summary>
        /// <param name="nodes">List of resource items as a collection of XmlNode types.</param>
        public Resource(IList<XmlNode> nodes)
        {
            if (nodes == null || !nodes.Any())
                return;

            this._items = nodes.ToDictionary(p => p.Attributes["key"].Value, p => p.InnerText);
        }
        #endregion

        #region Properties
        private readonly Dictionary<string, string> _items;
        #endregion

        #region Methods
        /// <summary>
        /// Gets the list of keys from the resource.
        /// </summary>
        /// <returns>Returns the list of keys from the resource.</returns>
        public IList<string> GetKeys()
        {
            var keys = new List<string>();
            if (this._items != null && this._items.Any())
                keys = this._items.Keys.ToList();
            return keys;
        }

        /// <summary>
        /// Gets the value corresponding to the key from the resource.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Returns the value corresponding to the key from the resource.</returns>
        public string GetValue(string key)
        {
            var value = String.Empty;
            if (this._items != null && this._items.Any() && this._items.ContainsKey(key))
                value = this._items[key];
            return value;
        }
        #endregion
    }
}