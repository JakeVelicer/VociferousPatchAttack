using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


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

    public GameObject basePanel;

    public GameObject RepairText;

    public TextMeshProUGUI statusText;

    public TextMeshProUGUI relayDisplayText;

    public GameObject winPanel;
    public GameObject losePanel;

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

    private bool p1selectsP1;
    private bool p2selectsP1;

    private bool p1selectsP2;

    private bool p2selectsP2;

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

        

        if (isLockedDown())
        {
            // if (Input.GetAxisRaw("Horizontal") > 0.0f)
            // {
            //     P1Select(2);
            // }
            // else if (Input.GetAxis("Horizontal") < 0.0f)
            // {
            //     P1Select(1);
            // }

            // if (Input.GetAxisRaw("HorizontalTurret") > 0.0f)
            // {
            //     P2Select(2);
            // }
            // else if (Input.GetAxis("HorizontalTurret") < 0.0f)
            // {
            //     P2Select(1);
            // }

            // if (Input.GetButtonDown("FireTurret") && P1repairPanelLeft.activeSelf)
            // {
            //     p1selectsP1 = true;
            // }

            // if (Input.GetButtonDown("Dash") && P2repairPanelLeft.activeSelf)
            // {
            //     p2selectsP1 = true;
            // }


            // if (Input.GetButtonDown("FireTurret") && P1repairPanelRight.activeSelf)
            // {
            //     p1selectsP2 = true;
            // }
            // else if (Input.GetButtonUp("FireTurret"))
            // {
            //     p1selectsP2 = false;
            // }

            // if (Input.GetButtonDown("Dash") && P2repairPanelRight.activeSelf)
            // {
            //     p2selectsP2 = true;
            // }
            // else if (Input.GetButtonUp("Dash"))
            // {
            //     p2selectsP2 = false;
            // }

            // if (p1selectsP2 && p2selectsP2)
            // {
            //     //start repairing player 2
            // }
        }
    }

    public void DeactivateAllPanels()
    {
        P1repairPanelLeft.SetActive(false);
        P1repairPanelRight.SetActive(false);

        P2repairPanelLeft.SetActive(false);
        P2repairPanelRight.SetActive(false);
    }

    public void DisplayWinPanel()
    {
        basePanel.SetActive(false);
        winPanel.SetActive(true);
        StartCoroutine(ReturnToMainMenu());
    }

    public void DisplayLosePanel()
    {
        basePanel.SetActive(false);
        losePanel.SetActive(true);
        StartCoroutine(ReturnToMainMenu());
    }

    public void updateRelayDisplayText(int currentRelays, int maxRelays)
    {
        relayDisplayText.text = currentRelays.ToString() + "/" + maxRelays.ToString() + " Activated";
    }

    public void ActivateRepairMode()
    {
        statusText.text = "Repairing";

        //P1Select(1);
        //P2Select(2);
    }



    public bool isLockedDown()
    {
        return (P1repairPanelLeft.activeSelf || P1repairPanelRight.activeSelf || P2repairPanelLeft.activeSelf || P2repairPanelRight.activeSelf);
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

    public IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Menu");
    }


}
