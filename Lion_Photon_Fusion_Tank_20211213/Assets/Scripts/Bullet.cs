using UnityEngine;
using Fusion;

/// <summary>
/// 子彈移動速度、存活時間
/// </summary>
public class Bullet : NetworkBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 100)]
    public float speed = 5;
    [Header("存活時間"), Range(0, 10)]
    public float lifeTime = 5;
    #endregion

    #region 屬性
    // Networked 連線用屬性資料
    /// <summary>
    /// 存活計時器
    /// </summary>
    [Networked]
    private TickTimer life { get; set; }
    #endregion

    #region 方法
    /// <summary>
    /// 初始資料
    /// </summary>
    public void Init()
    {
        // 存活計時器 = 計時器.從秒數建立(連線執行器，存活時間)
        life = TickTimer.CreateFromSeconds(Runner, lifeTime);
    }

    /// <summary>
    /// Network Behaviour 父類別提供的事件
    /// 連線用固定更新 50 FPS
    /// </summary>
    public override void FixedUpdateNetwork()
    {
        // Runner 連線執行器
        // Expired() 是否到期
        // Despawn() 刪除
        // Object 連線物件
        // Runner.DeltaTime 連線內一幀的時間
        // 如果 計時器 過期 (為零) 就刪除 此連線物件
        // 否則 就移動
        if (life.Expired(Runner)) Runner.Despawn(Object);
        else transform.Translate(0, 0, speed * Runner.DeltaTime);
    }
    #endregion
}
