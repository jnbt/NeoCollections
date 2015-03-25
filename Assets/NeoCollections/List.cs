using System;
using System.Text;

namespace Neo.Collections {
  /// <summary>
  /// This subclasses the default generic list class but overwrite a lot of iOS unsafe
  /// methods, which can fail because of the AOT compilation
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class List<T> : System.Collections.Generic.List<T>, IList<T> {
    /// <summary>
    /// Instantiate a new list with default capacity
    /// </summary>
    public List() : base() { }

    /// <summary>
    /// Instiantiate a new list with desired capacity
    /// </summary>
    /// <param name="capacity">to use</param>
    public List(int capacity) : base(capacity) { }

    /// <summary>
    /// Instiate a new list using all members of the given IEnumerable
    /// </summary>
    /// <param name="initial">to use as initial members</param>
    public List(System.Collections.Generic.IEnumerable<T> initial) : base() {
      System.Collections.Generic.IEnumerator<T> enumerator = initial.GetEnumerator();
      while(enumerator.MoveNext()) Add(enumerator.Current);
    }

    /// <summary>
    /// Iterates over the collection and calls the func for each member
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <param name="func">to be called per member</param>
    public new void ForEach(Action<T> func) {
      for(int i = 0, imax = Count; i < imax; i++) func(this[i]);
    }

    /// <summary>
    /// Iterates over the collection and calls the func for each member
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <param name="func">to be called per member with it's index</param>
    public void ForEach(Action<T, int> func) {
      for(int i = 0, imax = Count; i < imax; i++) func(this[i], i);
    }

    /// <summary>
    /// Returns a new list which all members which match the predicate.
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <param name="func">to check each member</param>
    /// <returns>a filtered list</returns>
    public new List<T> FindAll(Predicate<T> func) {
      List<T> selection = new List<T>();
      ForEach((item) => {
        if(func(item)) selection.Add(item);
      });
      return selection;
    }

    /// <summary>
    /// Returns a new list which all members which match the predicate.
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <param name="func">to check each member with it's index</param>
    /// <returns>a filtered list</returns>
    public List<T> FindAll(Func<T, int, bool> func) {
      List<T> selection = new List<T>();
      ForEach((item, index) => {
        if(func(item, index)) selection.Add(item);
      });
      return selection;
    }

    /// <summary>
    /// Returns a new list by converting each member using the converter
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <typeparam name="TOutput">of converter's result</typeparam>
    /// <param name="converter">to convert each member</param>
    /// <returns>a converted list</returns>
    public new List<TOutput> ConvertAll<TOutput>(System.Converter<T, TOutput> converter) {
      List<TOutput> converted = new List<TOutput>(Count);
      ForEach((item) => {
        converted.Add(converter(item));
      });
      return converted;
    }

    /// <summary>
    /// Finds the first member which matches the predicate
    /// </summary>
    /// <remarks>
    /// This must be a hard override as the native ForEach function might break on iOS after AOT compilation
    /// </remarks>
    /// <param name="func">to check the members</param>
    /// <returns>A single value or default</returns>
    public new T Find(Predicate<T> func) {
      for(int i=0, imax = Count; i < imax; i++) {
        T item = this[i];
        if(func(item)) return item;
      }
      return default(T);
    }

    /// <summary>
    /// True if the collection is empty
    /// </summary>
    public bool IsEmpty {
      get { return Count == 0; }
    }

    /// <summary>
    /// The first member or default
    /// </summary>
    public T First {
      get{
        if(Count > 0) return this[0];
        return default(T);
      }
    }

    /// <summary>
    /// The last member or default
    /// </summary>
    public T Last {
      get{
        if(Count > 0) return this[Count - 1];
        return default(T);
      }
    }

    /// <summary>
    /// Retruns a new list but omits all null values
    /// </summary>
    public List<T> AsCompact {
      get {
        List<T> result = new List<T>();
        ForEach((item) => {
          if(item != null) result.Add(item);
        });
        return result;
      }
    }

    /// <summary>
    /// Splices the collection using the bounds
    /// </summary>
    /// <param name="lower">as lower bound</param>
    /// <param name="count">as upper bound</param>
    /// <returns>a spliced list</returns>
    public List<T> Splice(int lower, int count) {
      if(lower < 0) throw new IndexOutOfRangeException("Lower cannot be less than zero");
      if(count < 0) throw new IndexOutOfRangeException("Count cannot be less than zero");
      int max   = Count - 1;
      int upper = lower + (count - 1);
      if(upper > max) upper = max;
      List<T> result = new List<T>();
      for(int i=lower; i <= upper; i++) {
        result.Add(this[i]);
      }
      return result;
    }

    /// <summary>
    /// Joins all members into a single string, by calling ToString per member and
    /// joining the results usint the separator
    /// </summary>
    /// <param name="seperator">between member strings</param>
    /// <returns>a combined string</returns>
    public string Join(string seperator = null) {
      if(IsEmpty) return "";

      StringBuilder builder = new StringBuilder();
      if(string.IsNullOrEmpty(seperator)) {
        ForEach((item) => {
          if(item != null) builder.Append(item.ToString());
        });
      } else {
        ForEach((item, i) => {
          if(i > 0) builder.Append(seperator);
          string what = (item != null) ? item.ToString() : "";
          builder.Append(what);
        });
      }
      return builder.ToString();
    }

    /// <summary>
    /// Shuffle the items in the list based on a Fisher-Yates shuffle
    /// </summary>
    /// <param name="rng">a random source</param>
    public void Shuffle(Random rng = null) {
      if(rng == null) rng = new Random();
      int n = this.Count;
      while(n > 1) {
        n--;
        int k = rng.Next(n + 1);
        T value = this[k];
        this[k] = this[n];
        this[n] = value;
      }
    }

    /// <summary>
    /// Checks if a non-null value is present at the index
    /// </summary>
    /// <param name="index">to be checked</param>
    /// <returns>True if a non-null exists at the index</returns>
    public bool HasItemAt(int index) {
      return (index >= 0) && (Count - 1 >= index) && (this[index] != null);
    }

    /// <summary>
    /// Builds a new combined list. 
    /// </summary>
    /// <param name="one">first members in new list</param>
    /// <param name="two">second members in new list</param>
    /// <returns>a combined list</returns>
    public static List<T> operator +(List<T> one, List<T> two) {
      List<T> result = new List<T>(one.Count + two.Count);
      result.AddRange(one);
      result.AddRange(two);
      return result;
    }

    /// <summary>
    /// Builds a new list returning all members from the first list
    /// which are not present in the second list.
    /// </summary>
    /// <param name="one">member to use</param>
    /// <param name="two">member not to use</param>
    /// <returns>a reduced list</returns>
    public static List<T> operator -(List<T> one, List<T> two) {
      List<T> result = new List<T>(one);
      two.ForEach((item) => result.Remove(item));
      return result;
    }
  }
}
