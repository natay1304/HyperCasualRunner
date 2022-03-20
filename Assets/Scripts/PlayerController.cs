using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Animator _animator;

	public event Action<string> OnGameOver;

	private Quaternion _targetRotation;
	private Vector3 _mousePosition;

	private bool _gameOver;
	private Transform _transform;
	private Vector3 _newPosition;
	private float _speed = 25f;

	private void Awake()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		if(_gameOver)
     			return;
		
		if (Input.GetMouseButtonDown(0))
		{
			_animator.SetBool("IsRunning", true);
			return;
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			_animator.SetBool("IsRunning", false);
		}

		if (Input.GetMouseButton(0))
		{
			float deltaX = Input.mousePosition.x / Screen.width * 2 - 1;
			_newPosition = new Vector3(deltaX * 30, _transform.position.y, _transform.position.z);
		
			_transform.position = Vector3.Lerp(
				_transform.position,
				_newPosition,
				Time.deltaTime * 2f
			);
			transform.position += _transform.forward * _speed * Time.deltaTime;
		}
	}

	public void GameOver(string gameResult)
	{
		OnGameOver?.Invoke(gameResult);
		_gameOver = true;
	}
}