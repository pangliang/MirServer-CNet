using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.LuaBase
{
    /// <summary>  
    /// Lua函数描述特性类  
    /// </summary>  
    public class LuaFunction : Attribute
    {
        private String FunctionName;

        public LuaFunction(String strFuncName)
        {
            FunctionName = strFuncName;
        }

        public String getFuncName()
        {
            return FunctionName;
        }
    }
}
