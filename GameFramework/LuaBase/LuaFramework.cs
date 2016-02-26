using LuaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GameFramework.LuaBase
{
    /// <summary>  
    /// Lua引擎  
    /// </summary>  
    public class LuaFramework
    {
        private Lua pLuaVM = new Lua();//lua虚拟机  

        /// <summary>  
        /// 注册lua函数  
        /// </summary>  
        /// <param name="pLuaAPIClass">lua函数类</param>  
        public void BindLuaApiClass(Object pLuaAPIClass)
        {
            foreach (MethodInfo mInfo in pLuaAPIClass.GetType().GetMethods())
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                {
                    if (attr is LuaFunction)
                    {
                        string LuaFunctionName = (attr as LuaFunction).getFuncName();
                        pLuaVM.RegisterFunction(LuaFunctionName, pLuaAPIClass, mInfo);
                    }
                }
            }
        }

        /// <summary>  
        /// 执行lua脚本文件  
        /// </summary>  
        /// <param name="luaFileName">脚本文件名</param>  
        public void ExecuteFile(string luaFileName)
        {
            try
            {
                pLuaVM.DoFile(luaFileName);
            }
            catch (Exception e)
            {
                throw new Exception("执行Lua脚本失败." + e.Message);
            }
        }

        /// <summary>
        /// 调用Lua脚本
        /// </summary>
        /// <param name="luaCommand"></param>
        /// <returns></returns>
        public object[] Invoke(string luaCommand)
        {
            try
            {
                var lua = pLuaVM.GetFunction(luaCommand);
                return lua.Call();
            }
            catch (Exception e)
            {
                throw new Exception("执行Lua脚本失败." + e.Message);
            } 
        }

        /// <summary>  
        /// 执行lua脚本  
        /// </summary>  
        /// <param name="luaCommand">lua指令</param>  
        public object[] ExecuteString(string luaCommand)
        {
            try
            {
               return pLuaVM.DoString(luaCommand);
            }
            catch (Exception e)
            {
                throw new Exception("执行Lua脚本失败." + e.Message);
            }
        }
    }
}