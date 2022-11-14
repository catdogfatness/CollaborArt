using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectUI : MonoBehaviour
{
    public GameObject ConnectoptionsPanelGameObject;
    public GameObject ConnectAnonoumouslyGameObject;

    #region Unity Methods
    void Start()
    {
        ConnectoptionsPanelGameObject.SetActive(true);
        ConnectAnonoumouslyGameObject.SetActive(true);
    }

    
    #endregion


}
