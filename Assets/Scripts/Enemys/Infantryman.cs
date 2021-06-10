using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantryman : Enemy
{
    [SerializeField] private float _secondsBeforeNewHit;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _player = collision.GetComponent<Player>();
            StartCoroutine(Fight());
        }
        if (collision.gameObject.GetComponent<Bullet>())
            TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
    }

    private IEnumerator Fight()
    {
        var secondsBeforeNewHit = new WaitForSeconds(_secondsBeforeNewHit);

        while (true)
        {
            _player.TakeDamage(Damage);
            yield return secondsBeforeNewHit;
        }
    }
}
