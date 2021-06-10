using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int MaxHealth;

    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            CurrentHealth -= MaxHealth - collision.GetComponent<Bullet>().Damage;
            CurrentHealth = Mathf.Max(0, CurrentHealth);
        }
    }
}
