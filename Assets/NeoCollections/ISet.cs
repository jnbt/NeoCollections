using System;

namespace Neo.Collections{
  public interface ISet<T> : System.Collections.Generic.ICollection<T>,
                             System.Collections.Generic.IEnumerable<T>,
                             System.Collections.IEnumerable{
    void AddAll(System.Collections.Generic.IEnumerable<T> toAdd);
    void RemoveAll(System.Collections.Generic.IEnumerable<T> toAdd);
    void ForEach(Action<T> func);
    T Find(Predicate<T> func);
    Set<T> FindAll(Predicate<T> func);
    int Capacity{get; }
  }
}