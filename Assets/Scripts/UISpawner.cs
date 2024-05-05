// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR;

// public class UISpawner : MonoBehaviour
// {
//     public GameObject UIPrefab;
//     private List<InputDevice> rightHandDevices = new List<InputDevice>();

//     private void GetRightHandDevices()
//     {
//         InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);
//     }

//     void Update()
//     {
//         if (rightHandDevices.Count == 0)
//         {
//             GetRightHandDevices();
//         }

//         foreach (var device in rightHandDevices)
//         {
//             bool primaryButtonPressed = false;
//             if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
//             {
//                 Instantiate(UIPrefab, transform.position, Quaternion.identity);
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ButtonPressDetector : MonoBehaviour
{
    public GameObject UIPrefab;
    // private InputDevice device;
    private bool previousButtonState = false;  // Tracks the button state from the previous frame

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

        bool primaryButtonPressed = false;
        foreach (var device in rightHandDevices) {
            // Check if the primary button is pressed
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed))
            {
                // Check if the button was not pressed before but is pressed now
                if (!previousButtonState && primaryButtonPressed)
                {
                    Debug.Log("Primary button was just pressed.");
                    // Here, you can add your code to handle the button press event
                    Instantiate(UIPrefab, transform.position, Quaternion.identity);
                    break;
                }
            }
        }

        // Update the previous button state for the next frame
        previousButtonState = primaryButtonPressed;
    }
}
