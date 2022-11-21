using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    public GameObject[] penLists;

    public void SwitchPen(string name)
    {
        for(int i =0 ;i< penLists.Length ; i++)
        {
            if(penLists[i].name == name)
            {
                penLists[i].SetActive(true);
            }
            else
            {
                
                 penLists[i].SetActive(false);
            }
        }
    }
}
