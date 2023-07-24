using DG.Tweening;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField, NotNull] Image _hpBar;
	[SerializeField, NotNull] private TextMeshProUGUI _coinsText;
	[SerializeField, NotNull] private TextMeshProUGUI _nickname;
	[SerializeField, NotNull] private Transform _playerModel;

	private float _hp = 100;
	private int _coins = 0;
	private PhotonView _view;
	private bool _alive = true;
	

	private void Start()
	{
		_view = GetComponent<PhotonView>();
		_nickname.text = _view.Owner.NickName;
		GameManager.instance.alive++;
		GameManager.instance.aliveplayers.Add(this);
	}
	public void GetShot(float damage)
	{

		if(_hp>damage)
		{
			_hp-=damage;
			_hpBar.fillAmount = _hp/100;
		}
		else
		{
			GameManager.instance.aliveplayers.Remove(this);
			_alive = false;
			_hp =0;
			GameManager.instance.alive--;
			_playerModel.DOScale(Vector3.zero, 0.25f);
			_playerModel.gameObject.SetActive(false);
			if (!_view.IsMine) return;
			GameManager.instance.PlayerDead();
			//Dead;
		}
	}

	/*public bool Alive()
	{
		return _alive;
	}*/

	public void AddCoins()
	{
		//Debug.Log(GameManager.alive);
		_coins++;
		//Debug.Log(_coins);
		_coinsText.text = _coins.ToString();
	}

	public string GetNickname()
	{
		return _nickname.text;
	}

	public string GetScore()
	{
		return _coins.ToString();
	}
}
