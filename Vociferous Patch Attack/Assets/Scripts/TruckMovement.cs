using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public Transform truckSpriteObject;
    private Vector2 movement;
    public float health;
    private float maxHealth;

    public float healRate;
    public float healAmount;

    private float currentTimer = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0 || movement.y != 0)
        {
            truckSpriteObject.transform.eulerAngles = new Vector3( 0, 0, Mathf.Atan2(-movement.x, movement.y) * 180 / Mathf.PI);
        }

        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log("Dash");
        }

        if (MicInput.micInstance.GetRepairMode())
        {
            HealOverTime();
        }

        if (health <= 0 && GameObject.FindObjectOfType<TrailerMovement>().health <= 0)
        {
            AudioManager.Instance.PlaySound("playerDeath");
            UIManager.instance.DisplayLosePanel();
        }
    }

    void FixedUpdate()
    {
        if (!MicInput.micInstance.GetRepairMode())
        {
            rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(MicInput.micInstance.GetRepairMode())
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    public void HealOverTime()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer >= healRate)
        {
            currentTimer = 0f;
            SetHealth(GetHealth() + healAmount);
        }
    }

    public void SetHealth(float givenHealth)
    {
        health = givenHealth;
        UIManager.instance.setPlayer1HealthBar((float)health, (float)maxHealth);
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
