using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject P1repairPanelLeft;
    public GameObject P1repairPanelRight;

    public GameObject P2repairPanelLeft;
    public GameObject P2repairPanelRight;

    public GameObject RepairText;

    public TextMeshProUGUI statusText;

    public Image p1Health;
    public Image p2Health;

    public Image soundImage;

    public void P1Select(int whichOne)
    {
        if (whichOne == 1)
        {
            P1repairPanelLeft.SetActive(true);
            P1repairPanelRight.SetActive(false);
        }
        else
        {
            P1repairPanelLeft.SetActive(false);
            P1repairPanelRight.SetActive(true);
        }
    }

    public void P2Select(int whichOne)
    {
        if (whichOne == 1)
        {
             P2repairPanelLeft.SetActive(true);
            P2repairPanelRight.SetActive(false);
        }
        else
        {
             P2repairPanelLeft.SetActive(false);
            P2repairPanelRight.SetActive(true);
        }
    }

    public bool P1Selected()
    {
        return (P1repairPanelLeft.activeSelf && P2repairPanelRight.activeSelf);
    }

    public bool P2Selected()
    {
        return (P1repairPanelRight.activeSelf && P2repairPanelRight.activeSelf);
    }

    private void Update() 
    {
        if (P1Selected())
        {
            //repair car
        }
        else if (P2Selected())
        {
            //repair gun
        }
    }

    public void DeactivateAllPanels()
    {
        P1repairPanelLeft.SetActive(false);
        P1repairPanelRight.SetActive(false);

        P1repairPanelLeft.SetActive(false);
        P1repairPanelRight.SetActive(false);
    }

    public void ActivateRepairMode()
    {
        statusText.text = "Lockdown";

        P1Select(1);
        P2Select(2);
    }

    public void DeactivateRepairMode()
    {
        statusText.text = "Moving";

        DeactivateAllPanels();
    }

    public void UpdateSoundBar(float newFill)
    {
        soundImage.fillAmount = newFill;
    }

    public void setPlayer1HealthBar(float currentHealth, float MaxHealth)
    {
        p1Health.fillAmount = (currentHealth / MaxHealth);
    }

    public void setPlayer2HealthBar(float currentHealth, float MaxHealth)
    {
        p2Health.fillAmount = (currentHealth / MaxHealth);
    }




}
