using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    public bool activated;
    public float maxCharge;
    public float amountCharged;
    public Image chargeBar;
    public float chargeRate = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chargeBar.fillAmount = (amountCharged / maxCharge);
    }

    public bool GetActivated()
    {
        return activated;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerTruck") || other.gameObject.CompareTag("PlayerTrailer"))
        {
            if(GameObject.FindObjectOfType<MicInput>().GetRepairMode())
            {
                amountCharged += chargeRate * Time.fixedDeltaTime;

                if (amountCharged >= maxCharge)
                {
                    if(activated == false)
                    {
                        AudioManager.Instance.PlaySound("relayPower");
                    }
                    activated = true;
                }
            }
        }
    }
}
