using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneLogic : MonoBehaviour
{
	[SerializeField] private Button _loadMenuButton;
	[SerializeField] private Text _coinCounterText;
	[SerializeField] private GameOverView _gameOverView;
	[SerializeField] private Timer _timer;

	[SerializeField] private CoinController _coinController;
	[SerializeField] private PlayerController _player;
	[SerializeField] private Collider _coinSpawnZone;

	private int _playerCoins;
	private void Awake()
	{
		_loadMenuButton.onClick.AddListener(LoadMenuHandler);
		
	}

	private void Start()
	{
		_timer.StartTimer();
		_player.OnGameOver += OnGameOverHandler;
		_coinController.OnCoinCollected += PlayerPointIncrease;
		_coinController.Spawn(15, _coinSpawnZone);
		_coinSpawnZone.enabled = false;
	}

	private void PlayerPointIncrease(int value)
	{
		_playerCoins += value;
		_coinCounterText.text = _playerCoins.ToString();
	}

	private void OnGameOverHandler(string gameResult)
	{
		_gameOverView.SetText($"Y O U  {gameResult} \n\nYour time is " + _timer.CurrentTimeFormated+" s\nScores: " + _playerCoins);
		_gameOverView.GameObject().SetActive(true);
		_timer.Pause(true);
	}
	
	private void LoadMenuHandler()
	{
		SceneManager.LoadScene("menu");
	}
}