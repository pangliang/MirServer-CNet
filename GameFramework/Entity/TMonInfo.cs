using System;
using System.Collections.Generic;

namespace GameFramework
{
    public class TMonInfo
    {
        public string sName;// 怪物名
        public byte btRace;// 种族
        public byte btRaceImg;// 种族图像
        public ushort wAppr;// 形像代码
        public ushort wLevel;
        public byte btLifeAttrib;// 不死系
        public bool boUndead;
        public ushort wCoolEye;// 视线范围
        public UInt32 dwExp;
        public int wMP;// 21亿魔法
        public int wHP;// 21亿血
        public ushort wAC;
        public ushort wMAC;
        public ushort wDC;
        public ushort wMaxDC;
        public ushort wMC;
        public ushort wSC;
        public ushort wSpeed;
        public ushort wHitPoint;// 命中率
        public ushort wWalkSpeed;// 行走速度
        public ushort wWalkStep;// 行走步伐
        public ushort wWalkWait;// 行走等待
        public ushort wAttackSpeed;// 攻击速度
        public IList<TMonItem> ItemList;
    }
}