using System;
using System.Collections;
using System.Reflection;

namespace Neo.Collections {
  /// <summary>
  /// Mono's AOT compilation has problems with the generic interface IEnumerable,
  /// the message which appears is "System.String doesn't implement interface System.Collections.IEnumerator".
  /// See http://forum.unity3d.com/threads/168019-quot-System-String-doesn-t-implement-interface-System-Collections-IEnumerator-quot-crash
  ///
  /// More on this issue at mono docs: http://www.mono-project.com/AOT#Limitation:_Generic_Interface_Instantiation
  ///
  /// This class is a helper to iterate over any enumerable by using reflection to find the
  /// NON GENERIC "GetEnumerator" method manually casting the items to the given type.
  /// </summary>
  /// <example><![CDATA[
  ///   List<MyClass> list = new List<MyClass>();
  ///   ...fill list...
  ///   Utils.Iterator.ForEach<MyClass>(list, (item) => {
  ///     ...do something with item which already is type-casted to MyClass
  ///   });
  /// ]]></example>
  public static class Iterator {
    public static void ForEach<T>(object enumerable, Action<T> action) {
      if(enumerable == null) return;

      Type listType = findListType(enumerable);

      MethodInfo method = listType.GetMethod("GetEnumerator");
      if(method == null) {
        throw new InvalidOperationException("Failed to get 'GetEnumberator()' method info from IEnumerable type");
      }
      IEnumerator enumerator = null;

      try {
        enumerator = (IEnumerator) method.Invoke(enumerable, null);
        if(enumerator is IEnumerator) {
          while(enumerator.MoveNext()) action((T) enumerator.Current);
        } else {
          UnityEngine.Debug.LogWarning(string.Format("{0}.GetEnumerator() returned '{1}' instead of IEnumerator.",
            enumerable.ToString(),
            enumerator.GetType().Name));
        }
      } finally {
        IDisposable disposable = enumerator as IDisposable;
        if(disposable != null) disposable.Dispose();
      }
    }

    public static void ForEach<T>(object enumerable, Action<T, int> action) {
      if(enumerable == null) return;

      Type listType = findListType(enumerable);

      MethodInfo method = listType.GetMethod("GetEnumerator");
      if(method == null) {
        throw new InvalidOperationException("Failed to get 'GetEnumberator()' method info from IEnumerable type");
      }
      IEnumerator enumerator = null;

      try {
        enumerator = (IEnumerator) method.Invoke(enumerable, null);
        if(enumerator is IEnumerator) {
          int i = 0;
          while(enumerator.MoveNext()) action((T) enumerator.Current, i++);
        } else {
          UnityEngine.Debug.LogWarning(string.Format("{0}.GetEnumerator() returned '{1}' instead of IEnumerator.",
            enumerable.ToString(),
            enumerator.GetType().Name));
        }
      } finally {
        IDisposable disposable = enumerator as IDisposable;
        if(disposable != null) disposable.Dispose();
      }
    }

    private static Type findListType(object enumerable) {
      Type[] interfaces = enumerable.GetType().GetInterfaces();
      Type listType = null;
      for(int i=interfaces.Length - 1; i >= 0; --i) {
        Type item = interfaces[i];
        if(!item.IsGenericType && item == typeof(IEnumerable)) {
          listType = item;
          break;
        }
      }
      return listType;
    }
  }
}
