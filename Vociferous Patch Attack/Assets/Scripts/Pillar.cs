using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    public bool activated;
    public float maxCharge;
    public float amountCharged;
    private bool charging;
    public Image chargeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(charging)
        {
            amountCharged += 2 * Time.fixedDeltaTime;

            if (amountCharged >= maxCharge)
            {
                activated = true;
            }
        }
        chargeBar.fillAmount = (amountCharged / maxCharge);
    }

    public bool GetActivated()
    {
        return activated;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerTruck") || other.gameObject.CompareTag("PlayerTruck"))
        {
            if(MicInput.micInstance.GetRepairMode() == true)
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
