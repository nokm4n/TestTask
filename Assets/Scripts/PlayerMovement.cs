using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
	private Joystick _joy;
	private Rigidbody2D _rigidbody;
    private PhotonView _view;
    private bool _isAlive = true;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        if(TryGetComponent<Rigidbody2D>(out var rd))
        {
            _rigidbody = rd;
        }    
        else
        {
            Debug.LogError("No RigidBody component");
        }
    }
    void Update()
    {
        if (!_view.IsMine || !_isAlive) return;

		Vector2 dir = new Vector3(0f, 0f);

		var xinp = _joy.Horizontal;
		var yinp = _joy.Vertical;

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		dir = new Vector2(xinp * _speed, yinp * _speed); //Joy controll
		//dir = new Vector2(h * _speed, v * _speed); //wasd controll

		if (dir != Vector2.zero) transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);

		_rigidbody.MovePosition(_rigidbody.position + dir);
	}

    public void SetJoy(Joystick joy)
    {
        _joy = joy;
    }
}
