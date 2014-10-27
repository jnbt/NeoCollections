using System;

namespace Neo.Collections{
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

    public void ForEach(Action<TKey,TValue> func){
      Iterator.ForEach<object>(this, (obj) => {
        System.Collections.Generic.KeyValuePair<TKey,TValue> pair = (System.Collections.Generic.KeyValuePair<TKey,TValue>) obj;
        func(pair.Key, pair.Value);
      });
    }

    public Dictionary<TKey,TValue> FindAll(Func<TKey,TValue,bool> func){
      Dictionary<TKey,TValue> selection = new Dictionary<TKey,TValue>();
      ForEach((k,v) => {
        if(func(k,v)) selection[k] = v;
      });
      return selection;
    }

    public TValue Get(TKey key) {
      if(key != null && ContainsKey(key)) return base[key];
      else return default(TValue);
    }

    public bool Has(TKey key){
      return key != null && ContainsKey(key) && (this[key] != null);
    }

    public bool IsEmpty{
      get{ return Count == 0; }
    }
  }
}