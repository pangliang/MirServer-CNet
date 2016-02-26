using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.EntityMgr
{
    /// <summary>
    /// 实现了对MonGen.txt文本的加载和内容管理
    /// </summary>
    public class MonGenMgr : BaseMgr<Entity.MonGenInfo>
    {
        public MonGenMgr(string file) : base(file) { }


        public override Entity.MonGenInfo ConvertFromString(string s)
        {
            string[] arr = s.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 7)
            { //刷怪配置最少需要7项，少于7项则视为错误刷怪项
                return null;
            }

            Entity.MonGenInfo mongen = null;
            try
            {
                mongen = new Entity.MonGenInfo();

                mongen.sMapName = arr[0];
                mongen.nX = int.Parse(arr[1]);
                mongen.nY = int.Parse(arr[2]);
                mongen.sMonName = arr[3];
                mongen.nRange = int.Parse(arr[4]);
                mongen.nCount = int.Parse(arr[5]);
                mongen.dwZenTime = int.Parse(arr[6]);
                if (s.Length > 7)
                {
                    if (s.Length == 8)
                    {
                        mongen.boIsNGMon = arr[7] != "0";
                    }

                    if (s.Length == 9)
                    {
                        byte colorName = 0;
                        if (byte.TryParse(arr[8], out colorName))
                        {
                            mongen.nNameColor = colorName;
                        }
                    }

                    if (s.Length == 10)
                    {
                        int rate = 0;
                        if (int.TryParse(arr[9], out rate))
                        {
                            mongen.nMissionGenRate = rate;
                        }
                    }

                    if (s.Length == 11)
                    {
                        mongen.nChangeColorType = arr[10] != "0";
                    }
                }
            }
            catch
            {
                //如果发生异常则忽略
                return null;
            }

            return mongen;
        }

        public override string ConviertToString(Entity.MonGenInfo t)
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}",
                t.sMapName, t.nX, t.nY, t.sMonName, t.nRange, t.nCount, t.dwZenTime,
                t.boIsNGMon ? "0" : "1", t.nNameColor, t.nMissionGenRate, t.nChangeColorType);
        }
    }
}