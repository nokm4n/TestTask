using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField, NotNull] private TMP_InputField _createRoomName;
    [SerializeField, NotNull] private TMP_InputField _joinRoomName;

    [SerializeField, NotNull] private TMP_InputField _nickName;

    [SerializeField, NotNull] private RectTransform _nickWindow;
    [SerializeField, NotNull] private RectTransform _roomsWindow;

    [SerializeField, NotNull] private TextMeshProUGUI _errorMessage;

	private float _scaleTime = 0.25f;

    //[SerializeField, NotNull] private Text _maxPlayers;
    private void Start()
    {
        if (PlayerPrefs.HasKey("name"))
        {
            _nickName.text = PlayerPrefs.GetString("name");
			PhotonNetwork.NickName = _nickName.text;
			_roomsWindow.DOScale(Vector3.one, _scaleTime);
            _nickWindow.DOScale(Vector3.zero, _scaleTime);
        }
        else
        {
            _roomsWindow.DOScale(Vector3.zero, _scaleTime);
            _nickWindow.DOScale(Vector3.one, _scaleTime);
        }

	}
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
       /* if(_maxPlayers.ConvertTo<int>() <=1)
        {
            
        }*/
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(_createRoomName.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinRoomName.text);
    }
	public void JoinRandomRoom()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void SubmitNickBtn()
    {
        if (_nickName.text == null || _nickName.text == "NickInput" || _nickName.text == "")
        {
           // Debug.LogError("no nick");
            _errorMessage.text = "Input Nickname!";

        }
        else
        {
            Debug.Log(_nickName.text);
            PlayerPrefs.SetString("name", _nickName.text);
            PhotonNetwork.NickName = _nickName.text;

            _roomsWindow.DOScale(Vector3.one, _scaleTime);
            _nickWindow.DOScale(Vector3.zero, _scaleTime);
        }
	}

    public void ChangeNicknameWindow()
    {
		_roomsWindow.DOScale(Vector3.zero, _scaleTime);
		_nickWindow.DOScale(Vector3.one, _scaleTime);
	}
}
