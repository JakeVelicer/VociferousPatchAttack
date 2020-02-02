using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public int health;
    public int damage;
    public float speed;


    protected Transform truck;
    protected Transform trailer;

    private Camera mainCam;


    private void Start() 
    {
        truck   = GameObject.FindGameObjectWithTag("PlayerTruck").transform;
        trailer = GameObject.FindGameObjectWithTag("PlayerTrailer").transform;

        //mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    public Transform ClosestPlayer()
    {
        if (Vector2.Distance(transform.position, truck.position) < Vector2.Distance(transform.position, trailer.position))
        {
            return truck;
        }
        else
        {
            return trailer;
        }
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

    public void DamagePlayer(GameObject playerToAttack)
    {
        if (playerToAttack.name == "Truck")
        {
            playerToAttack.GetComponent<TruckMovement>().SetHealth(playerToAttack.GetComponent<TruckMovement>().GetHealth() - damage);
        }
        else if (playerToAttack.name == "Trailer")
        {
            playerToAttack.GetComponent<TrailerMovement>().SetHealth(playerToAttack.GetComponent<TrailerMovement>().GetHealth() - damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            BulletScript bulletHit = other.gameObject.GetComponent<BulletScript>();
            TakeDamage((int)(bulletHit.GetBulletDamage()));
            Destroy(other.gameObject);
        }
    }

    public void Die()
    {

    }

    public virtual void Move()
    {

    }
}
