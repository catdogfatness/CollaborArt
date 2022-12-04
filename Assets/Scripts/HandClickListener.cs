using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandClickListener : MonoBehaviour
{
     public UnityEvent triggerEvent;
    
    private UnityEngine.XR.InputDevice leftHand_device;

    public ButtonType buttonType;
    private void OnEnable() {
      
        GetLeftHand(); 
    }
 
    public void GetLeftHand()
    {
        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
 
        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("左手设备名 '{0}' 该设备具有的特征 '{1}'", device.name, device.characteristics.ToString()));
            leftHand_device=device;
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool istrigger = false;
        switch (buttonType)
        {
            case ButtonType.gripButton:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out istrigger);
                break;
            case ButtonType.menuButton:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out istrigger);
                break;
            case ButtonType.primaryButton:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out istrigger);
                break;
            case ButtonType.primaryTouch:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryTouch, out istrigger);
                break;
            case ButtonType.secondaryButton:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out istrigger);
                break;
            case ButtonType.secondaryTouch:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryTouch, out istrigger);
                break;
            case ButtonType.triggerButton:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out istrigger);
                break;
            case ButtonType.primary2DAxisClick:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out istrigger);
                break;
            case ButtonType.primary2DAxisTouch:
                leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out istrigger);
                break;
        }

        if (istrigger)
        {
            triggerEvent.Invoke();
        }
}
}

[Serializable]
public enum ButtonType
{
    gripButton,
    menuButton,
    primaryButton,
    primaryTouch,
    secondaryButton,
    secondaryTouch,
    triggerButton,
    primary2DAxisClick,
    primary2DAxisTouch
}
