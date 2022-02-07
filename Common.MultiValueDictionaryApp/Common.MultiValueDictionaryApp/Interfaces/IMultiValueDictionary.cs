using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MultiValueDictionaryApp.Interfaces
{
    public interface IMultiValueDictionary<TKey, TValue>
    {
        /// <summary>
        ///     Gets a collection containing the keys in the MultiValueDictionary
        ///  
        /// Returns:
        ///     A ICollection containing the keys in the MultiValueDictionary
        /// </summary>
        public ICollection<TKey> Keys { get; }

        /// <summary>
        /// Returns the members of the given key.
        /// </summary>
        /// <param name="key">The key to check in the dictionary</param>
        /// <returns>A collection of members if the key exists in the dictionary</returns>
        /// <exception cref="KeyNotExistsException">throws KeyNotExistsException exception when key is not present in the dictionary</exception>
        public ICollection<TValue> Members(TKey key);

        /// <summary>
        /// Add value of type TValue into the dictionary for the given key of type TKey 
        /// when the TValue is not present for TKey
        /// </summary>
        /// <param name="key">The key for which the value need to inserted</param>
        /// <param name="value">the value to be inserted for the given key</param>
        /// <returns>true if value is added for the given key</returns>
        /// <exception cref="MemberAlreadyExistsException">Throws MemberAlreadyExistsException exception if the value already exists for the given key
        /// </exception>

        public bool Add(TKey key, TValue value);

        /// <summary>
        /// Removes a value for the given key in dictionary.
        /// Removes the key if the value is the last one to be deleted.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>returns true if the value is removed for the given key</returns>
        /// <exception cref="KeyNotExistsException">Throws KeyNotExistsException exception when key is not present in the dictionary</exception>
        /// <exception cref="MemberNotExistsException">Throws MemberNotExistsException exception when value is not present for the given key in the dictionary</exception>
        public bool Remove(TKey key, TValue value);

        /// <summary>
        /// Removes the key and all the values for the given key in the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if successfully removed the key and all values for the key </returns>
        /// <exception cref="KeyNotExistsException">throws KeyNotExistsException exception if key is not present in the dictionary</exception>
        public bool RemoveAll(TKey key);

        /// <summary>
        /// Removes all the keys and values from the dictionary
        /// </summary>
        public void Clear();

        /// <summary>
        /// Determines if the key is present in the dictionary
        /// </summary>
        /// <param name="key">The key to check in the dictionary</param>
        /// <returns>True if the key is present in the dictionary. Otherwise false.</returns>
        public bool KeyExists(TKey key);

        /// <summary>
        /// Determines if the value is present in the values of the given key 
        /// </summary>
        /// <param name="key">The key for the values in which the value has to be checked</param>
        /// <param name="value">The value to be verified for the given key</param>
        /// <returns>True if the key has the value otherwise false.</returns>
        public bool MemberExists(TKey key, TValue value);

        /// <summary>
        ///  Gets a Collection of all values of all the keys in the dictionary.
        /// </summary>
        /// <returns> A collection of all the values of all the keys in the dictionary. Null if the dictionary is empty</returns>
        public ICollection<TValue> AllMembers();

        /// <summary>
        /// Gets all the keys and all thier values from the dictionary.
        /// </summary>
        /// <returns>A List<KeyValuePair<TKey,TValue>> if dictionary has keys and values. Null if the dictionary is empty.</returns>
        public List<KeyValuePair<TKey, TValue>>? Items();
    }
}
