using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Transporting;
using FishNet.Transporting.Tugboat;
using TMPro;
using UnityEngine;

namespace Dodgeball.Menu
{
    public class MenuController : MonoBehaviour
    {
        [Header("Tugboat Reference")] [SerializeField]
        private Tugboat _tugboat;

        [Header("UI References")] [SerializeField]
        private TMP_InputField _inputField;

        [Header("Lobby Scene Settings")] [SerializeField]
        private string _lobbySceneName;

        private void Start()
        {
            InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
            InstanceFinder.ServerManager.OnServerConnectionState += OnServerStarted;
        }

        private void OnDestroy()
        {
            if (InstanceFinder.ClientManager != null)
            {
                InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;
            }

            if (InstanceFinder.ServerManager != null)
            {
                InstanceFinder.ServerManager.OnServerConnectionState -= OnServerStarted;
            }
        }

        public void CreateLobby()
        {
            InstanceFinder.ServerManager.StartConnection();
            InstanceFinder.ClientManager.StartConnection();
        }

        public void JoinLobby()
        {
            if (_inputField == null)
            {
                throw new NullReferenceException("Input field is null. Set it from UI.");
            }

            string ip = _inputField.text;

            if (string.IsNullOrEmpty(ip))
            {
                ip = "localhost";
            }

            if (_tugboat == null)
            {
                throw new NullReferenceException("Tugboat component reference is null. " +
                                                 "Set it from game object.");
            }

            _tugboat.SetClientAddress(ip);

            InstanceFinder.ClientManager.StartConnection();
        }

        private void OnServerStarted(ServerConnectionStateArgs args)
        {
            if (args.ConnectionState == LocalConnectionState.Started)
            {
                Debug.Log("Server Started");
                SceneLoadData sld = new SceneLoadData(_lobbySceneName)
                {
                    ReplaceScenes = ReplaceOption.All
                };

                InstanceFinder.SceneManager.LoadGlobalScenes(sld);
            }
        }

        private void OnClientConnectionState(ClientConnectionStateArgs args)
        {
            if (args.ConnectionState == LocalConnectionState.Stopped)
            {
                Debug.Log("Client Disconnected");
            }
            else if (args.ConnectionState == LocalConnectionState.Started)
            {
                Debug.Log("Client Started");
            }
        }
    }
}