using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    [Header("Melee Attributes")]
    public float distanceToAttack;
    public float attackRechargeRate; //time between attacks


    private float currentTimer = 0.0f;

    public override void Move()
    {
        //Move towards the player


            if (DistanceToPlayer() > distanceToAttack)
            {
                transform.position = Vector2.MoveTowards(transform.position, ClosestPlayer().position,  speed * Time.deltaTime);
            }
            else
            {
                Clawing();
            }
        
    }

    private void Clawing()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer >= attackRechargeRate)
        {
            Debug.Log("Time to attack");
            DamagePlayer(ClosestPlayer().gameObject);
            currentTimer = 0f;
        }
    }



    public float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, ClosestPlayer().position);
    }

    public override void Die()
    {
        Destroy(gameObject);
        AudioManager.Instance.PlaySound("Squish");
    }
}
