using System;

namespace Neo.Collections {
  public class NameValueCollection : System.Collections.Specialized.NameValueCollection{
    public void ForEach(Action<string,string> func) {
      this.AllKeys.ForEach(key => {
        func(key, this[key]);
      });
    }

    public void ForEach(Action<string, string, int> func) {
      int i = 0;
      this.AllKeys.ForEach(key => {
        func(key, this[key], i);
        i++;
      });
    }

    public bool IsEmpty {
      get { return this.Count <= 0;  }
    }
  }
}
