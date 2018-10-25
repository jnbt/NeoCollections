using System;
using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections{
  [TestFixture]
  public sealed class TestSet{

    [Test]
    public void InitializesDefault(){
      Set<int> subject = new Set<int>();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void InitializesWithCapacity(){
      Set<int> subject = new Set<int>(5);
      Assert.AreEqual(0, subject.Count);
      Assert.AreEqual(5, subject.Capacity);
    }

    [Test]
    public void InitializesWithInitial(){
      int[] initial = new int[]{1,2,3};
      Set<int> subject = new Set<int>(initial);
      Assert.AreEqual(3, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsTrue(subject.Contains(3));
    }

    [Test]
    public void CountAddRemoveAndContains(){
      Set<int> subject = new Set<int>();
      Assert.AreEqual(0, subject.Count);
      Assert.IsFalse(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));

      subject.Add(1);
      Assert.AreEqual(1, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));
      Assert.Throws<ArgumentException>( () => {
        subject.Add(1);
      });
      Assert.AreEqual(1, subject.Count);
      subject.Add(2);
      Assert.AreEqual(2, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));

      Assert.IsFalse(subject.Remove(3));
      Assert.AreEqual(2, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));

      Assert.IsTrue(subject.Remove(2));
      Assert.AreEqual(1, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));

      Assert.IsTrue(subject.Remove(1));
      Assert.AreEqual(0, subject.Count);
      Assert.IsFalse(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));
    }

    [Test]
    public void IsEmpty(){
      Set<int> subject = new Set<int>();
      Assert.IsTrue(subject.IsEmpty);
      subject.Add(1);
      Assert.IsFalse(subject.IsEmpty);
      subject.Remove(1);
      Assert.IsTrue(subject.IsEmpty);
    }

    [Test]
    public void AddOnlyOnce(){
      Set<int> subject = new Set<int>();
      subject.Add(1);

      Assert.Throws<ArgumentException>( () => {
        subject.Add(1);
      });

      subject.Add(2);
    }

    [Test]
    public void TryAdd(){
      Set<int> subject = new Set<int>();
      Assert.IsTrue(subject.TryAdd(1));
      Assert.IsTrue(subject.Contains(1));

      Assert.IsFalse(subject.TryAdd(1));

      Assert.IsTrue(subject.TryAdd(2));
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
    }

    [Test]
    public void AddAllAndRemoveAll(){
      Set<int> subject = new Set<int>();
      subject.AddAll(new int[]{1,2,3});
      Assert.AreEqual(3, subject.Count);

      subject.AddAll(new int[]{4});
      Assert.AreEqual(4, subject.Count);

      subject.RemoveAll(new int[]{4});
      Assert.AreEqual(3, subject.Count);

      subject.RemoveAll(new int[]{1,2,3,4,5});
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void ForEachDoNotCallForEmpty(){
      Set<int> subject = new Set<int>();
      bool called = false;
      subject.ForEach((item) => called = true);
      Assert.IsFalse(called);
    }

    [Test]
    public void ForEachCallsOncePerItem(){
      Set<int> subject = new Set<int>(){1,2,3};

      System.Collections.Generic.List<object> called = new System.Collections.Generic.List<object>(4);
      subject.ForEach((item) => {
        called.Add(item);
      });

      Assert.AreEqual(1, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(3, called[2]);
      Assert.AreEqual(3, called.Count);
    }

    [Test]
    public void Clear(){
      Set<int> subject = new Set<int>(){1,2,3};
      Assert.AreEqual(3, subject.Count);
      subject.Clear();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void CopyTo(){
      Set<int> subject = new Set<int>(){1,2,3};
      int[] target = new int[3];
      subject.CopyTo(target);
      Assert.AreEqual(new int[]{1,2,3}, target);
    }

    [Test]
    public void CopyToFromIndex(){
      Set<int> subject = new Set<int>(){1,2,3};
      int[] target = new int[]{9,9,9,9};
      subject.CopyTo(target, 1);
      Assert.AreEqual(new int[]{9,1,2,3}, target);
    }

    [Test]
    public void Find(){
      Set<int> subject = new Set<int>(){1,2,3};
      int found = subject.Find((item) => {
        return item % 2 == 0;
      });
      Assert.AreEqual(2, found);

      int found2 = subject.Find((item) => {
        return item > 10;
      });
      Assert.AreEqual(0, found2);
    }

    [Test]
    public void FindAll(){
      Set<int> subject = new Set<int>(){1,2,3};
      Set<int> filtered = subject.FindAll((item) => {
        return item % 2 == 1;
      });
      Assert.AreEqual(2, filtered.Count);
      Assert.IsTrue(filtered.Contains(1));
      Assert.IsTrue(filtered.Contains(3));
    }

    [Test]
    public void OperatorPlus(){
      Set<int> one = new Set<int>(){1,2,3};
      Set<int> two = new Set<int>(){3,4,5};
      one += two;
      Assert.AreEqual(5, one.Count);
      Assert.IsTrue(one.Contains(1));
      Assert.IsTrue(one.Contains(2));
      Assert.IsTrue(one.Contains(3));
      Assert.IsTrue(one.Contains(4));
      Assert.IsTrue(one.Contains(5));
    }

    [Test]
    public void OperatorMinus(){
      Set<int> one = new Set<int>(){1,2,3};
      Set<int> two = new Set<int>(){3,4,5};
      Set<int> r   = one - two;
      Assert.AreEqual(2, r.Count);
      Assert.IsTrue(r.Contains(1));
      Assert.IsTrue(r.Contains(2));
    }

    [Test]
    public void Intersect(){
      Set<int> one = new Set<int>(){1,2,3};
      Set<int> two = new Set<int>(){3,4,5};
      Set<int> r   = one.IntersectWith(two);
      Assert.AreEqual(1, r.Count);
      Assert.IsTrue(r.Contains(3));
    }
  }
}
