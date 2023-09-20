using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playermovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    public Transform plane;

    // [SerializeField] private AnimatorController _animatorController;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    // public Transform leftPoint, rightPoint, forwardPoint;
    // public float rotateSpeed = 50f;
    // Vector3 mousePosition;
	// bool isGameOver;
    private Vector2 target;
    


    private Rigidbody _rigidbody;
    

    private Vector3 _moveVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        movePlane();
        // rotatePlane(Input.GetAxis("Horizontal"));
    }


    void movePlane(){
		_rigidbody.velocity = transform.right * _moveSpeed;
        
	}

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.y = _joystick.Vertical * _moveSpeed * Time.deltaTime;

      

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            // Vector2 direction = Vector2.MoveTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            Vector2 direction = Vector2.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(direction);
            // Quaternion toRotation = Quaternion.LookRotation (Vector3. forward, movementDirection);
            // transform.rotation = Quaternion. RotateTowards (transform. rotation, toRotation, rotationSpeed Time.deltaTime);|

            // _animatorController.PlayRun();
        }

        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            // _animatorController.PlayIdle();
        }

        // Vector3 moveDir = new Vector3(_moveVector.x, 0f, _moveVector.y);

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }

    // void rotatePlane(float x){	
	// 	float angle;
	// 	Vector2 direction = new Vector2(0,0);

	// 	if(x < 0) direction = (Vector2) leftPoint.position - _rigidbody.position;
	// 	if(x > 0) direction = (Vector2) rightPoint.position - _rigidbody.position;
		
	// 	direction.Normalize();
	// 	angle = Vector3.Cross(direction, transform.up).x;
	// 	if(x != 0) _rigidbody.angularVelocity = -rotateSpeed * angle;
	// 	else _rigidbody . angularVelocity = 0;
	// 	angle = Mathf.Atan2(forwardPoint.position.y - plane.transform.position.y, forwardPoint.position.x - plane.transform.position.x) * Mathf.Rad2Deg;
	// 	plane.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
	// }

}