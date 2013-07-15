using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This represents the localisation resource configuration manager entity.
    /// </summary>
    public class ConfigurationManager
    {
        #region Constructors
        /// <summary>
        /// Initialises an instance of the ConfigurationManager class.
        /// </summary>
        /// <param name="locale">Locale.</param>
        /// <param name="server">The instance of HttpServerUtility. Default value is NULL.</param>
        public ConfigurationManager(string locale, HttpServerUtility server = null)
        {
            this._locale = locale;
            this._server = server;
        }
        #endregion

        #region Properties
        private string _locale;
        /// <summary>
        /// Gets the locale.
        /// </summary>
        public string Locale
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this._locale))
                    this._locale = "en";
                return this._locale;
            }
        }

        private HttpServerUtility _server;
        /// <summary>
        /// Gets the HttpServerUtility instance.
        /// </summary>
        public HttpServerUtility Server
        {
            get
            {
                if (this._server == null)
                {
                    var context = HttpContext.Current;
                    if (context != null)
                        this._server = context.Server;
                }
                return this._server;
            }
        }

        private LocalisationResourcesSection _section;
        /// <summary>
        /// Gets the localisation resources section.
        /// </summary>
        public LocalisationResourcesSection Section
        {
            get
            {
                if (this._section == null)
                    this._section = (LocalisationResourcesSection)System.Configuration.ConfigurationManager.GetSection("localisationResourcesSection");
                return this._section;
            }
        }

        private IResource _resource;
        /// <summary>
        /// Gets the localisation resource with locale.
        /// </summary>
        public IResource Resource
        {
            get
            {
                if (this._resource == null)
                    this._resource = this.GetResource();
                return this._resource;
            }
        }

        /// <summary>
        /// Gets the list of resoruce keys.
        /// </summary>
        public IList<string> Keys
        {
            get
            {
                var keys = this.Resource != null ? this.Resource.GetKeys() : new List<string>();
                return keys;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the localisation resource data from the XML file.
        /// </summary>
        /// <param name="locale">Locale. Default is null.</param>
        /// <returns>Returns the localisation resource data.</returns>
        public IResource GetResource(string locale = null)
        {
            if (!String.IsNullOrWhiteSpace(locale))
                this._locale = locale;

            var element = this.Section.Resources[this.Locale];
            if (element == null)
                return null;

            var path = element.Src;
            if (!path.StartsWith("/"))
                path = "/" + path;

            if (this.Server != null)
            {
                if (!path.StartsWith("~"))
                    path = "~" + path;
                path = this.Server.MapPath(path);
            }
            else
            {
                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                directory = Regex.Replace(directory, "\\\\bin(\\\\Debug)?", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                path = Path.GetFullPath(directory + path);
            }

            var exists = File.Exists(path);
            if (!exists)
                return null;

            var xml = XDocument.Load(path);
            if (xml.Root == null)
                return null;

            if (xml.Root.Name != "resource")
                return null;

            if (xml.Root.Element("items") == null)
                return null;

            var items = xml.Root
                           .Element("items")
                           .Elements("item")
                           .ToList();

            var resource = items.Any() ? new Resource(items) : null;
            return resource;
        }

        /// <summary>
        /// Checks whether the key exists in the resource or not.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Returns <c>True</c>, if the key exists in the resource; otherwise returns <c>False</c>.</returns>
        public bool HasKey(string key)
        {
            var hasKey = this.Keys.Contains(key);
            return hasKey;
        }

        /// <summary>
        /// Gets the value corresponding to the key from the resource.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Returns the value corresponding to the key from the resource.</returns>
        public string GetValue(string key)
        {
            var value = this.Resource.GetValue(key);
            return value;
        }
        #endregion
    }
}
