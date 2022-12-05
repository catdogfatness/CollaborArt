using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    public void SwitchMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
