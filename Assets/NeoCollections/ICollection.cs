using System;

namespace Neo.Collections{
  public interface ICollection<T> : System.Collections.Generic.ICollection<T>,
                                    System.Collections.Generic.IEnumerable<T>{
    void ForEach(Action<T> func);
    void ForEach(Action<T,int> func);
    bool IsEmpty{get;}
  }
}