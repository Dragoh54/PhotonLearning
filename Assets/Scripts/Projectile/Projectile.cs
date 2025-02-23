using System;
using HealthSystems;
using UnityEngine;
using Photon.Pun;


namespace Projectile
{
    public class Projectile : MonoBehaviourPun
    {
        public float speed;
        public float damage;
        public float prLife;        //how much our projectile live
        private float _prCount;     //how much time projectile have

        public LayerMask layerMask;

        private PhotonView _view;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _prCount = prLife;
            _view = GetComponentInParent<PhotonView>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (!_view.IsMine)
            {
                _spriteRenderer.color = Color.red;
            }
        }

        void Update()
        {
            transform.Translate(Vector2.up * (speed * Time.deltaTime));

            _prCount -= Time.deltaTime;
            if (_prCount <= 0)
            {
                Destroy(gameObject);
            }

            /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0.1f, layerMask);
            //Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);
            if (hitInfo.collider != null)
            {
                Health enemyHp = hitInfo.collider.transform.GetComponent<Health>();      
                if (enemyHp != null)
                {
                    enemyHp.photonView.RPC("TakeDamage", RpcTarget.All, damage);
                }
                PhotonNetwork.Destroy(gameObject);
            }*/
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Health enemyHp = collision.transform.GetComponent<Health>();
            if (enemyHp != null)
            {
                PhotonNetwork.Destroy(gameObject);
                enemyHp.photonView.RPC("TakeDamage", RpcTarget.All, damage);
            }
        }
    }
}
