using System;

/// <summary>
/// Extends all array base classes with iteration function ForEach
/// </summary>
/// <remarks>
/// This file as intentionally no namespace as the extensions methods will be loaded GLOBALLY
/// </remarks>
public static class ArrayExtensions {
  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <typeparam name="T">Type of the array items</typeparam>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach<T>(this T[] array, Action<T> func) where T : class {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <typeparam name="T">Type of the array items</typeparam>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach<T>(this T[] array, Action<T, int> func) where T : class {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this int[] array, Action<int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this int[] array, Action<int, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this long[] array, Action<long> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this long[] array, Action<long, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this float[] array, Action<float> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this float[] array, Action<float, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this bool[] array, Action<bool> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this bool[] array, Action<bool, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this double[] array, Action<double> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this double[] array, Action<double, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }

  /// <summary>
  /// Iterate over the elements
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item</param>
  public static void ForEach(this char[] array, Action<char> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i]);
  }

  /// <summary>
  /// Iterate over the elements including the index
  /// </summary>
  /// <param name="array">to be iterated</param>
  /// <param name="func">to be called per item with its index</param>
  public static void ForEach(this char[] array, Action<char, int> func) {
    for(int i = 0, imax = array.Length; i < imax; i++) func(array[i], i);
  }
}
