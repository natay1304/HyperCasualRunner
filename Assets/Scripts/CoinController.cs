using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinController : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab; 
    public event Action<int> OnCoinCollected;

    private async Task OnCoinWasCollectedHandler(Coin coin)
    {
        OnCoinCollected?.Invoke(coin.CoinValue);
        await Task.Delay(TimeSpan.FromSeconds(1f)); 
        Destroy(coin.gameObject);
    }

    public void Spawn(int count, Collider collider)
    {
        var deltaX = (collider.bounds.max.x - collider.bounds.min.x) / count;
        var x = collider.bounds.min.x;
        for (int i = 0; i < count; i++)
        {
            x += deltaX;
            var z = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            var coin = Instantiate(_coinPrefab, new Vector3(x, 1, z), Quaternion.identity);
            coin.OnCoinCollected += () => OnCoinWasCollectedHandler(coin);
        }
    }
}
