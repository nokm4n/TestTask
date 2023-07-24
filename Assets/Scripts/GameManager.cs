using DG.Tweening;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField, NotNull] private RectTransform _gameplayCanv;
    [SerializeField, NotNull] private RectTransform _deadCanv;
    [SerializeField, NotNull] private RectTransform _prepareCanv;
    [SerializeField, NotNull] private RectTransform _winCanv;

	[SerializeField, NotNull] private TextMeshProUGUI _winnerNick;
	[SerializeField, NotNull] private TextMeshProUGUI _winnerScore;

	[SerializeField, NotNull] private TextMeshProUGUI _alive;

	private bool _gameStarted = false;


	public List<Player> aliveplayers;
	public int alive = 0;
	public static GameManager instance;

	private void Awake()
	{
		{
			if (instance != null)
			{
				Debug.Log("More than 1 GameManager in scene");
			}
			instance = this;
		}
		_prepareCanv.DOScale(Vector3.one, 0.25f);
		_gameplayCanv.DOScale(Vector3.zero, 0.25f);
	}

	private void Update()
	{
		_alive.text = alive.ToString();
		if (alive > 1)
		{
			_prepareCanv.DOScale(Vector3.zero, 0.25f);
			_gameplayCanv.DOScale(Vector3.one, 0.25f);
			_gameStarted = true;
		}

		if(_gameStarted && alive <2)
		{
			_winnerNick.text = aliveplayers[0].GetNickname();
			_winnerScore.text = aliveplayers[0].GetScore();
			_deadCanv.DOScale(Vector3.zero, 0.25f);
			_gameplayCanv.DOScale(Vector3.zero, 0.25f);
			_winCanv.DOScale(Vector3.one, 0.25f);
		}
	}

	public void PlayerDead()
	{
		_gameplayCanv.DOScale(Vector3.zero, 0.25f);
		_deadCanv.DOScale(Vector3.one, 0.25f);
	}

	public void ExitToMenu()
	{
		//alive--;
		PhotonNetwork.Disconnect();
		SceneManager.LoadScene(0);
	}


}
