using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerMovement : MonoBehaviour
{
    public GameObject truck;
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public float maxDistance = 3;
    private Vector2 movement;
    private float distance;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private float fractionOfJourney;

    // Start is called before the first frame update
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, truck.transform.position);
    }

    void Update()
    {
        distance = Vector3.Distance (transform.position, truck.transform.position);

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        Vector3 vectorToTarget = truck.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance > maxDistance)
        {
            rigidBody.MovePosition(Vector3.Lerp(transform.position, truck.transform.position, fractionOfJourney));
        }
    }
}
