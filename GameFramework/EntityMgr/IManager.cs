using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.EntityMgr {
    /// <summary>
    /// 提供一个泛型的文本加载接口，实现从文本行加载Entity和将List保存到文本
    /// </summary>
    interface IManager<T> : IList<T> {
        List<T> Load();
        void Save();
        T ConvertFromString(string s);
        string ConviertToString(T t);
    }
}
