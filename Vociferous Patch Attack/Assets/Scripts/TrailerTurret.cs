using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerTurret : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float rotateSpeed;
    public float bulletSpeed;
    public float fireRate;
    private bool shooting;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!MicInput.micInstance.GetRepairMode())
        {
            if(Input.GetAxisRaw("HorizontalTurret") < 0)
            {
                transform.Rotate(Vector3.forward * (rotateSpeed * Time.fixedDeltaTime));
            }
            else if (Input.GetAxisRaw("HorizontalTurret") > 0)
            {
                transform.Rotate(Vector3.forward * (-rotateSpeed * Time.fixedDeltaTime));
            }

            if (Input.GetButtonDown("FireTurret") && !shooting)
            {
                shooting = true;
            }
            else if (Input.GetButtonUp("FireTurret"))
            {
                shooting = false;
            }
        }
        else
        {
            shooting = false;
        }

        if (shooting)
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= fireRate)
            {
                Shoot();
                currentTimer = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.GetComponent<BulletScript>().SetBulletSpeed(bulletSpeed);
    }
}
