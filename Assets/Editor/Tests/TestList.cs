using NUnit.Framework;
using Neo.Collections;

namespace Tests.Neo.Collections{
  [TestFixture]
  public sealed class TestList{

    [Test]
    public void InitializesDefaultAndInheritsFromSystemList(){
      List<int> list = new List<int>();
      Assert.AreEqual(0, list.Count);
      Assert.IsTrue(list is System.Collections.Generic.List<int>);
    }

    [Test]
    public void InitializesWithCapacity(){
      List<int> list = new List<int>(23);
      Assert.AreEqual(23, list.Capacity);
    }

    [Test]
    public void InitializesFromOtherEnumerable(){
      System.Collections.Generic.IEnumerable<int> other = new int[]{1,2,3};
      List<int> list = new List<int>(other);
      Assert.AreEqual(3, list.Count);
      Assert.AreEqual(1, list[0]);
      Assert.AreEqual(2, list[1]);
      Assert.AreEqual(3, list[2]);
    }

    [Test]
    public void IsEmpty(){
      List<int> subject = new List<int>();
      Assert.IsTrue(subject.IsEmpty);
      subject.Add(1);
      Assert.IsFalse(subject.IsEmpty);
    }

    [Test]
    public void ForEachDoNotCallForEmpty(){
      List<int> list = new List<int>();
      bool called = false;
      list.ForEach((item) => called = true);
      Assert.IsFalse(called);
    }

    [Test]
    public void ForEachCallsOncePerItem(){
      List<int> list = new List<int>(){1,2,3};

      System.Collections.Generic.List<object> called = new System.Collections.Generic.List<object>(4);
      list.ForEach((item) => {
        called.Add(item);
      });

      Assert.AreEqual(1, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(3, called[2]);
      Assert.AreEqual(3, called.Count);
    }

    [Test]
    public void ForEachCallsOncePerItemWithIndex(){
      List<int> list = new List<int>(){1,2,3};

      System.Collections.Generic.List<object> called = new System.Collections.Generic.List<object>(4);
      System.Collections.Generic.List<int> index = new System.Collections.Generic.List<int>(4);
      list.ForEach((item, i) => {
        called.Add(item); index.Add(i);
      });

      Assert.AreEqual(1, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(3, called[2]);
      Assert.AreEqual(3, called.Count);

      Assert.AreEqual(0, index[0]);
      Assert.AreEqual(1, index[1]);
      Assert.AreEqual(2, index[2]);
      Assert.AreEqual(3, index.Count);
    }

    [Test]
    public void FindAll(){
      List<int> list = new List<int>(){1,2,3,4};
      List<int> filtered = list.FindAll((item) => {
        return item % 2 == 0;
      });

      Assert.AreEqual(2, filtered[0]);
      Assert.AreEqual(4, filtered[1]);
      Assert.AreEqual(2, filtered.Count);
    }

    [Test]
    public void FindAllWithIndex(){
      List<int> list = new List<int>(){1,2,3,4};
      List<int> filtered = list.FindAll((item, index) => {
        return item % 2 == 0 && index < 3;
      });

      Assert.AreEqual(2, filtered[0]);
      Assert.AreEqual(1, filtered.Count);
    }

    [Test]
    public void Find(){
      List<int> list = new List<int>(){1,2,3,4};
      Assert.AreEqual(0, list.Find( (item) => {
        return item > 5;
      }));

      Assert.AreEqual(2, list.Find( (item) => {
        return item % 2 == 0 && item < 4;
      }));

      Assert.AreEqual(2, list.Find( (item) => {
        return item % 2 == 0 && item < 4;
      }));
    }

    [Test]
    public void ConvertAll(){
      List<int> list = new List<int>(){1,2,3,4};
      List<bool> converted = list.ConvertAll<bool>((item) => {
        return item % 2 == 0;
      });

      Assert.AreEqual(4, converted.Count);
      Assert.AreEqual(false, converted[0]);
      Assert.AreEqual(true,  converted[1]);
      Assert.AreEqual(false, converted[2]);
      Assert.AreEqual(true,  converted[3]);
    }

    [Test]
    public void WorksWithIterator(){
      List<int> list = new List<int>(){1,2,3};
      System.Collections.Generic.List<int> called = new System.Collections.Generic.List<int>(3);
      global::Neo.Collections.Iterator.ForEach<int>(list, called.Add);
      Assert.AreEqual(1, called[0]);
      Assert.AreEqual(2, called[1]);
      Assert.AreEqual(3, called[2]);
      Assert.AreEqual(3, called.Count);
    }

    [Test]
    public void First(){
      List<int> empty = new List<int>(0);
      Assert.AreEqual(0, empty.Last);
      List<int> list = new List<int>(){1,2,3};
      Assert.AreEqual(1, list.First);
    }

    [Test]
    public void Last(){
      List<int> empty = new List<int>(0);
      Assert.AreEqual(0, empty.Last);
      List<int> list = new List<int>(){1,2,3};
      Assert.AreEqual(3, list.Last);
    }

    [Test]
    public void Splice(){
      List<int> empty = new List<int>(0);
      List<int> sEmpty = empty.Splice(0,0);
      Assert.AreEqual(0, sEmpty.Count);

      List<int> some = new List<int>(){1,2,3,4,5};
      List<int> one  = some.Splice(0,5);
      Assert.AreEqual(some, one);

      List<int> second = some.Splice(1,2);
      Assert.AreEqual(new List<int>(){2,3}, second);

      List<int> third = some.Splice(3,5);
      Assert.AreEqual(new List<int>(){4,5}, third);
    }

    [Test]
    public void OperatorPlus(){
      List<int> one   = new List<int>(){1,2,3};
      List<int> two   = new List<int>(){4,5};
      List<int> three = new List<int>(0);

      List<int> sum = one + two + three;
      List<int> expected = new List<int>(){1,2,3,4,5};
      Assert.AreEqual(expected, sum);
    }

    [Test]
    public void OperatorMinus(){
      List<int> one   = new List<int>(){1,2,2,3};
      List<int> two   = new List<int>(){2,4,5};
      List<int> three = new List<int>(0);

      Assert.AreEqual(one, one - three);
      Assert.AreEqual(two, two - three);
      Assert.AreEqual(new List<int>(){1,2,3}, one - two);
      Assert.AreEqual(three, one - one);
      Assert.AreEqual(three, two - two);
    }

  }
}