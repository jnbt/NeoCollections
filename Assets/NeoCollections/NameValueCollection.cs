using System;

namespace Neo.Collections {
  /// <summary>
  /// A typical Name-Value-Collection
  /// </summary>
  public class NameValueCollection : System.Collections.Specialized.NameValueCollection {
    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">to be called per member</param>
    public void ForEach(Action<string, string> func) {
      this.AllKeys.ForEach(key => {
        func(key, this[key]);
      });
    }

    /// <summary>
    /// Iterates over the members and their indexes
    /// </summary>
    /// <param name="func">to be called per member and index</param>
    public void ForEach(Action<string, string, int> func) {
      int i = 0;
      this.AllKeys.ForEach(key => {
        func(key, this[key], i);
        i++;
      });
    }

    /// <summary>
    /// Is the collection empty?
    /// </summary>
    public bool IsEmpty {
      get { return this.Count <= 0; }
    }
  }
}
