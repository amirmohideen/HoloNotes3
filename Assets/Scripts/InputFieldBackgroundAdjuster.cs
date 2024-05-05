using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldBackgroundAdjuster : MonoBehaviour
{
    private InputField inputField;
    private RectTransform backgroundRect;
    public float padding = 10f;  // Adjust padding based on your needs

    void Start()
    {
        inputField = GetComponent<InputField>();
        backgroundRect = inputField.GetComponent<RectTransform>();
        UpdateBackgroundSize();
        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void ValueChangeCheck()
    {
        UpdateBackgroundSize();
    }

    private void UpdateBackgroundSize()
    {
        Text textComponent = inputField.textComponent;
        var textWidth = textComponent.preferredWidth;
        var textHeight = textComponent.preferredHeight;

        backgroundRect.sizeDelta = new Vector2(textWidth + padding, textHeight + padding);
    }
}
