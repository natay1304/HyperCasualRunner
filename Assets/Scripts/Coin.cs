using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private MeshRenderer _view;
    public event Action OnCoinCollected;
    private int _coinValue = 1;

    public int CoinValue
    {
        get => _coinValue;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>( out var player))
        {
            CollecteCoin();
        }
    }

    private void CollecteCoin()
    {
        _view.enabled = false;
        _particle.GameObject().SetActive(true);
        OnCoinCollected?.Invoke();
    }
}
