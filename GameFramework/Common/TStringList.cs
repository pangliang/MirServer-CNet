using System;
using System.IO;
using System.Text;

namespace GameFramework {
    /// <summary>
    /// 实现了一个字符串管理类
    /// </summary>
    public sealed class TStringList : IDisposable {
        private int m_Capacity;
        private string[] m_Strings;
        private int m_Size;

        /// <summary>
        /// 数据个数属性
        /// </summary>
        public int Count {
            get {
                return m_Size;
            }
        }

        /// <summary>
        /// 缓存大小属性
        /// </summary>
        public int Capacity {
            get {
                return m_Capacity;
            }
            set {
                if (m_Strings == null) {
                    return;
                }

                if (value != m_Strings.Length) {
                    if (value < this.m_Size) {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (value > 0) {
                        string[] objArray1 = new string[value];
                        if (this.m_Size > 0) {
                            Array.Copy(this.m_Strings, 0, objArray1, 0, this.m_Size);
                        }
                        this.m_Strings = objArray1;
                    } else {
                        this.m_Strings = new string[0x10];
                    }
                }
            }
        }

        public string Text
        {
            get
            {
                return this.ToString();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TStringList()
            : this(10) {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TStringList(int capacity) {
            m_Capacity = capacity;

            m_Strings = new string[capacity];
            m_Size = 0;
        }

        /// <summary>
        /// 读取某行内容
        /// </summary>
        /// <param name="index"></param>
        public string this[int index] {
            get {
                if ((index < 0) || (index >= m_Size)) {
                    throw new ArgumentOutOfRangeException();
                }
                return this.m_Strings[index];
            }
            set {
                if ((index < 0) || (index >= m_Size)) {
                    throw new ArgumentOutOfRangeException();
                }
                this.m_Strings[index] = value;
            }
        }

        /// <summary>
        /// 调整缓存大小
        /// </summary>
        protected void EnsureCapacity(int min) {
            if (this.m_Strings.Length < min) {
                int num1 = (this.m_Strings.Length == 0) ? 0x10 : (this.m_Strings.Length * 2);
                if (num1 < min) {
                    num1 = min;
                }
                this.Capacity = num1;
            }
        }

        public int Add(string value) {
            if (this.Count == m_Strings.Length) {
                EnsureCapacity(this.Count + 1);
            }

            m_Strings[this.Count] = value;
            m_Size++;

            return m_Size;
        }

        /// <summary>
        /// 追加一行
        /// </summary>
        public int AppendText(string value) {
            if (this.Count == m_Strings.Length) {
                EnsureCapacity(this.Count + 1);
            }

            m_Strings[this.Count] = value;
            m_Size++;

            return m_Size;
        }

        /// <summary>
        /// 插入一行
        /// </summary>
        /// <param name="index"></param>
        public int InsertText(int index, string value) {
            if (index < 0) {
                index = 0;
            }

            if (this.Count == m_Strings.Length) {
                EnsureCapacity(this.Count + 1);
            }

            if (index < this.Count) {
                Array.Copy(this.m_Strings, index, this.m_Strings, index + 1, this.m_Size - index);
            }

            m_Strings[index] = value;
            m_Size++;

            return m_Size;
        }

        /// <summary>
        /// 查找数据的位置
        /// </summary>
        public int IndexOf(string value) {
            return Array.IndexOf(this.m_Strings, value, 0, this.m_Size);
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {
            if ((index < 0) || (index >= this.m_Size)) {
                throw new ArgumentOutOfRangeException();
            }
            this.m_Size--;
            if (index < this.m_Size) {
                Array.Copy(this.m_Strings, index + 1, this.m_Strings, index, this.m_Size - index);
            }
            this.m_Strings[this.m_Size] = null;
        }

        /// <summary>
        /// 转换为字符串。
        /// </summary>
        public override string ToString() {
            StringBuilder s = new StringBuilder(this.Count);

            for (int i = 0; i < this.Count; i++) {
                s.Append(m_Strings[i] + "\r\n");
            }

            return s.ToString();
        }

        /// <summary>
        /// 转换为字符串。
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string ToString(int startIndex, int count) {
            if (startIndex < 0) {
                startIndex = 0;
            } else if (startIndex >= this.Count) {
                return "";
            }

            if (count <= 0) {
                return "";
            }

            if (count + startIndex > this.Count) {
                count = this.Count - startIndex;
            }

            StringBuilder s = new StringBuilder(this.Count);

            for (int i = startIndex; i < count; i++) {
                s.Append(m_Strings[i] + "\r\n");
            }

            return s.ToString();
        }

        /// <summary>
        /// 清除内容
        /// </summary>
        public void Clear() {
            this.m_Size = 0;
        }

        /// <summary>
        /// 保存为一个文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="encoding"></param>
        public void SaveToFile(string fileName, Encoding encoding) {
            StreamWriter sw2 = new StreamWriter(fileName, false, encoding);
            for (int i = 0; i < this.Count; i++) {
                sw2.Write(m_Strings[i] + "\r\n");
            }

            sw2.Close();
        }

        public void SaveToFile(string fileName) {
            StreamWriter sw2 = new StreamWriter(fileName, false, ASCIIEncoding.Default);
            for (int i = 0; i < this.Count; i++) {
                sw2.Write(m_Strings[i] + "\r\n");
            }

            sw2.Close();
        }

        /// <summary>
        /// 读入一个文本文件
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadFromFile(string fileName)
        {
            this.Clear();
            using (StreamReader sr2 = new StreamReader(fileName, ASCIIEncoding.Default))
            {
                while (sr2.Peek() >= 0)
                {
                    this.AppendText(sr2.ReadLine());
                }
                sr2.Close();
            }
        }

        /// <summary>
        /// 从文本文件中加载内容
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="isAdd">是否追加</param>
        public void LoadFromFile(string fileName, bool isAdd) {
            if (!isAdd) {
                this.Clear();
            }
            using (StreamReader sr2 = new StreamReader(fileName, ASCIIEncoding.Default)) {
                while (sr2.Peek() >= 0) {
                    this.AppendText(sr2.ReadLine());
                }
                sr2.Close();
            }
        }

        /// <summary>
        /// 从文本文件中加载内容
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="encoding">字符编码，一般为AscII</param>
        public void LoadFromFile(string fileName, Encoding encoding) {
            this.Clear();
            using (StreamReader sr2 = new StreamReader(fileName, encoding)) {
                while (sr2.Peek() >= 0) {
                    this.AppendText(sr2.ReadLine());
                }
                sr2.Close();
            }
        }

        public void __Lock() {
        }

        public void UnLock() {
        }

        public void Dispose() {
        }
    }
}