using System;
using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections{
  [TestFixture]
  public sealed class TestQueue{

    [Test]
    public void InitializeDefault(){
      Queue<int> subject = new Queue<int>();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void InitializeWithCapacity(){
      Queue<int> subject = new Queue<int>(5);
      Assert.AreEqual(0, subject.Count);
      Assert.AreEqual(5, subject.Capacity);
    }

    [Test]
    public void InitializesWithInitial(){
      int[] initial = new int[]{1,2,3};
      Queue<int> subject = new Queue<int>(initial);
      Assert.AreEqual(3, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsTrue(subject.Contains(3));
    }

    [Test]
    public void IsEmpty(){
      Queue<int> subject = new Queue<int>();
      Assert.IsTrue(subject.IsEmpty);
      subject.Add(1);
      Assert.IsFalse(subject.IsEmpty);
    }

    [Test]
    public void QueueOperations(){
      Queue<int> subject = new Queue<int>();
      Assert.AreEqual(0, subject.First);
      Assert.AreEqual(0, subject.Last);
      subject.Add(1);
      Assert.AreEqual(1, subject.Count);
      Assert.AreEqual(1, subject.First);
      Assert.AreEqual(1, subject.Last);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));
      Assert.IsFalse(subject.Contains(3));

      subject.Add(2);
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(1, subject.First);
      Assert.AreEqual(2, subject.Last);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsFalse(subject.Contains(3));

      subject.Add(3);
      Assert.AreEqual(3, subject.Count);
      Assert.AreEqual(1, subject.First);
      Assert.AreEqual(3, subject.Last);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsTrue(subject.Contains(3));

      Assert.IsTrue(subject.Remove(2));
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(1, subject.First);
      Assert.AreEqual(3, subject.Last);

      Assert.IsFalse(subject.Remove(9));
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(1, subject.First);
      Assert.AreEqual(3, subject.Last);

      Assert.AreEqual(1, subject.Dequeue());
      Assert.AreEqual(1, subject.Count);
      Assert.AreEqual(3, subject.First);
      Assert.AreEqual(3, subject.Last);

      Assert.AreEqual(3, subject.Dequeue());
      Assert.AreEqual(0, subject.Count);

      Assert.AreEqual(0, subject.Dequeue());
    }

    [Test]
    public void Clear(){
      Queue<int> subject = new Queue<int>(){1,2,3};
      subject.Clear();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void ForEachDoNotCallForEmpty(){
      Queue<int> subject = new Queue<int>();
      bool called = false;
      subject.ForEach((item) => called = true);
      Assert.IsFalse(called);
    }

    [Test]
    public void ForEachCallsOncePerItem(){
      Queue<int> subject = new Queue<int>(){1,2,3};

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
    public void CopyTo(){
      Queue<int> subject = new Queue<int>(){1,2,3};
      int[] target = new int[3];
      subject.CopyTo(target);
      Assert.AreEqual(new int[]{1,2,3}, target);
    }

    [Test]
    public void CopyToFromIndex(){
      Queue<int> subject = new Queue<int>(){1,2,3};
      int[] target = new int[]{9,9,9,9};
      subject.CopyTo(target, 1);
      Assert.AreEqual(new int[]{9,1,2,3}, target);
    }

    [Test]
    public void WorksWithIterator(){
      Queue<int> subject = new Queue<int>(){1,2,3};
      System.Collections.Generic.List<int> called = new System.Collections.Generic.List<int>(4);
      global::Neo.Collections.Iterator.ForEach<int>(subject, called.Add);
      Assert.AreEqual(1, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(3, called[2]);
      Assert.AreEqual(3, called.Count);
    }
  }
}
