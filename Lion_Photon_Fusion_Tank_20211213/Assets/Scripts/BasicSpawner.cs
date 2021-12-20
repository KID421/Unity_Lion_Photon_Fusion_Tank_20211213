using UnityEngine;
using UnityEngine.UI;
using Fusion;                           // �ޥ� Fusion �R�W�Ŷ�
using Fusion.Sockets;
using System;
using System.Collections.Generic;

// INetworkRunnerCallbacks �s�u���澹�^�I�����ARunner ���澹�B�z�欰��|�^�I����������k
/// <summary>
/// �s�u�򩳥ͦ���
/// </summary>
public class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    #region ���
    [Header("�ЫػP�[�J�ж����")]
    public InputField inputFieldCreateRoom;
    public InputField inputFieldJoinRoom;
    [Header("���a�����")]
    public GameObject goPlayer;

    /// <summary>
    /// ���a��J���ж��W��
    /// </summary>
    private string roomNameInput;
    #endregion

    #region ��k
    /// <summary>
    /// ���s�I���I�s�G�Ыةж�
    /// </summary>
    public void BtnCreateRoom()
    {
        roomNameInput = inputFieldCreateRoom.text;
        print("�Ыةж��G" + roomNameInput);
    }

    /// <summary>
    /// ���s�I���I�s�G�[�J�ж�
    /// </summary>
    public void BtnJoinRoom()
    {
        roomNameInput = inputFieldJoinRoom.text;
        print("�[�J�ж��G" + roomNameInput);
    }
    #endregion

    #region Fusion �^�I�禡�ϰ�
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

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
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
