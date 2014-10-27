using System;

namespace Neo.Collections{
  public class Queue<T> : ICollection<T>{
    private readonly List<T> list;

    public Queue(){
      list = new List<T>();
    }
    public Queue(int capacity){
      list = new List<T>(capacity);
    }
    public Queue(System.Collections.Generic.IEnumerable<T> initial) {
      list = new List<T>(initial);
    }

    //This is a Enqueue operation
    public void Add(T item){
      list.Add(item);
    }

    //This is NOT a dequeue operation
    public bool Remove(T item){
      return list.Remove(item);
    }

    public T First{
      get{
        if(Count > 0) return list[0];
        else return default(T);
      }
    }

    public T Last{
      get{
        if(Count > 0) return list[Count-1];
        else return default(T);
      }
    }

    public T Dequeue(){
      if(Count > 0){
        T item = list[0];
        list.RemoveAt(0);
        return item;
      } else return default(T);
    }

    public int Count{
      get{ return list.Count; }
    }

    public int Capacity{
      get{ return list.Capacity; }
    }

    public bool IsReadOnly{
      get{ return false; }
    }

    public void ForEach(Action<T> func){
      list.ForEach(func);
    }

    public void ForEach(Action<T,int> func){
      list.ForEach(func);
    }

    public void Clear(){
      list.Clear();
    }

    public bool Contains(T item){
      return list.Contains(item);
    }

    public void CopyTo(T[] array, int index){
      list.CopyTo(array, index);
    }

    public void CopyTo(T[] array){
      list.CopyTo(array);
    }

    System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator(){
      return list.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
      return (list as System.Collections.IEnumerable).GetEnumerator();
    }

    public bool IsEmpty{
      get{ return Count == 0; }
    }
  }
}