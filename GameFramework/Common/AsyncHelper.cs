/*
 * 名称：AsyncHelper
 * 创建人：John
 * 创建时间：2012-3-7 9:37:27
 * 描述:UI异步操作
 *********************************************
*/
using System;
using System.Windows.Forms;

namespace GameFramework
{
    /// <summary>
    /// 异步操作状态类
    /// </summary>
    public class AsyncState
    {
        /// <summary>
        /// 异步操作异常对象
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// 状态对象
        /// </summary>
        public object Data { get; set; }

    }

    /// <summary>
    /// 异步操作的工具类
    /// </summary>
    public class AsyncHelper
    {
        private AsyncState state;

        /// <summary>
        /// 异步操作状态对象
        /// </summary>
        public AsyncState State
        {
            get { return this.state; }
        }

        /// <summary>
        /// 控件对象
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// 异步操作
        /// </summary>
        public Action<AsyncState> AsyncOperation { get; set; }

        /// <summary>
        /// 异步操作的回调方法
        /// </summary>
        public Action<AsyncState> AsyncOperationCallback { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public AsyncHelper()
        {
            this.state = new AsyncState();
        }

        /// <summary>
        /// 开始执行异步操作
        /// </summary>
        public void BeginInvoke()
        {
            this.state.Error = null;

            if (this.Control != null && this.AsyncOperation != null)
            {
                this.AsyncOperation.BeginInvoke(this.state, new AsyncCallback(this.InvokeCallback), null);
            }
        }

        /// <summary>
        /// 执行异步操作的回调方法
        /// </summary>
        private void InvokeCallback(IAsyncResult ar)
        {
            try
            {
                this.AsyncOperation.EndInvoke(ar);
            }
            catch (Exception ex)
            {
                this.state.Error = ex;
            }

            if (this.AsyncOperationCallback != null)
            {
                if (this.Control.InvokeRequired)
                {
                    this.Control.Invoke(this.AsyncOperationCallback, this.state);
                }
                else
                {
                    this.AsyncOperationCallback(this.state);
                }
            }

        }
    }
}
