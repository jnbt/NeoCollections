using System;

namespace Neo.Collections{
  /// <summary>
  /// Defines methods to manipulate generic collections
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ICollection<T> : System.Collections.Generic.ICollection<T>,
                                    System.Collections.Generic.IEnumerable<T>{
    /// <summary>
    /// Iterates over the collection and calls the func for each member
    /// </summary>
    /// <param name="func">to be called per member</param>
    void ForEach(Action<T> func);
    /// <summary>
    /// Iterates over the collection and calls the func for each member
    /// </summary>
    /// <param name="func">to be called per member with it's index</param>
    void ForEach(Action<T,int> func);
    /// <summary>
    /// True if the collection is empty
    /// </summary>
    bool IsEmpty{get;}
  }
}
