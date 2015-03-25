using System;

namespace Neo.Collections{
  /// <summary>
  /// Represents a nongeneric collection of key/value pairs.
  /// </summary>
  public interface IDictionary : System.Collections.IDictionary{}

  /// <summary>
  /// Represents a generic collection of key/value pairs
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary</typeparam>
  public interface IDictionary<TKey,TValue> : System.Collections.Generic.IDictionary<TKey,TValue>,
                                              System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                              System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                              IDictionary,
                                              System.Runtime.Serialization.IDeserializationCallback,
                                              System.Runtime.Serialization.ISerializable{
    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">called per key and value</param>
    void ForEach(Action<TKey,TValue> func);
    /// <summary>
    /// Returns a new Dictionary including all members which evaluate to true
    /// </summary>
    /// <param name="func">called per key and value</param>
    /// <returns>new filtered Dictionary</returns>
    Dictionary<TKey,TValue> FindAll(Func<TKey,TValue,bool> func);
    /// <summary>
    /// Returns the value for the key if it's present
    /// </summary>
    /// <param name="key">to be looked up</param>
    /// <returns>the found value or a default value</returns>
    TValue Get(TKey key);
    /// <summary>
    /// Check is a key is present in the Dictionary
    /// </summary>
    /// <param name="key">to be looked up</param>
    /// <returns>true if present</returns>
    bool Has(TKey key);
  }
}
