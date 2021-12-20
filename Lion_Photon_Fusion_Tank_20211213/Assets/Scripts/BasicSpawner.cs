using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fusion;                           // 引用 Fusion 命名空間
using Fusion.Sockets;
using System;
using System.Collections.Generic;

// INetworkRunnerCallbacks 連線執行器回呼介面，Runner 執行器處理行為後會回呼此介面的方法
/// <summary>
/// 連線基底生成器
/// </summary>
public class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    #region 欄位
    [Header("創建與加入房間欄位")]
    public InputField inputFieldCreateRoom;
    public InputField inputFieldJoinRoom;
    [Header("玩家控制物件 - 連線預製物")]
    public NetworkPrefabRef goPlayer;
    [Header("畫布連線")]
    public GameObject goCanvas;

    /// <summary>
    /// 玩家輸入的房間名稱
    /// </summary>
    private string roomNameInput;
    /// <summary>
    /// 連線執行器
    /// </summary>
    private NetworkRunner runner;
    #endregion

    #region 方法
    /// <summary>
    /// 按鈕點擊呼叫：創建房間
    /// </summary>
    public void BtnCreateRoom()
    {
        roomNameInput = inputFieldCreateRoom.text;
        print("創建房間：" + roomNameInput);
        StartGame(GameMode.Host);
    }

    /// <summary>
    /// 按鈕點擊呼叫：加入房間
    /// </summary>
    public void BtnJoinRoom()
    {
        roomNameInput = inputFieldJoinRoom.text;
        print("加入房間：" + roomNameInput);
        StartGame(GameMode.Client);
    }

    // async 非同步處理：執行系統時處理連線
    /// <summary>
    /// 開始連線遊戲
    /// </summary>
    /// <param name="mode">連線模式：主機、客戶</param>
    private async void StartGame(GameMode mode)
    {
        print("<color=yellow>開始連線</color>");

        runner = gameObject.AddComponent<NetworkRunner>();      // 連線執行器 = 添加元件<連線執行器>
        runner.ProvideInput = true;                             // 連線執行器.是否提供輸入 = 是

        // 等待連線：遊戲連線模式、房間名稱、連線後的場景、場景管理器
        await runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomNameInput,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneObjectProvider = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        print("<color=yellow>連線完成</color>");
        goCanvas.SetActive(false);
    }
    #endregion

    #region Fusion 回呼函式區域
    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    /// <summary>
    /// 當玩家成功加入房間後
    /// </summary>
    /// <param name="runner">連線執行器</param>
    /// <param name="player">玩家資訊</param>
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // 連線執行器.生成(物件，座標，角度，玩家資訊)
        runner.Spawn(goPlayer, new Vector3(-5, 1, -10), Quaternion.identity, player);
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
    #endregion
}
