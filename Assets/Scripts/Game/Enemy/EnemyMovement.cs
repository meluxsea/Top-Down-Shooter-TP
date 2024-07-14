using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _screenBorder;

    private Rigidbody2D _rigidbody;
    private PlayerAwarnessController _playerAwarenessController;
    private Vector2 targetDirection;
    private float _ChangeDirectionCoolDown;
    private Camera _camera;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarnessController>();
        targetDirection = transform.up;
        _camera = Camera.main;
    }


    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        
        HandleRandomDirection();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
    }

    private void HandleRandomDirection()
    {
        _ChangeDirectionCoolDown -= Time.deltaTime;
        if(_ChangeDirectionCoolDown < 0 )
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange,transform.forward);
            targetDirection = rotation * targetDirection;

            _ChangeDirectionCoolDown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
       if(_playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }


    private void HandleEnemyOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _screenBorder && targetDirection.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && targetDirection.x > 0))


        {
            targetDirection = new Vector2(-targetDirection.x,targetDirection.y);
        }

        if ((screenPosition.y < _screenBorder && targetDirection.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && targetDirection.y > 0))


        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }


    private void RotateTowardsTarget()
    {
        
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,_rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);

    }
    private void SetVelocity()
    {
         
             _rigidbody.velocity = transform.up * _speed;
        

    }



}
