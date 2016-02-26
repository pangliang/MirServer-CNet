using System.Collections.Generic;

namespace DBServer.Entity
{
    public class TGStringList : List<string>
    {
        private object CriticalSection = null;

        public TGStringList()
        {
            CriticalSection = new object();
        }

        public void __Lock()
        {
            GameFramework.HUtil32.EnterCriticalSection(CriticalSection);
        }

        public void UnLock()
        {
            GameFramework.HUtil32.LeaveCriticalSection(CriticalSection);
        }

        //public void Up(Object AObject)
        //{
        //    int nIndex;
        //    string s;
        //    if (this.Count <= 1)
        //    {
        //        return;
        //    }
        //    //@ Unsupported property or method(A): 'IndexOfObject'
        //    nIndex = this.IndexOf(AObject.ToString());
        //    //nIndex = this.IndexOfObject(AObject);
        //    if (nIndex >= 0)
        //    {
        //        if ((nIndex - 1 >= 0) && (nIndex - 1 < this.Count))
        //        {
        //            s = this[nIndex];
        //            this.RemoveAt(nIndex);
        //            //this.Remove(nIndex);
        //            nIndex -= 1;
        //            //@ Unsupported property or method(A): 'InsertObject'
        //            //this.InsertObject(nIndex, s, AObject);
        //            this.Add(AObject.ToString());
        //        }
        //    }
        //}

        //public void Down(Object AObject)
        //{
        //    int nIndex;
        //    string s;
        //    if (this.Count <= 1)
        //    {
        //        return;
        //    }
        //    //@ Unsupported property or method(A): 'IndexOfObject'
        //    nIndex = this.IndexOfObject(AObject);
        //    if (nIndex >= 0)
        //    {
        //        if ((nIndex + 1 >= 0) && (nIndex + 1 < this.Count))
        //        {
        //            s = this[nIndex];
        //            this.Remove(nIndex);
        //            nIndex ++;
        //            //@ Unsupported property or method(A): 'InsertObject'
        //            this.InsertObject(nIndex, s, AObject);
        //        }
        //    }
        //}
    }
}