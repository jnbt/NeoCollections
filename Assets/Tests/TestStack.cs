using System;
using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections{
  [TestFixture]
  public sealed class TestStack{

    [Test]
    public void InitializeDefault(){
      Stack<int> subject = new Stack<int>();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void InitializeWithCapacity(){
      Stack<int> subject = new Stack<int>(5);
      Assert.AreEqual(0, subject.Count);
      Assert.AreEqual(5, subject.Capacity);
    }

    [Test]
    public void InitializesWithInitial(){
      int[] initial = new int[]{1,2,3};
      Stack<int> subject = new Stack<int>(initial);
      Assert.AreEqual(3, subject.Count);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsTrue(subject.Contains(3));
    }

    [Test]
    public void IsEmpty(){
      Stack<int> subject = new Stack<int>();
      Assert.IsTrue(subject.IsEmpty);
      subject.Add(1);
      Assert.IsFalse(subject.IsEmpty);
    }

    [Test]
    public void StackOperations(){
      Stack<int> subject = new Stack<int>();
      Assert.AreEqual(0, subject.Peek);

      subject.Add(1);
      Assert.AreEqual(1, subject.Count);
      Assert.AreEqual(1, subject.Peek);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsFalse(subject.Contains(2));
      Assert.IsFalse(subject.Contains(3));
      subject.Add(2);
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(2, subject.Peek);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsFalse(subject.Contains(3));
      subject.Add(3);
      Assert.AreEqual(3, subject.Count);
      Assert.AreEqual(3, subject.Peek);
      Assert.IsTrue(subject.Contains(1));
      Assert.IsTrue(subject.Contains(2));
      Assert.IsTrue(subject.Contains(3));

      Assert.IsTrue(subject.Remove(2));
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(3, subject.Peek);

      Assert.IsFalse(subject.Remove(9));
      Assert.AreEqual(2, subject.Count);
      Assert.AreEqual(3, subject.Peek);

      Assert.AreEqual(3, subject.Pop());
      Assert.AreEqual(1, subject.Count);
      Assert.AreEqual(1, subject.Peek);

      Assert.AreEqual(1, subject.Pop());
      Assert.AreEqual(0, subject.Count);

      Assert.AreEqual(0, subject.Peek);
    }

    [Test]
    public void Clear(){
      Stack<int> subject = new Stack<int>(){1,2,3};
      subject.Clear();
      Assert.AreEqual(0, subject.Count);
    }

    [Test]
    public void ForEachDoNotCallForEmpty(){
      Stack<int> subject = new Stack<int>();
      bool called = false;
      subject.ForEach((item) => called = true);
      Assert.IsFalse(called);
    }

    [Test]
    public void ForEachCallsOncePerItem(){
      Stack<int> subject = new Stack<int>(){1,2,3};

      System.Collections.Generic.List<object> called = new System.Collections.Generic.List<object>(4);
      subject.ForEach((item) => {
        called.Add(item);
      });

      Assert.AreEqual(3, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(1, called[2]);
      Assert.AreEqual(3, called.Count);
    }

    [Test]
    public void CopyTo(){
      Stack<int> subject = new Stack<int>(){1,2,3};
      int[] target = new int[3];
      subject.CopyTo(target);
      Assert.AreEqual(new int[]{3,2,1}, target);
    }

    [Test]
    public void CopyToFromIndex(){
      Stack<int> subject = new Stack<int>(){1,2,3};
      int[] target = new int[]{9,9,9,9};
      subject.CopyTo(target, 1);
      Assert.AreEqual(new int[]{9,3,2,1}, target);
    }
  }
}
