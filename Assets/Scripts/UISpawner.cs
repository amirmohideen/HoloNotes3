using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UISpawner : MonoBehaviour
{
    public GameObject UIPrefab;
    private List<InputDevice> rightHandDevices = new List<InputDevice>();

    private void GetRightHandDevices()
    {
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
    }

    void Update()
    {
        if (rightHandDevices.Count == 0)
        {
            GetRightHandDevices();
        }

        foreach (var device in rightHandDevices)
        {
            bool primaryButtonPressed;
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
            {
                Instantiate(UIPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
