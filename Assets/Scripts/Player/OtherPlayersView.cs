using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class OtherPlayersView : MonoBehaviour
    {
        private PhotonView _view;
        private SpriteRenderer _spriteRenderer;
        public Sprite otherPlayersSprite;
    
        void Start()
        {
            _view =  GetComponentInParent<PhotonView>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (!_view.IsMine)
            {
                _spriteRenderer.sprite = otherPlayersSprite;
            }
        }
    }
}
