using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests.Neo.Collections{

  [TestFixture]
  public class TestIterator{
    [Test]
    public void ForArray(){
      long[] arr = new long[]{1L, 2L, 3L};
      testIterations<long>(arr, arr);
      testIterationsWithIndex<long>(arr, arr);
    }

    [Test]
    public void ForArrayList(){
      ArrayList list = new ArrayList(){"a", "b", "c"};
      testIterations<object>(list, list.ToArray());
      testIterationsWithIndex<object>(list, list.ToArray());
    }

    [Test]
    public void ForGenericList(){
      List<string> list = new List<string>(){"a", "b", "c"};
      testIterations<string>(list, list.ToArray());
      testIterationsWithIndex<string>(list, list.ToArray());
    }

    [Test]
    public void ForHashtable(){
      Hashtable table = new Hashtable(){
        {"a", "1"},
        {"b", "2"}
      };

      DictionaryEntry[] expected = new DictionaryEntry[]{
        new DictionaryEntry("a", "1"),
        new DictionaryEntry("b", "2")
      };
      testIterations<DictionaryEntry>(table, expected);
      testIterationsWithIndex<DictionaryEntry>(table, expected);
    }

    [Test]
    public void ForGenericDictionary(){
      Dictionary<string,string> dict = new Dictionary<string,string>(){
        {"a", "1"},
        {"b", "2"}
      };
      KeyValuePair<string,string>[] expected = new KeyValuePair<string,string>[]{
        new KeyValuePair<string,string>("a", "1"),
        new KeyValuePair<string,string>("b", "2")
      };
      testIterations<KeyValuePair<string,string>>(dict, expected);
      testIterationsWithIndex<KeyValuePair<string,string>>(dict, expected);
    }

    private void testIterations<T>(object enumerable, T[] expected){
      int  i = 0;
      global::Neo.Collections.Iterator.ForEach<T>(enumerable, (item) => {
        Assert.AreEqual(expected[i], item);
        i++;
      });
      Assert.AreEqual(i, expected.Length);
    }

    private void testIterationsWithIndex<T>(object enumerable, T[] expected){
      int  i = 0;
      global::Neo.Collections.Iterator.ForEach<T>(enumerable, (item, index) => {
        Assert.AreEqual(expected[i], item);
        Assert.AreEqual(i, index);
        i++;
      });
      Assert.AreEqual(i, expected.Length);
    }

  }
}
