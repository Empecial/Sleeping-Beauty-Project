using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    public GameObject BossHealthBar;
    public GameObject BossAttack;

    public bool BossIsAttacking = false;
    public bool BossStartAttack = false;
    public float BossAttackDelay;
    private float BossAttackTimer;

    public float TimeToNextAttack = 0;
    public float AddTimeToNextAttack = 15;

    public bool CanAttackBoss = false;
    public float BossHealth;

    private float AttackCooldown = 15;
    private float NextAttack = 0;

    public bool OnlyOnce = true;
    public bool BossDefeated = false;

    public Sprite[] HealthBar;

    void Start()
    {
        BossHealthBar.GetComponent<SpriteRenderer>();

        
    }

    void Update()
    {
        if (CanAttackBoss && Input.GetKeyDown(KeyCode.E) && Time.time >= NextAttack)
        {
            BossHealth++;
            NextAttack = Time.time + AttackCooldown;
        }

        if (BossHealth >= 3)
        {
            BossIsAttacking = false;
        }

        if (BossStartAttack && BossIsAttacking && Time.time >= TimeToNextAttack)
        {
            TimeToNextAttack = Time.time + AddTimeToNextAttack;
            InvokeRepeating("SpawnAttack", BossAttackTimer, BossAttackDelay);
        }

        if (OnlyOnce == false)
        {
            switch (BossHealth) //Man skal ændre clonens sprite ikke prefab (Big dum dum)
            {
                case 0:
                    BossHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBar[0];
                    break;

                case 1:
                    BossHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBar[1];
                    break;

                case 2:
                    BossHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBar[2];
                    break;

                case 3:
                    BossHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBar[3];
                    BossDefeated = true;
                    BossHealthBar.SetActive(false);
                    Debug.Log("boss is defeated");

                    break;
                default:
                    BossHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBar[3];
                    
                    break;
            }
        }
    }

    public void SpawnAttack()
    {
        Instantiate(BossAttack, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnlyOnce && collision.name == "Player")
        {
            BossIsAttacking = true;
            BossStartAttack = true;
            OnlyOnce = false;
        }

        if (BossStartAttack && collision.name == "Player")
        {
            CanAttackBoss = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            CanAttackBoss = false;
        }
    }
}
