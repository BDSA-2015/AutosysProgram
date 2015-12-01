using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// This class is used as an extension of numerous enums represented in entities like e.g. DataField, Role and TaskRequest.
    /// Data annotations are used in entities to map the string to the database and ignore the enum.
    /// </summary>
    public class EnumExtensions
    {

        /// <summary>
        /// Returns the correct enum from a given string.
        /// </summary>
        /// <typeparam name="T">
        /// Expected enum from string in database.
        /// </typeparam>
        /// <param name="value">
        /// String in database used to represent enum. 
        /// </param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }

}
