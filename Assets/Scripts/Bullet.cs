using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _damage = 2f;
	private void Start()
	{
		StartCoroutine(DestroyBullet());
	}
	void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out var p))
		{
			//if (!p.Alive()) return;
            p.GetShot(_damage);
			Destroy(gameObject, 0.2f);
		}
	}

	private IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}

}
