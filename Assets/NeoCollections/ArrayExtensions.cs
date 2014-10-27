using System;

/// <summary>
/// Extends all Array base clases for a iOS safe iteration function ForEach
/// </summary>
/// <remarks>
/// This file as intentionally no namespace as the extensions methods will be loaded GLOBALLY
/// </remarks>
public static class ArrayExtensions {
  public static void ForEach<T>(this T[] array, Action<T> func) where T : class {
    Neo.Collections.Iterator.ForEach<T>(array, func);
  }

  public static void ForEach<T>(this T[] array, Action<T, int> func) where T : class {
    Neo.Collections.Iterator.ForEach<T>(array, func);
  }

  public static void ForEach(this int[] array, Action<int> func) {
    Neo.Collections.Iterator.ForEach<int>(array, func);
  }

  public static void ForEach(this int[] array, Action<int, int> func) {
    Neo.Collections.Iterator.ForEach<int>(array, func);
  }

  public static void ForEach(this long[] array, Action<long> func) {
    Neo.Collections.Iterator.ForEach<long>(array, func);
  }

  public static void ForEach(this long[] array, Action<long, int> func) {
    Neo.Collections.Iterator.ForEach<long>(array, func);
  }

  public static void ForEach(this float[] array, Action<float> func) {
    Neo.Collections.Iterator.ForEach<float>(array, func);
  }

  public static void ForEach(this float[] array, Action<float, int> func) {
    Neo.Collections.Iterator.ForEach<float>(array, func);
  }

  public static void ForEach(this bool[] array, Action<bool> func) {
    Neo.Collections.Iterator.ForEach<bool>(array, func);
  }

  public static void ForEach(this bool[] array, Action<bool, int> func) {
    Neo.Collections.Iterator.ForEach<bool>(array, func);
  }

  public static void ForEach(this double[] array, Action<double> func) {
    Neo.Collections.Iterator.ForEach<double>(array, func);
  }

  public static void ForEach(this double[] array, Action<double, int> func) {
    Neo.Collections.Iterator.ForEach<double>(array, func);
  }

  public static void ForEach(this char[] array, Action<char> func) {
    Neo.Collections.Iterator.ForEach<char>(array, func);
  }

  public static void ForEach(this char[] array, Action<char, int> func) {
    Neo.Collections.Iterator.ForEach<char>(array, func);
  }
}
