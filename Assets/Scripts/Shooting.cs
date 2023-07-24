using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField, NotNull] private Bullet _bullet;
    [SerializeField, NotNull] private Transform _shotPos;

    public void Shoot()
    {
        PhotonNetwork.Instantiate(_bullet.name, _shotPos.position, _shotPos.rotation);
    }
}
