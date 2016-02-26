using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    public unsafe class MemoryHelper
    {
        // 处理堆栈的句柄，此句柄用于下面方法的HeapXXX APIs的调用
        private static int ph = GetProcessHeap();

        // 私有的构造器，防止实例化
        private MemoryHelper()
        {
        }

        // 分配一个给定大小的内存块。分配的内存自动地初始化为0
        public static void* Alloc(int size)
        {
            void* result = HeapAlloc(ph, HEAP_ZERO_MEMORY, size);
            if (result == null) throw new OutOfMemoryException();
            return result;
        }

        //从src拷贝到count字节到dst，源块与目标块允许重叠
        public static void Copy(void* src, void* dst, int count)
        {
            byte* ps = (byte*)src;
            byte* pd = (byte*)dst;
            if (ps > pd)
            {
                for (; count != 0; count--) *pd++ = *ps++;
            }
            else if (ps < pd)
            {
                for (ps += count, pd += count; count != 0; count--) *--pd = *--ps;
            }
        }

        //释放内存块
        public static void Free(void* block)
        {
            if (!HeapFree(ph, 0, block)) throw new InvalidOperationException();
        }

        // 重分配内存块。如果重分配请求需要更大块，则另外的内存区域自动地初始化为0
        public static void* ReAlloc(void* block, int size)
        {
            void* result = HeapReAlloc(ph, HEAP_ZERO_MEMORY, block, size);
            if (result == null) throw new OutOfMemoryException();
            return result;
        }

        // 返回内存块的大小
        public static int SizeOf(void* block)
        {
            int result = HeapSize(ph, 0, block);
            if (result == -1) throw new InvalidOperationException();
            return result;
        }

        // 堆栈API标记 Heap API flags
        private const int HEAP_ZERO_MEMORY = 0x00000008;

        // 堆栈API函数 Heap API functions
        [DllImport("kernel32")]
        private static extern int GetProcessHeap();

        [DllImport("kernel32")]
        private static extern void* HeapAlloc(int hHeap, int flags, int size);

        [DllImport("kernel32")]
        private static extern bool HeapFree(int hHeap, int flags, void* block);

        [DllImport("kernel32")]
        private static extern void* HeapReAlloc(int hHeap, int flags,
         void* block, int size);

        [DllImport("kernel32")]
        private static extern int HeapSize(int hHeap, int flags, void* block);
    }
}