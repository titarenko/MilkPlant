using System;
using System.Configuration;
using System.Globalization;

namespace MilkPlant.Shared
{
    /// <summary>
    /// Provides access to configuration values. Behaves like dictionary.
    /// </summary>
    public class Configuration : IConfiguration
    {
        private readonly string prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration() : this(null)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        public Configuration(string prefix)
        {
            this.prefix = prefix;
        }

        /// <summary>
        /// Returns subsection by name.
        /// </summary>
        /// <param name="name">Subsection name.</param>
        /// <returns>Configuration instance representing requested subsection.</returns>
        public IConfiguration GetSubsection(string name)
        {
            return new Configuration(name);
        }

        /// <summary>
        /// Returns value by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value if key exists. Otherwise null.</returns>
        public string GetValue(string key)
        {
            if (prefix != null)
            {
                key = string.Format("{0}.{1}", prefix, key);
            }
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Returns value converted to requested type by key.
        /// </summary>
        /// <typeparam name="T">Type of returned value.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Value converted to requested type.</returns>
        public T GetValue<T>(string key)
        {
            return (T) Convert.ChangeType(GetValue(key), typeof (T), CultureInfo.InvariantCulture);
        }
    }
}