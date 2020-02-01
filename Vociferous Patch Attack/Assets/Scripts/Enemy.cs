using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public int health;
    public int damage;
    public float speed;


    protected Transform player;
    private Camera mainCam;


    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }


    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
            Die();
    }

    private void Update() 
    {
        Move();
    }

    public void DamagePlayer(int damageToDeal)
    {
        Debug.Log("Player is being damaged");
    }

    public void Die()
    {

    }

    public virtual void Move()
    {

    }
}
