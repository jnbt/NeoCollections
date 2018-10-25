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

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <returns>The all.</returns>
  /// <param name="array">Array.</param>
  /// <param name="func">Func.</param>
  /// <typeparam name="T">The type of the array</typeparam>
  /// <typeparam name="TOutput">The converter's result</typeparam>
  public static TOutput[] ConvertAll<T,TOutput>(this T[] array, Func<T, TOutput> func) where T : class {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this int[] array, Func<int, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this long[] array, Func<long, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this float[] array, Func<float, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this double[] array, Func<double, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this bool[] array, Func<bool, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }

  /// <summary>
  /// Returns a new array by converting each member using the converter
  /// </summary>
  /// <typeparam name="TOutput">of converter's result</typeparam>
  /// <param name="array">to be converted</param>
  /// <param name="func">to convert each member</param>
  /// <returns>a converted array</returns>
  public static TOutput[] ConvertAll<TOutput>(this char[] array, Func<char, TOutput> func) {
    TOutput[] o = new TOutput[array.Length];
    for(int i = 0, imax = array.Length; i < imax; i++) o[i] = func(array[i]);
    return o;
  }
}
