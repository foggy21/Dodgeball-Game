using FishNet;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.UI;

namespace Dodgeball.Scripts.Lobby
{
    public class LobbyController : NetworkBehaviour
    {
        [SerializeField] private Button _buttonStart;

        [Header("Scenes Settings")] 
        [SerializeField] private string _mainSceneName;
        [SerializeField] private string _gameSceneName;

        private void Start()
        {
            InstanceFinder.ServerManager.OnServerConnectionState += OnServerStopped;
            InstanceFinder.ClientManager.OnClientConnectionState += OnClientStopped;
        }

        public override void OnStartClient()
        {
            ShowButtonStart();
        }

        private void OnDestroy()
        {
            if (InstanceFinder.ServerManager != null)
            {
                InstanceFinder.ServerManager.OnServerConnectionState -= OnServerStopped;
            }

            if (InstanceFinder.ClientManager != null)
            {
                InstanceFinder.ClientManager.OnClientConnectionState -= OnClientStopped;
            }
        }

        [ServerRpc(RequireOwnership = false)]
        private void ShowButtonStart()
        {
            if (IsServerInitialized)
            {
                _buttonStart.gameObject.SetActive(true);   
            }
        }

        public void StartGame()
        {
            Debug.Log("Game is started");
            SceneLoadData sld = new SceneLoadData(_gameSceneName)
            {
                ReplaceScenes = ReplaceOption.All
            };
            
            InstanceFinder.SceneManager.LoadGlobalScenes(sld);
        }
        
        public void ExitLobby()
        {
            if (IsServerInitialized)
            {
                InstanceFinder.ServerManager.StopConnection(true);
            }
            InstanceFinder.ClientManager.StopConnection();
        }

        private void OnServerStopped(ServerConnectionStateArgs args)
        {
            if (args.ConnectionState == LocalConnectionState.Stopped)
            {
                Debug.Log("Server is stopped");
                SceneLoadData sld = new SceneLoadData(_mainSceneName)
                {
                    ReplaceScenes = ReplaceOption.All
                };

                InstanceFinder.SceneManager.LoadGlobalScenes(sld);
            }
        }
        
        private void OnClientStopped(ClientConnectionStateArgs args)
        {
            if (args.ConnectionState == LocalConnectionState.Stopped)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(_mainSceneName);
            }
        }
    }
}