using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Resources.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Vector2 _moveVector;
        private Rigidbody2D _rb;

        public Joystick joystick;

        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector3 moveVector = (Vector3.up * joystick.Vertical - Vector3.left * joystick.Horizontal);
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            }
        }

        private void FixedUpdate()
            {
                _rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
            }
    }
}
