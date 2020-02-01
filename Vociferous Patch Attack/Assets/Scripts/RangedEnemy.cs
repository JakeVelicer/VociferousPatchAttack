using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    [Header("Ranged Attributes")]

    public float fireRate;
    public float bulletSpeed;
    public GameObject bullet;
    public Transform firePoint;

    private float currentTimer;
    private bool canShoot = false;


    public override void Move()
    {
        if (canShoot)
        {
            LookAtPlayer();

            currentTimer += Time.deltaTime;

            if (currentTimer >= fireRate)
            {
                Shoot();
               currentTimer = 0f;
            }
        }

    }

    private void LookAtPlayer()
    {
        Vector2 lookDirection = ClosestPlayer().position - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

        BulletScript bulletScript = newBullet.GetComponent<BulletScript>();

        bulletScript.SetBulletSpeed(bulletSpeed);
    }

    private void OnBecameVisible() 
    {
        canShoot = true;
    }

    private void OnBecameInvisible() 
    {
        canShoot = false;
    }
}
