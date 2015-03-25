using System;

namespace Neo.Collections{
  /// <summary>
  /// Represents a non-generic collection of objects that can be individually accessed by index
  /// </summary>
  public interface IList : System.Collections.IList{
    /// <summary>
    /// Checks if a non-null value is present at the index
    /// </summary>
    /// <param name="index">to be checked</param>
    /// <returns>True if a non-null exists at the index</returns>
    bool HasItemAt(int index);
  }

  /// <summary>
  /// Represents a collection of objects that can be individually accessed by index
  /// </summary>
  /// <typeparam name="T">The type of elements in the list</typeparam>
  public interface IList<T> : ICollection<T>,
                              IList{
    /// <summary>
    /// Returns a new list which all members which match the predicate.
    /// </summary>
    /// <param name="func">to check each member</param>
    /// <returns>a filtered list</returns>
    List<T> FindAll(Predicate<T> func);
    /// <summary>
    /// Returns a new list which all members which match the predicate.
    /// </summary>
    /// <param name="func">to check each member with it's index</param>
    /// <returns>a filtered list</returns>
    List<T> FindAll(Func<T,int,bool> func);
  }
}
