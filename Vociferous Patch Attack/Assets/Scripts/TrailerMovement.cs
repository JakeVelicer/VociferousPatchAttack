using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerMovement : MonoBehaviour
{
    public GameObject truck;
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public float maxDistance = 3;
    public float health;

    private float maxHealth;
    private float distance;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        distance = Vector3.Distance (transform.position, truck.transform.position);

        // Rotation Management
        Vector3 vectorToTarget = truck.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

        if (distance > maxDistance)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
            rigidBody.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove && !MicInput.micInstance.GetRepairMode())
        {
            rigidBody.velocity = (truck.transform.position - transform.position) * moveSpeed;
        }
        else if(MicInput.micInstance.GetRepairMode())
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    public void SetHealth(float givenHealth)
    {
        health = givenHealth;
        UIManager.instance.setPlayer2HealthBar((float)givenHealth, (float)maxHealth);
    }

    public float GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            SetHealth(health - other.gameObject.GetComponent<BulletScript>().GetBulletDamage());
            Destroy(other.gameObject);
        }
    }
}
