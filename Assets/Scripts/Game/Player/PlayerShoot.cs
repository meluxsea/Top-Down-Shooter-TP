using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;
    
    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    private bool _FireCont;
    private bool _FireSingle;
    private float _lastFireTime;

    // Update is called once per frame
    void Update()
    {
        if (_FireCont || _FireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {

                FireBullet();

                _lastFireTime = Time.time;
                _FireSingle = false;
            }
        }
    }


    private void FireBullet()
    {
        GameObject bullet = Instantiate( _bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        _FireCont = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _FireSingle = true;
        }
    } 
}
