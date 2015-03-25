using System;

namespace Neo.Collections{
  /// <summary>
  /// A set is a collection which allows a single member to only be
  /// included exactly once
  /// </summary>
  /// <typeparam name="T">The type of elements in the set</typeparam>
  public interface ISet<T> : System.Collections.Generic.ICollection<T>,
                             System.Collections.Generic.IEnumerable<T>,
                             System.Collections.IEnumerable{
    /// <summary>
    /// Tries to add every item
    /// </summary>
    /// <param name="toAdd">items to add</param>
    void AddAll(System.Collections.Generic.IEnumerable<T> toAdd);
    /// <summary>
    /// Tries to remove every given item
    /// </summary>
    /// <param name="toRemove">items to remove</param>
    void RemoveAll(System.Collections.Generic.IEnumerable<T> toRemove);
    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">to be called per member</param>
    void ForEach(Action<T> func);
    /// <summary>
    /// Finds the first member in the set which matches the predicate
    /// </summary>
    /// <param name="func">to check the members</param>
    /// <returns>The first match</returns>
    T Find(Predicate<T> func);
    /// <summary>
    /// Gather a new set containing all matching members
    /// </summary>
    /// <param name="func">to check each member</param>
    /// <returns>A new set</returns>
    Set<T> FindAll(Predicate<T> func);
    /// <summary>
    /// Current capacity of the set
    /// </summary>
    int Capacity{get; }
  }
}
