using System.Text.RegularExpressions;

namespace GameFramework
{
    public static class RegexpEngine
    {
        /// <summary>
        /// 验证字符串是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(string str)
        {
            Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");

            if (regex.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查字符串是否存在数字
        /// </summary>
        /// <returns></returns>
        public static bool HaveNumber(string str)
        {
            Regex reg = new Regex(".*\\d+.*");
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}