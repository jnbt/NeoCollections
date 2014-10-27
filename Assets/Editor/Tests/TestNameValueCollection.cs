using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections {
  [TestFixture]
  public sealed class TestNameValueCollection {
    [Test]
    public void InitializesDefaultAndInheritsFromSystem() {
      NameValueCollection nvc = new NameValueCollection();
      Assert.AreEqual(0, nvc.Count);
      Assert.IsTrue(nvc is System.Collections.Specialized.NameValueCollection);
    }

    [Test]
    public void IsEmpty() {
      NameValueCollection nvc = new NameValueCollection();
      Assert.IsTrue(nvc.IsEmpty);
      nvc.Add("a", "b");
      Assert.IsFalse(nvc.IsEmpty);
      nvc.Clear();
      Assert.IsTrue(nvc.IsEmpty);
    }

    [Test]
    public void ForEach() {
      NameValueCollection nvc = new NameValueCollection();
      List<string[]> called = new List<string[]>();
      nvc.ForEach((key, val) => {
        called.Add(new string[] { key, val });
      });
      Assert.IsTrue(called.IsEmpty);

      nvc.Add("a", "b");
      nvc.Add("a", "c");
      nvc.Add("1", "2");
      nvc.Set("1", "x");

      nvc.ForEach((key, val) => {
        called.Add(new string[] { key, val });
      });

      Assert.AreEqual(2, called.Count);
      Assert.AreEqual(new string[] { "a", "b,c" }, called[0]);
      Assert.AreEqual(new string[] { "1", "x" }, called[1]);
    }

    [Test]
    public void ForEachWithIndex() {
      NameValueCollection nvc = new NameValueCollection();
      List<string[]> called = new List<string[]>(3);
      nvc.ForEach((key, val, index) => {
        called.Insert(index, new string[] { key, val });
      });
      Assert.IsTrue(called.IsEmpty);

      nvc.Add("a", "b");
      nvc.Add("a", "c");
      nvc.Add("1", "2");
      nvc.Set("1", "x");

      nvc.ForEach((key, val, index) => {
        called.Insert(index, new string[] { key, val });
      });

      Assert.AreEqual(2, called.Count);
      Assert.AreEqual(new string[] { "a", "b,c" }, called[0]);
      Assert.AreEqual(new string[] { "1", "x" }, called[1]);
    }
  }
}
