using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public bool activated;
    public float maxCharge;
    public float amountCharged;
    private bool charging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charging)
        {
            
        }
    }

    public bool GetActivated()
    {
        return activated;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("PlayerTruck") || other.gameObject.CompareTag("PlayerTruck"))
        {
            if(MicInput.micInstance.GetRepairMode())
            {
                charging = true;
            }
            else
            {
                charging = false;
            }
        }
        else
        {
            charging = false;
        }
    }
}
