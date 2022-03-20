using UnityEngine;

public class GameOverVictory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            player.GameOver("W I N");
        }
    }
}
