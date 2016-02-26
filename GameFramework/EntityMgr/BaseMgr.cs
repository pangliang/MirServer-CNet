using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GameFramework;

namespace GameFramework.EntityMgr
{
    /// <summary>
    /// 泛型管理的基本实现
    /// </summary>
    public abstract class BaseMgr<T> : IManager<T>
    {
        protected TStringList textString = null;
        protected List<T> list;
        public BaseMgr(string s)
        {
            this.FilePath = s;

            textString = new TStringList();
            list = new List<T>();
        }

        protected virtual string FilePath { get; set; }

        #region 抽象方法，子类必须实现

        /// <summary>
        /// 定义了如何从一个格式化的字符串（文本行）转化为一个实例T，如实例化失败，则返回null
        /// </summary>
        /// <param name="s">格式化的字符串</param>
        public abstract T ConvertFromString(string s);

        /// <summary>
        /// 将T格式化为一个字符串（转化为本文中的一行）
        /// </summary>
        public abstract string ConviertToString(T t);

        #endregion

        /// <summary>
        /// 加载数据（如果子类的内容不是单行文本构成，则自行重写实现解析），不返回null
        /// </summary>
        public virtual List<T> Load()
        {
            textString.LoadFromFile(this.FilePath, Encoding.ASCII);

            if (textString.Count > 0)
            {
                for (int i = 0; i < textString.Count; i++)
                {
                    if (null == textString || textString[0] == ";")
                    {
                        continue; //跳过空行，注释行
                    }

                    T t = ConvertFromString(textString[i]);
                    if (t != null) list.Add(t);
                }
            }

            return list;
        }

        /// <summary>
        /// 将泛型列表保存到文本
        /// </summary>
        public void Save()
        {
            this.textString.SaveToFile(this.FilePath, Encoding.ASCII);
        }

        #region IList
        public void Add(T item)
        {
            this.list.Add(item);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(T item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }
        #endregion

        /// <summary>
        /// 是否存在，存在则返回true
        /// </summary>
        /// <param name="match">查找委托</param>
        public bool Exists(Predicate<T> match)
        {
            return this.list.Exists(match);
        }

        /// <summary>
        /// 返回所有符合条件的子集，如果参数match=null则返回整个集合
        /// </summary>
        public List<T> FindAll(Predicate<T> match)
        {
            if (match == null) return this.list;
            return this.list.FindAll(match);
        }
    }
}