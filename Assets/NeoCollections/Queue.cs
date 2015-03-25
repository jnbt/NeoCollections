using System;

namespace Neo.Collections {
  /// <summary>
  /// A generic implemenation of a queue
  /// </summary>
  /// <typeparam name="T">of items</typeparam>
  public class Queue<T> : ICollection<T> {
    private readonly List<T> list;

    /// <summary>
    /// Instantiate a new queue with default capacity
    /// </summary>
    public Queue() {
      list = new List<T>();
    }

    /// <summary>
    /// Instiantiate a new queue with desired capacity
    /// </summary>
    /// <param name="capacity">to use</param>
    public Queue(int capacity) {
      list = new List<T>(capacity);
    }

    /// <summary>
    /// Instiate a new queue using all members of the given IEnumerable
    /// </summary>
    /// <param name="initial">to use as initial members</param>
    public Queue(System.Collections.Generic.IEnumerable<T> initial) {
      list = new List<T>(initial);
    }

    /// <summary>
    /// This is a enqueue operation
    /// </summary>
    /// <param name="item">to be added at the end of the queue</param>
    public void Add(T item) {
      list.Add(item);
    }

    /// <summary>
    /// Removes the first occurance of the item from the queue. (This is a NOT a dequeue operation)
    /// </summary>
    /// <param name="item">to be removed</param>
    /// <returns>true if the item was a member</returns>
    public bool Remove(T item) {
      return list.Remove(item);
    }

    /// <summary>
    /// Returns the first item of the queue
    /// </summary>
    public T First {
      get {
        if(Count > 0) return list[0];
        else return default(T);
      }
    }

    /// <summary>
    /// Returns the last item of the queue
    /// </summary>
    public T Last {
      get {
        if(Count > 0) return list[Count - 1];
        else return default(T);
      }
    }

    /// <summary>
    /// Dequeues the frist item of the queue
    /// </summary>
    /// <returns>the former first item</returns>
    public T Dequeue() {
      if(Count > 0) {
        T item = list[0];
        list.RemoveAt(0);
        return item;
      } else return default(T);
    }

    /// <summary>
    /// Number of members in the queue
    /// </summary>
    public int Count {
      get { return list.Count; }
    }

    /// <summary>
    /// Current capacity of the queue
    /// </summary>
    public int Capacity {
      get { return list.Capacity; }
    }

    /// <summary>
    /// True if it's a readonly collection
    /// </summary>
    public bool IsReadOnly {
      get { return false; }
    }

    /// <summary>
    /// Iterates over the members
    /// </summary>
    /// <param name="func">to be called per member</param>
    public void ForEach(Action<T> func) {
      list.ForEach(func);
    }

    /// <summary>
    /// Iterates over the members and their indexes
    /// </summary>
    /// <param name="func">to be called per member and index</param>
    public void ForEach(Action<T, int> func) {
      list.ForEach(func);
    }

    /// <summary>
    /// Clears the whole queue
    /// </summary>
    public void Clear() {
      list.Clear();
    }

    /// <summary>
    /// Detects if the queues contains the item
    /// </summary>
    /// <param name="item">to be looked up</param>
    /// <returns>true if the item is a member</returns>
    public bool Contains(T item) {
      return list.Contains(item);
    }

    /// <summary>
    /// Copies the content into an array started at the index
    /// </summary>
    /// <param name="array">target array</param>
    /// <param name="index">to start at</param>
    public void CopyTo(T[] array, int index) {
      list.CopyTo(array, index);
    }

    /// <summary>
    /// Copies the content into an array
    /// </summary>
    /// <param name="array">target array</param>
    public void CopyTo(T[] array) {
      list.CopyTo(array);
    }

    /// <summary>
    /// Returns an enumerator, in index order, that can be used to iterate over the queue
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() {
      return list.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator, in index order, that can be used to iterate over the queue
    /// </summary>
    /// <returns>An enumerator for the list</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
      return (list as System.Collections.IEnumerable).GetEnumerator();
    }

    /// <summary>
    /// Is the collection empty?
    /// </summary>
    public bool IsEmpty {
      get { return Count == 0; }
    }
  }
}
