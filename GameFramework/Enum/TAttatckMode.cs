namespace GameFramework
{
    /// <summary>
    /// 攻击模式
    /// </summary>
    public enum TAttatckMode : byte
    {
        /// <summary>
        /// 攻击模式: 全体攻击
        /// </summary>
        HAM_ALL = 0,

        /// <summary>
        /// 攻击模式: 和平攻击
        /// </summary>
        HAM_PEACE = 1,

        /// <summary>
        /// 攻击模式: 夫妻攻击
        /// </summary>
        HAM_DEAR = 2,

        /// <summary>
        /// 攻击模式: 师徒攻击
        /// </summary>
        HAM_MASTER = 3,

        /// <summary>
        /// 攻击模式: 编组攻击
        /// </summary>
        HAM_GROUP = 4,

        /// <summary>
        /// 攻击模式: 行会攻击
        /// </summary>
        HAM_GUILD = 5,

        /// <summary>
        /// 攻击模式: 红名攻击
        /// </summary>
        HAM_PKATTACK = 6
    }
}