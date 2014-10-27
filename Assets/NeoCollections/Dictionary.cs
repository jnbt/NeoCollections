using System;

namespace Neo.Collections{
  /// <summary>
  /// An AOT-safe subclass of System.Collection.Generic.Dictionary
  /// </summary>
  /// <typeparam name="TKey">type of the keys</typeparam>
  /// <typeparam name="TValue">type of the values</typeparam>
  public class Dictionary<TKey,TValue> : System.Collections.Generic.Dictionary<TKey,TValue>, IDictionary<TKey,TValue>{
    public Dictionary() : base(){ }
    public Dictionary(System.Collections.Generic.IDictionary<TKey,TValue> initial) : base(initial) { }
    public Dictionary(System.Collections.Generic.IEqualityComparer<TKey> comparer) : base(comparer) { }
    public Dictionary(int capacity) : base(capacity) {}
    public Dictionary(System.Collections.Generic.IDictionary<TKey,TValue> initial,
                      System.Collections.Generic.IEqualityComparer<TKey> comparer) : base(initial, comparer) { }
    public Dictionary(int capacity, System.Collections.Generic.IEqualityComparer<TKey> comparer) : base(capacity, comparer) {}

    protected Dictionary(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
              base(info, context){}

    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">called per key and value</param>
    public void ForEach(Action<TKey,TValue> func){
      Iterator.ForEach<object>(this, (obj) => {
        System.Collections.Generic.KeyValuePair<TKey,TValue> pair = (System.Collections.Generic.KeyValuePair<TKey,TValue>) obj;
        func(pair.Key, pair.Value);
      });
    }

    /// <summary>
    /// Returns a new Dictionary including all members which evaluate to true
    /// </summary>
    /// <param name="func">called per key and value</param>
    /// <returns>new filtered Dictionary</returns>
    public Dictionary<TKey,TValue> FindAll(Func<TKey,TValue,bool> func){
      Dictionary<TKey,TValue> selection = new Dictionary<TKey,TValue>();
      ForEach((k,v) => {
        if(func(k,v)) selection[k] = v;
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
    public bool Has(TKey key){
      return key != null && ContainsKey(key) && (this[key] != null);
    }

    /// <summary>
    /// Is the collection empty?
    /// </summary>
    public bool IsEmpty{
      get{ return Count == 0; }
    }
  }
}
