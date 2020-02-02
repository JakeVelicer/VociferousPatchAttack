using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private float bulletSpeed = 0;

    private float bulletDamage = 0f;


    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    public void SetBulletSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }

    public void SetBulletDamage(float newDamage)
    {
        bulletDamage = newDamage;
    }
}
