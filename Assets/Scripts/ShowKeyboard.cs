using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ShowKeyboard : MonoBehaviour
{
    public float keyboardDistance = 0.5f; // Distance from the camera
    public Vector3 keyboardOffset = new Vector3(0f, -1.15f, 0f); // Adjust this as necessary
    public Vector3 keyboardAngleOffset = new Vector3(30f, 0f, 0f); // Angle offset relative to the camera's forward vector


    private TMP_InputField inputField;
    private Transform mainCameraTransform;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());
        mainCameraTransform = Camera.main.transform;
    }

    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);

        SetCaretColorAlpha(1);
        NonNativeKeyboard.Instance.OnClosed += Instance_OnClosed;

        // Move the keyboard in front of the camera
        NonNativeKeyboard.Instance.transform.position = mainCameraTransform.position + mainCameraTransform.forward * keyboardDistance + keyboardOffset;
        // Ensure the keyboard is facing the camera
        NonNativeKeyboard.Instance.transform.rotation = Quaternion.LookRotation(mainCameraTransform.forward);
        // // Adjust the keyboard to face the camera with the given angle offset
        NonNativeKeyboard.Instance.transform.rotation = Quaternion.Euler(mainCameraTransform.eulerAngles + keyboardAngleOffset);
    }

    void Update(){
        // Move the keyboard in front of the camera
        NonNativeKeyboard.Instance.transform.position = mainCameraTransform.position + mainCameraTransform.forward * keyboardDistance + keyboardOffset;
        // Ensure the keyboard is facing the camera
        NonNativeKeyboard.Instance.transform.rotation = Quaternion.LookRotation(mainCameraTransform.forward);
        // Adjust the keyboard to face the camera with the given angle offset
        NonNativeKeyboard.Instance.transform.rotation = Quaternion.Euler(mainCameraTransform.eulerAngles + keyboardAngleOffset);
    }

    private void Instance_OnClosed(object sender, System.EventArgs e)
    {
        SetCaretColorAlpha(0);
        NonNativeKeyboard.Instance.OnClosed -= Instance_OnClosed;
    }

    public void SetCaretColorAlpha(float value)
    {
        inputField.customCaretColor = true;
        Color caretColor = inputField.caretColor;
        caretColor.a = value;
        inputField.caretColor = caretColor;
    }
}
