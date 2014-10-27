using System;

namespace Neo.Collections{
  public class Set<T> : ISet<T>{
    private List<T> list;

    public Set(){
      list = new List<T>();
    }
    public Set(int capacity){
      list = new List<T>(capacity);
    }
    public Set(System.Collections.Generic.IEnumerable<T> initial) : this(){
      AddAll(initial);
    }

    public int Count{
      get{ return list.Count; }
    }

    public bool IsEmpty{
      get{ return list.Count == 0;}
    }

    public bool IsReadOnly{
      get{ return false; }
    }

    public int Capacity{
      get{ return list.Capacity; }
    }

    public void AddAll(System.Collections.Generic.IEnumerable<T> toAdd){
      Iterator.ForEach<T>(toAdd, Add);
    }

    public void RemoveAll(System.Collections.Generic.IEnumerable<T> toRemove){
      Iterator.ForEach<T>(toRemove, (item) => {
        Remove(item); // ignore return value
      });
    }

    public void Add(T item){
      if(list.Contains(item)) throw new ArgumentException("Item already in set");
      else list.Add(item);
    }

    public bool TryAdd(T item){
      if(list.Contains(item)) return false;
      list.Add(item);
      return true;
    }

    public bool Remove(T item){
      if(list.Contains(item)){
        list.Remove(item);
        return true;
      } else return false;
    }

    public void ForEach(Action<T> func){
      list.ForEach(func);
    }

    public T Find(Predicate<T> func){
      return list.Find(func);
    }

    public Set<T> FindAll(Predicate<T> func){
      Set<T> selection = new Set<T>();
      ForEach((item) => {
        if(func(item)) selection.Add(item);
      });
      return selection;
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

    public static Set<T> operator +(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>(one.Count);
      result.AddAll(one);
      two.ForEach((item) => {
        if(!result.Contains(item)) result.Add(item);
      });
      return result;
    }

    public static Set<T> operator -(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>();
      one.ForEach((item) => {
        if(!two.Contains(item)) result.Add(item);
      });
      return result;
    }

    public Set<T> IntersectWith(Set<T> other){
      return Intersect(this, other);
    }

    public static Set<T> Intersect(Set<T> one, Set<T> two){
      Set<T> result = new Set<T>();
      one.ForEach((item) => {
        if(two.Contains(item)) result.Add(item);
      });
      return result;
    }

  }
}