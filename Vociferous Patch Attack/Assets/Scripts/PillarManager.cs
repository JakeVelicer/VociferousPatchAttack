using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public Pillar[] pillarScripts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         int relaysActivated = 0;

        for (int i = 0; i < pillarScripts.Length; i++)
        {
            if(pillarScripts[i].GetComponent<Pillar>().GetActivated())
            {
                relaysActivated++;
            }
        }

        UIManager.instance.updateRelayDisplayText(relaysActivated, pillarScripts.Length);
       

        for(int i = 0; i < pillarScripts.Length; i++)
        {
            if(!pillarScripts[i].GetComponent<Pillar>().GetActivated())
            {
                break;
            }
            UIManager.instance.DisplayWinPanel();
        }

    }
}
