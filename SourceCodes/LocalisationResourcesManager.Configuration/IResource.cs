using System.Collections.Generic;

namespace Aliencube.Utilities.LocalisationResourcesManager.Configuration
{
    /// <summary>
    /// This provides interfaces for the Resource class.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Gets the list of keys from the resource.
        /// </summary>
        /// <returns>Returns the list of keys from the resource.</returns>
        IList<string> GetKeys();

        /// <summary>
        /// Gets the value corresponding to the key from the resource.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Returns the value corresponding to the key from the resource.</returns>
        string GetValue(string key);
    }
}
