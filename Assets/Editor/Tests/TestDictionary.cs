using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections{
  [TestFixture]
  public sealed class TestDictionary{

    [Test]
    public void InitializesDefaultAndInheritsFromSystemList(){
      Dictionary<string,int> dict = new Dictionary<string,int>();
      Assert.AreEqual(0, dict.Count);
      Assert.IsTrue(dict is System.Collections.Generic.Dictionary<string,int>);
    }

    [Test]
    public void InitializesWithCapacity(){
      Dictionary<string,int> dict = new Dictionary<string,int>(23);
      Assert.AreEqual(0, dict.Count);
    }

    [Test]
    public void InitializesFromOther(){
      System.Collections.Generic.IDictionary<string,int> other = new System.Collections.Generic.Dictionary<string,int>{
        {"a", 1},
        {"b", 2}
      };
      Dictionary<string,int> dict = new Dictionary<string,int>(other);
      Assert.AreEqual(2, dict.Count);
      Assert.AreEqual(1, dict["a"]);
      Assert.AreEqual(2, dict["b"]);
    }

    [Test]
    public void ForEachDoNotCallForEmpty(){
      Dictionary<string,int> dict = new Dictionary<string,int>();
      bool called = false;
      dict.ForEach((k,v) => called = true);
      Assert.IsFalse(called);
    }

    [Test]
    public void ForEachCallsOncePerPair(){
      Dictionary<string,int> dict = new Dictionary<string,int>{
        {"a", 1},
        {"b", 2}
      };
      System.Collections.Generic.List<object> called = new System.Collections.Generic.List<object>(4);
      dict.ForEach((k,v) => {
        called.Add(k);
        called.Add(v);
      });

      Assert.AreEqual("a", called[0]);
      Assert.AreEqual(1, called[1]);
      Assert.AreEqual("b", called[2]);
      Assert.AreEqual(2, called[3]);
      Assert.AreEqual(4, called.Count);
    }

    [Test]
    public void FindAll(){
      Dictionary<string,int> dict = new Dictionary<string,int>{
        {"a", 1},
        {"b", 2},
        {"aa", 3}
      };

      Dictionary<string,int> filtered = dict.FindAll( (k,v) => {
        return k.StartsWith("a");
      });

      Assert.AreEqual(2, filtered.Count);
      Assert.AreEqual(1, filtered["a"]);
      Assert.AreEqual(3, filtered["aa"]);
    }

    [Test]
    public void GetReturnsDefaultInsteadOfException(){
      Dictionary<string,int> dict = new Dictionary<string,int>{
        {"a", 1}
      };

      Assert.AreEqual(1, dict.Get("a"));
      Assert.AreEqual(0, dict.Get("c"));
      Assert.AreEqual(0, dict.Get(null));
    }

    [Test]
    public void Has(){
      Dictionary<string,int> dict = new Dictionary<string,int>{
        {"a", 1}
      };

      Assert.IsTrue(dict.Has("a"));
      Assert.IsFalse(dict.Has("b"));
      Assert.IsFalse(dict.Has("c"));
      Assert.IsFalse(dict.Has(null));
    }

  }
}