namespace GameFramework
{
    public static class ByteExtension
    {
        /// <summary>
        /// 对Byte数组加密
        /// </summary>
        /// <param name="sData">需要加密的对象</param>
        /// <param name="Size">对象大小</param>
        /// <returns></returns>
        public static string EncodeBuffer(this byte[] sData, int Size = 0)
        {
            if (Size == 0) //如果Szie参数为0,则拿字节大小即可
            {
                return EncryptUnit.EncodeBuffer(sData, sData.Length);
            }
            else
            {
                return EncryptUnit.EncodeBuffer(sData, Size);
            }
        }

        /// <summary>
        /// 当前对象是否玩家或者英雄
        /// </summary>
        /// <param name="btRaceServer"></param>
        /// <returns></returns>
        public static bool IsPlayOrHero(this byte btRaceServer)
        {
            if (btRaceServer == 0 || btRaceServer == 66)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 当前对象是否玩家或英雄或人形怪
        /// </summary>
        /// <param name="btRaceServer"></param>
        /// <returns></returns>
        public static bool IsPlarOrHeroOrPlayMoster(this byte btRaceServer)
        {
            if (btRaceServer == 0 || btRaceServer == 66 || btRaceServer == 150)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 对比当前物品类型是否存在数组元素中
        /// </summary>
        /// <param name="StdMode"></param>
        /// <param name="Arrar"></param>
        /// <returns></returns>
        public static bool Compare(this byte StdMode, int[] Arrar)
        {
            bool result = false;
            for (int i = 0; i < Arrar.Length; i++)
            {
                if (StdMode == Arrar[i])
                {
                    result = true;
                    break;//找到一个就跳出循环
                }
            }
            return result;
        }

        /// <summary>
        /// 数组转String
        /// </summary>
        /// <param name="src"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public static string ToString(this byte[] src, int Len)
        {
            return System.Text.Encoding.Default.GetString(src, 0, Len);
        }
    }
}