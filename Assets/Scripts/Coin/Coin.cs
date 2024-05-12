using Photon.Pun;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviourPun, IPunObservable
    {
        private bool _isCollected = false;

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !_isCollected)
            {
                _isCollected = true;
                Collect();
            }
        }

        void Collect()
        {
            CoinCollector coinCollector = new CoinCollector();
            coinCollector.AddCoin();
            photonView.RPC("CollectCoinRPC", RpcTarget.AllBuffered);
        }

        [PunRPC]
        void CollectCoinRPC()
        {
            PhotonNetwork.Destroy(gameObject);
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_isCollected);
            }
            else
            {
                _isCollected = (bool)stream.ReceiveNext();
            }
        }
    }
}