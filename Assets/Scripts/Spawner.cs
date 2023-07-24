using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField, NotNull] private GameObject _player;
    [SerializeField, NotNull] private GameObject _coins;
    [SerializeField, NotNull] private List<Transform> _spawnPos;

    [SerializeField, NotNull] private Joystick _joy;
    [SerializeField, NotNull] private Button _shootBtn;

    private int _spawnCount = 0;
    
    void Start()
    {
        var p = PhotonNetwork.Instantiate(_player.name, _spawnPos[Random.Range(0, _spawnPos.Count)].position, Quaternion.identity);
        if(p.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.SetJoy(_joy);
        }
		if (p.TryGetComponent<Shooting>(out var shooting))
		{
            _shootBtn.onClick.AddListener(shooting.Shoot);
		}
        //GameManager.alive = PhotonNetwork.CountOfPlayers;
        Debug.Log(PhotonNetwork.CountOfPlayers + "count of players");
        Debug.Log(PhotonNetwork.NickName + "nick");
        
	}

}
