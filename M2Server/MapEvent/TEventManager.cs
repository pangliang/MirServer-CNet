using GameFramework;
using System;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 地图事件管理
    /// </summary>
    public class TEventManager
    {
        /// <summary>
        /// 运行事件列表
        /// </summary>
        public List<TEvent> m_EventList = null;
        /// <summary>
        /// 关闭事件列表
        /// </summary>
        public List<TEvent> m_ClosedEventList = null;

        public TEventManager()
        {
            m_EventList = new List<TEvent>();
            m_ClosedEventList = new List<TEvent>();
        }

        ~TEventManager()
        {
            if (m_EventList != null)
            {
                foreach (var item in m_EventList)
                {
                    m_EventList.Remove(item);
                }
                Dispose(m_EventList);
            }

            if (m_ClosedEventList != null)
            {
                foreach (var item in m_ClosedEventList)
                {
                    m_ClosedEventList.Remove(item);
                }
                Dispose(m_ClosedEventList);
            }
        }

        public void Run()
        {
            TEvent __Event = null;
            byte nCode = 0;
            try
            {
                try
                {
                    nCode = 1;
                    for (int I = m_EventList.Count - 1; I >= 0; I--)
                    {
                        if (m_EventList.Count <= 0)
                        {
                            break;
                        }
                        nCode = 2;
                        __Event = m_EventList[I];
                        nCode = 3;
                        if (__Event != null)
                        {
                            if (__Event.m_boActive && ((HUtil32.GetTickCount() - __Event.m_dwRunStart) > __Event.m_dwRunTick))
                            {
                                __Event.m_dwRunStart = HUtil32.GetTickCount();
                                nCode = 4;
                                __Event.Run();
                                if (__Event.m_boClosed)
                                {
                                    try
                                    {
                                        nCode = 5;
                                        m_ClosedEventList.Add(__Event);
                                    }
                                    finally
                                    {
                                    }
                                    nCode = 6;
                                    m_EventList.RemoveAt(I);
                                }
                            }
                        }
                    }
                }
                finally
                {
                }
                nCode = 7;
                foreach (var item in m_ClosedEventList)
                {
                    if (item != null)
                    {
                        if ((HUtil32.GetTickCount() - item.m_dwCloseTick) > 300000)// 5 * 60 * 1000
                        {
                            m_ClosedEventList.Remove(item);
                            nCode = 8;
                            if (item != null)
                            {
                                Dispose(item);
                            }
                            nCode = 9;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TEventManager.Run Code:" + nCode);
            }
        }

        public int GetRangeEvent(TEnvirnoment Envir, TBaseObject OwnBaseObject, int nX, int nY, int nRange, int nType)
        {
            return m_EventList.FindAll(Event =>
            {
                return (Event.m_OwnBaseObject == OwnBaseObject) && (Math.Abs(Event.m_nX - nX) <= nRange)
                    && (Math.Abs(Event.m_nY - nY) <= nRange) && (Event.m_nEventType == nType);
            }).Count;
        }

        public TEvent GetEvent(TEnvirnoment Envir, int nX, int nY, int nType)
        {
            return m_EventList.Find(Event =>
            {
                return (Event.m_Envir == Envir) && (Event.m_nX == nX) && (Event.m_nY == nY) && (Event.m_nEventType == nType);
            });
        }

        public TEvent FindEvent(TEnvirnoment Envir, TEvent __Event)
        {
            return m_EventList.Find(c =>
            {
                return (c.m_Envir == Envir) && (c == __Event);
            });
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="__Event"></param>
        public void AddEvent(TEvent Event)
        {
            m_EventList.Add(Event);
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    } 
}
