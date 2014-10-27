using System;

namespace Neo.Collections{
  public interface IDictionary : System.Collections.IDictionary{}

  public interface IDictionary<TKey,TValue> : System.Collections.Generic.IDictionary<TKey,TValue>,
                                              System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                              System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,
                                              IDictionary,
                                              System.Runtime.Serialization.IDeserializationCallback,
                                              System.Runtime.Serialization.ISerializable{
    void ForEach(Action<TKey,TValue> func);
    Dictionary<TKey,TValue> FindAll(Func<TKey,TValue,bool> func);
    TValue Get(TKey key);
    bool Has(TKey key);
  }
}