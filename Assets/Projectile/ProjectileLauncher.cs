using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Windows.Input;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float shootTime;      //time between projectiles
    private float _shootCounter; //how much time left before shoot

    private bool _isPressed;

        
    void Start()
    {
        _shootCounter = shootTime;
        _isPressed = false;
    }

    void Update()
    {
        if (_isPressed && _shootCounter <= 0)
        {
            Instantiate(projectilePrefab, transform.parent.position, transform.rotation);
            _shootCounter = shootTime;
            _isPressed = false;
        }
        
        _shootCounter -= Time.deltaTime;
    }

    public void Fire()
    {
        _isPressed = true;
    }
}
