using FishNet.Object;
using TMPro;
using UnityEngine;

namespace Dodgeball.Scripts.Lobby
{
    public class PlayerCounter : NetworkBehaviour
    {
        [SerializeField] private TMP_Text _playersCountText;
        
        private int _playersCount;

        public override void OnStartClient()
        {
            ChangePlayerCountText(ClientManager.Clients.Count);
        }

        [ServerRpc(RequireOwnership = false)]
        private void ChangePlayerCountText(int playersCount)
        {
            _playersCount = playersCount;
            ChangePlayersCountTextAtObservers(_playersCount);
        }

        [ObserversRpc]
        private void ChangePlayersCountTextAtObservers(int playersCount)
        {
            _playersCount = playersCount;
            _playersCountText.text = $"Игроков в лобби {_playersCount} / 2";
        }
    }
}