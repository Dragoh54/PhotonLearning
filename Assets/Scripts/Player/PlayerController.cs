using UnityEngine;
using Photon.Pun;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Vector2 _moveVector;
        private Rigidbody2D _rb;

        private Joystick _joystick;

        private PhotonView _view;
        private SpriteRenderer _spriteRenderer;
        public Sprite otherPlayersSprite;

        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
            _view = GetComponent<PhotonView>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (!_view.IsMine)
            {
                _spriteRenderer.sprite = otherPlayersSprite;
            }
        }

        private void FixedUpdate()
        {
            var x = _joystick.Horizontal * speed;
            var y = _joystick.Vertical * speed;
            if (_view.IsMine)
            {
                Vector3 moveVector = Vector3.up * y / speed - Vector3.left * x / speed;
                if (x != 0 || y != 0)
                {
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                }
                _rb.velocity = new Vector2(x, y);
            }
        }
    }
}

