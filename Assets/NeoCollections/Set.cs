using System;

namespace Neo.Collections{
  /// <summary>
  /// A set is a collection which allows a single member to only be
  /// included exactly once.
  /// </summary>
  /// <typeparam name="T">of items</typeparam>
  public class Set<T> : ISet<T>{
    private List<T> list;

    /// <summary>
    /// Instantiate a new set with default capacity
    /// </summary>
    public Set(){
      list = new List<T>();
    }

    /// <summary>
    /// Instiantiate a new set with desired capacity
    /// </summary>
    /// <param name="capacity">to use</param>
    public Set(int capacity){
      list = new List<T>(capacity);
    }

    /// <summary>
    /// Instiate a new queue using all members of the given IEnumerable
    /// </summary>
    /// <param name="initial">to use as initial members</param>
    public Set(System.Collections.Generic.IEnumerable<T> initial) : this(){
      AddAll(initial);
    }

    /// <summary>
    /// Number of members in the set
    /// </summary>
    public int Count{
      get{ return list.Count; }
    }

    /// <summary>
    /// Is the collection empty?
    /// </summary>
    public bool IsEmpty{
      get{ return list.Count == 0;}
    }

    /// <summary>
    /// True if it's a readonly collection
    /// </summary>
    public bool IsReadOnly{
      get{ return false; }
    }

    /// <summary>
    /// Current capacity of the set
    /// </summary>
    public int Capacity{
      get{ return list.Capacity; }
    }

    /// <summary>
    /// Gets or sets the element at the specified index of the current instance
    /// </summary>
    /// <param name="index">The zero-based index of the element in the current instance to get or set</param>
    /// <returns>The element at the specified index of the current instance</returns>
    public T this[int index] {
      get {
        return list[index];
      }
      protected set {
        list[index] = value;
      }
    }

    /// <summary>
    /// Tries to add every item
    /// </summary>
    /// <param name="toAdd">items to add</param>
    public void AddAll(System.Collections.Generic.IEnumerable<T> toAdd){
      System.Collections.Generic.IEnumerator<T> enumerator = toAdd.GetEnumerator();
      while(enumerator.MoveNext()) Add(enumerator.Current);
    }

    /// <summary>
    /// Tries to remove every given item
    /// </summary>
    /// <param name="toRemove">items to remove</param>
    public void RemoveAll(System.Collections.Generic.IEnumerable<T> toRemove){
      System.Collections.Generic.IEnumerator<T> enumerator = toRemove.GetEnumerator();
      while(enumerator.MoveNext()) Remove(enumerator.Current);
    }

    /// <summary>
    /// Adds an item to the set
    /// </summary>
    /// <param name="item">to add</param>
    public void Add(T item){
      if(list.Contains(item)) throw new ArgumentException("Item already in set");
      else list.Add(item);
    }

    /// <summary>
    /// Adds an item to the set
    /// </summary>
    /// <param name="item">to add</param>
    /// <returns>True if wasn't previously in the collection</returns>
    public bool TryAdd(T item){
      if(list.Contains(item)) return false;
      list.Add(item);
      return true;
    }

    /// <summary>
    /// Removes an item
    /// </summary>
    /// <param name="item">to remove</param>
    /// <returns>true if the item was a member</returns>
    public bool Remove(T item){
      if(list.Contains(item)){
        list.Remove(item);
        return true;
      } else return false;
    }

    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">to be called per member</param>
    public void ForEach(Action<T> func){
      list.ForEach(func);
    }

    /// <summary>
    /// Finds the first member in the set which matches the predicate
    /// </summary>
    /// <param name="func">to check the members</param>
    /// <returns>The first match</returns>
    public T Find(Predicate<T> func){
      return list.Find(func);
    }

    /// <summary>
    /// Gather a new set containing all matching members
    /// </summary>
    /// <param name="func">to check each member</param>
    /// <returns>A new set</returns>
    public Set<T> FindAll(Predicate<T> func){
      Set<T> selection = new Set<T>();
      ForEach((item) => {
        if(func(item)) selection.Add(item);
      });
      return selection;
    }

    /// <summary>
    /// Clears the whole set
    /// </summary>
    public void Clear(){
      list.Clear();
    }

    /// <summary>
    /// Detects if the set contains the item
    /// </summary>
    /// <param name="item">to be looked up</param>
    /// <returns>true if the item is a member</returns>
    public bool Contains(T item){
      return list.Contains(item);
    }

    /// <summary>
    /// Copies the content into an array started at the index
    /// </summary>
    /// <param name="array">target array</param>
    /// <param name="index">to start at</param>
    public void CopyTo(T[] array, int index){
      list.CopyTo(array, index);
    }

    /// <summary>
    /// Copies the content into an array
    /// </summary>
    /// <param name="array">target array</param>
    public void CopyTo(T[] array){
      list.CopyTo(array);
    }

    /// <summary>
    /// Returns an enumerator, in index order, that can be used to iterate over the queue
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator(){
      return list.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator, in index order, that can be used to iterate over the queue
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
      return (list as System.Collections.IEnumerable).GetEnumerator();
    }

    /// <summary>
    /// Builds a new set by addition (UNION)
    /// </summary>
    /// <param name="one">first set</param>
    /// <param name="two">second set</param>
    /// <returns>A union of both sets</returns>
    public static Set<T> operator +(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>(one.Count);
      result.AddAll(one);
      two.ForEach((item) => {
        if(!result.Contains(item)) result.Add(item);
      });
      return result;
    }

    /// <summary>
    /// Builds a new set by substraction
    /// </summary>
    /// <param name="one">first set</param>
    /// <param name="two">to substract</param>
    /// <returns>All members form one which are not in two</returns>
    public static Set<T> operator -(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>();
      one.ForEach((item) => {
        if(!two.Contains(item)) result.Add(item);
      });
      return result;
    }

    /// <summary>
    /// Builds a new set by intersection
    /// </summary>
    /// <param name="other">to intersect</param>
    /// <returns>A intersection of both</returns>
    public Set<T> IntersectWith(Set<T> other){
      return Intersect(this, other);
    }

    /// <summary>
    /// Builds a new set by intersection
    /// </summary>
    /// <param name="one">first set</param>
    /// <param name="two">second set</param>
    /// <returns>A intersection of both</returns>
    public static Set<T> Intersect(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>();
      one.ForEach((item) => {
        if(two.Contains(item)) result.Add(item);
      });
      return result;
    }
  }
}
