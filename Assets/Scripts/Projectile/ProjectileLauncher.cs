using System;
using System.Collections;
using System.Collections.Generic;
using HealthSystems;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Windows.Input;
using Photon.Pun;

namespace Projectile
{
    public class ProjectileLauncher : MonoBehaviour
    {
        public GameObject projectilePrefab;
        private Joystick _joystick;

        public float shootTime;      //time between projectiles
        private float _shootCounter; //how much time left before shoot
        
        private PhotonView _view;

        void Start()
        {
            _shootCounter = shootTime;
            _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
            _view = GetComponent<PhotonView>();
        }

        void FixedUpdate()
        {
            var x = _joystick.Horizontal;
            var y = _joystick.Vertical;
            if (_view.IsMine)
            {
                if (_shootCounter <= 0 && (x != 0 || y != 0))
                {
                    PhotonNetwork.Instantiate(projectilePrefab.name, transform.position, transform.parent.rotation);
                    _shootCounter = shootTime;
                }
                _shootCounter -= Time.deltaTime;
            }
        }
    }
}
