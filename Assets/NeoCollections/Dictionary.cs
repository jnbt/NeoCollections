using System;

namespace Neo.Collections {
  /// <summary>
  /// Subclass of System.Collection.Generic.Dictionary
  /// </summary>
  /// <typeparam name="TKey">type of the keys</typeparam>
  /// <typeparam name="TValue">type of the values</typeparam>
  public class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>, IDictionary<TKey, TValue> {
    /// <summary>
    /// Instantiate a new dictionary with default capacity
    /// </summary>
    public Dictionary() : base() { }

    /// <summary>
    /// Instantiate a new dictionary using all members as initial state
    /// </summary>
    /// <param name="initial">to use as initial members</param>
    public Dictionary(System.Collections.Generic.IDictionary<TKey, TValue> initial) : base(initial) { }

    /// <summary>
    /// Instantiate a new dictionary with a custom comparer
    /// </summary>
    /// <param name="comparer">to use as comparer</param>
    public Dictionary(System.Collections.Generic.IEqualityComparer<TKey> comparer) : base(comparer) { }

    /// <summary>
    /// Instantiate a new dictionary with custom capacity
    /// </summary>
    /// <param name="capacity">to use</param>
    public Dictionary(int capacity) : base(capacity) { }

    /// <summary>
    /// Instantiate a new dictionary using all members as initial state and a custom comparer
    /// </summary>
    /// <param name="initial">to use a initial state</param>
    /// <param name="comparer">to use as comparer</param>
    public Dictionary(System.Collections.Generic.IDictionary<TKey, TValue> initial,
                      System.Collections.Generic.IEqualityComparer<TKey> comparer)
      : base(initial, comparer) { }

    /// <summary>
    /// Instantiate a new dictionary with a custom capacity and custom comparer
    /// </summary>
    /// <param name="capacity">to use</param>
    /// <param name="comparer">to use</param>
    public Dictionary(int capacity, System.Collections.Generic.IEqualityComparer<TKey> comparer) : base(capacity, comparer) { }

    /// <summary>
    /// Instantiate a new dictionary with serialized data
    /// </summary>
    /// <param name="info">information required to serialize</param>
    /// <param name="context">containing the source and destination of the serialized stream</param>
    protected Dictionary(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
      base(info, context) { }

    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">called per key and value</param>
    public void ForEach(Action<TKey, TValue> func) {
      Enumerator enumerator = GetEnumerator();
      while(enumerator.MoveNext()) {
        System.Collections.Generic.KeyValuePair<TKey, TValue> pair = enumerator.Current;
        func(pair.Key, pair.Value);
      }
    }

    /// <summary>
    /// Returns a new Dictionary including all members which evaluate to true
    /// </summary>
    /// <param name="func">called per key and value</param>
    /// <returns>new filtered Dictionary</returns>
    public Dictionary<TKey, TValue> FindAll(Func<TKey, TValue, bool> func) {
      Dictionary<TKey, TValue> selection = new Dictionary<TKey, TValue>();
      ForEach((k, v) => {
        if(func(k, v)) selection[k] = v;
      });
      return selection;
    }

    /// <summary>
    /// Returns the value for the key if it's present
    /// </summary>
    /// <param name="key">to be looked up</param>
    /// <returns>the found value or a default value</returns>
    public TValue Get(TKey key) {
      if(key != null && ContainsKey(key)) return base[key];
      else return default(TValue);
    }

    /// <summary>
    /// Check is a key is present in the Dictionary
    /// </summary>
    /// <param name="key">to be looked up</param>
    /// <returns>true if present</returns>
    public bool Has(TKey key) {
      return key != null && ContainsKey(key) && (this[key] != null);
    }

    /// <summary>
    /// Is the collection empty?
    /// </summary>
    public bool IsEmpty {
      get { return Count == 0; }
    }
  }
}
