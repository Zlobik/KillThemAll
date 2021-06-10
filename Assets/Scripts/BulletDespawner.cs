using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
            Destroy(collision.gameObject);
    }
}
