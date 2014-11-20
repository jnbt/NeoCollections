using System;

namespace Neo.Collections{
  public interface IList : System.Collections.IList{
    bool HasItemAt(int index);
  }

  public interface IList<T> : ICollection<T>,
                              IList{
    List<T> FindAll(Predicate<T> func);
    List<T> FindAll(Func<T,int,bool> func);
  }
}
