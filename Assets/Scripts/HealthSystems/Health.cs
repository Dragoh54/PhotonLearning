using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HealthSystems
{
    public class Health : MonoBehaviourPun
    {
        public float maxHealth;
        private float _hp;

        public bool isAlive;

        //public RectTransform healthBar;
        [SerializeField] Image _healthbar;
        EndgameManager _endgame;
        ServerScripts.GameManager _gm;

        void Start()
        {
            _hp = maxHealth;
            isAlive = true;
            _endgame = FindAnyObjectByType<EndgameManager>();
            _gm = FindAnyObjectByType<ServerScripts.GameManager>();
        }

        [PunRPC]
        public void TakeDamage(float amount)
        {
            Debug.Log(_hp);
            _hp -= amount;
            if (_hp <= 0)
            {
                _hp = 0;
                isAlive = false;

                _gm.IsLocalAlive = isAlive;

                _endgame.SetWinStatus(false);

                _endgame.SetActiveEndgame(true);

                if (photonView.IsMine)
                {
                    Death();
                }
                //photonView.RPC("Death", RpcTarget.AllBufferedViaServer);
            }

            //healthBar.sizeDelta = new Vector2(_hp, healthBar.sizeDelta.y);
            _healthbar.fillAmount = _hp / maxHealth;
        }

        [PunRPC]
        void Death()
        {
            gameObject.SetActive(false);
        }
    }
}
