using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int ScoreForDeath;
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float Speed;
    [SerializeField] protected float Damage;
    [SerializeField] protected Player Target;
    [SerializeField] protected string EnemyClass;

    public float MaxEnemyHealth => MaxHealth;
    public float EnemyDamage => Damage;
    public string EnemyType => EnemyClass;
    public float CurrentHealth { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            collision.GetComponent<Player>().TakeDamage(Damage);
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey($"{EnemyClass}Health"))
            MaxHealth = PlayerPrefs.GetFloat($"{EnemyClass}Health");
        if (PlayerPrefs.HasKey($"{EnemyClass}Strenght"))
            Damage = PlayerPrefs.GetFloat($"{EnemyClass}Strenght");

        //Debug.Log($"{EnemyClass} Health - {MaxHealth}, Damage - {Damage}");
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
            Die();

        CurrentHealth = Mathf.Max(0, CurrentHealth);
    }

    private void OnEnable()
    {
        CurrentHealth = MaxEnemyHealth;
    }

    private void Die()
    {
        Target.AddScore(ScoreForDeath);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position != Target.transform.position)
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
}
