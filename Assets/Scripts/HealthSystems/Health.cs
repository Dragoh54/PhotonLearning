using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace HealthSystems
{
    public class Health : MonoBehaviour
    {
        public float maxHealth;
        private float _hp;

        public bool isAlive;

        public RectTransform healthBar;
        void Start()
        {
            _hp = maxHealth;
            isAlive = true;
        }

        public void TakeDamage(float amount)
        {
            _hp -= amount;
            if (_hp <= 0)
            {
                _hp = 0;
                isAlive = false;
                PhotonNetwork.Destroy(gameObject);
            }

            healthBar.sizeDelta = new Vector2(_hp, healthBar.sizeDelta.y);
        }
    }
}
