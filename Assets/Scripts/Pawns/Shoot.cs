using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;
    private bool _fireContinuously;



    // Update is called once per frame
    void Update()
    {
        if (_fireContinuously)
        {
            FireBullet();
        }
    }


    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;
        Debug.Log("We Fired");
    }

    private void FireBullet()
    {
        GameObject projectile = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _bulletSpeed * transform.up; //TODO: swap out transform.up for nearest enemy location
    }
}
