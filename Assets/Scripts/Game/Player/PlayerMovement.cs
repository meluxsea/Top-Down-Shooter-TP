using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float screenBorder;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;
    private Vector2 _smoothMoveInput;
    private Vector2 _smoothMoveSpeed;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _camera = Camera.main;

    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateOnDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothMoveInput = Vector2.SmoothDamp(
            _smoothMoveInput, _moveInput
            , ref _smoothMoveSpeed,
            0.1f);

        _rigidbody.velocity = _smoothMoveInput * _moveSpeed;
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && _rigidbody.velocity.x < 0) || 
            (screenPosition.x > _camera.pixelWidth - screenBorder && _rigidbody.velocity.x > 0))
                

        {
          _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if ((screenPosition.y < screenBorder && _rigidbody.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - screenBorder && _rigidbody.velocity.y > 0))


        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
    }



    private void RotateOnDirectionOfInput()
    {
        if(_moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothMoveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }


    private void OnMove(InputValue inputValue)
    {
        _moveInput = inputValue.Get<Vector2>();
    }
}
