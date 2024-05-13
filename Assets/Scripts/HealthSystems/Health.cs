using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HealthSystems
{
    public class Health : Player.Player
    {
        public float maxHealth;
        private float _hp;

        public bool IsAlive { get; set; }

        [SerializeField] Image _healthbar;
        EndgameManager _endgame;
        ServerScripts.GameManager _gm;

        void Start()
        {
            _hp = maxHealth;
            IsAlive = true;
            _endgame = FindAnyObjectByType<EndgameManager>();
            _gm = FindAnyObjectByType<ServerScripts.GameManager>();

           //Debug.Log(Nickname);
        }

        [PunRPC]
        public void TakeDamage(float amount)
        {
            _hp -= amount;
            if (_hp <= 0)
            {
                _hp = 0;
                IsAlive = false;


                photonView.RPC("Death", RpcTarget.AllBufferedViaServer);
                photonView.RPC("ShowDeathScreen", RpcTarget.AllBufferedViaServer);
            }
            _healthbar.fillAmount = _hp / maxHealth;
        }

        [PunRPC]
        void Death()
        {
            gameObject.SetActive(false);
        }

        [PunRPC]
        public void ShowDeathScreen()
        {
            Debug.Log("Dead:" + Nickname);
            _endgame.SetWinStatus(false);
            _endgame.SetActiveEndgame(true);
        }
    }
}
