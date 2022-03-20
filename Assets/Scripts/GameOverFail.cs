using System;
using UnityEngine;

public class GameOverFail : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent<PlayerController>(out var player))
		{
			player.GameOver("L O S E");
		}
	}
}
