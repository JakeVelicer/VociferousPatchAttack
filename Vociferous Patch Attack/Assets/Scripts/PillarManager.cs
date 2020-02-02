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
        for(int i = 0; i < pillarScripts.Length; i++)
        {
            if(!pillarScripts[i].GetComponent<Pillar>().GetActivated())
            {
                break;
            }
            // win condition
        }

    }
}
