using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    private NetworkRunner _networkRunner;

    public GameObject paddlePrefab;
    public GameObject ballPrefab;

    void Start()
    {
        // Initialize the NetworkRunner
        _networkRunner = gameObject.GetComponent<NetworkRunner>();
        _networkRunner.AddCallbacks(this);

        // Start by joining the session lobby
        JoinLobby();
    }

    private async void JoinLobby()
    {
        await _networkRunner.JoinSessionLobby(SessionLobby.Shared);
    }

    private async void CreateOrJoinSession(GameMode mode, string sessionName)
    {
        var sceneRef = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);

        await _networkRunner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = sessionName,
            Scene = sceneRef,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            Vector3 position = new Vector3(-3, 0, 0);
            runner.Spawn(paddlePrefab, position, Quaternion.identity, player);

            if (runner.ActivePlayers.Count() == 2)
            {
                Vector3 ballPosition = Vector3.zero;
                runner.Spawn(ballPrefab, ballPosition, Quaternion.identity);
            }
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    public void OnConnectedToServer(NetworkRunner runner) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, System.ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }

    public async void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        if (sessionList.Count > 0)
        {
            // Join the first available session
            await runner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Client,
                SessionName = sessionList[0].Name,
                Scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex),
                SceneManager = gameObject.GetComponent<NetworkSceneManagerDefault>() ?? gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }
        else
        {
            // No sessions available, create a new one
            CreateOrJoinSession(GameMode.Host, "PingPongGame");
        }
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, System.ArraySegment<byte> data) { }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
}