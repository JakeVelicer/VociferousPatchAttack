using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public Transform truckSpriteObject;
    private Vector2 movement;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void FixedUpdate()
    {
        if (MicInput.micInstance.GetRepairMode())
        {
            rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(!MicInput.micInstance.GetRepairMode())
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    public void SetHealth(float givenHealth)
    {
        health = givenHealth;
    }

    public float GetHealth()
    {
        return health;
    }
}
