using System;

namespace Neo.Collections{
  public class Stack<T> : ICollection<T>{
    private readonly List<T> list;

    public Stack(){
      list = new List<T>();
    }
    public Stack(int capacity){
      list = new List<T>(capacity);
    }
    public Stack(System.Collections.Generic.IEnumerable<T> initial) {
      list = new List<T>(initial);
    }

    //This is a push operation
    public void Add(T item){
      list.Insert(0, item);
    }

    //This is NOT a Pop operation
    public bool Remove(T item){
      return list.Remove(item);
    }

    public T Peek{
      get{
        if(Count > 0) return list[0];
        else return default(T);
      }
    }

    public T Pop(){
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