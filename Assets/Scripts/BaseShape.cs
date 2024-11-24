using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    [SerializeField] private string message;
    private static TextMeshProUGUI messageText;

    private void Start()
    {
        if (messageText == null)
        {
            messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        }
    }

    public virtual void DisplayMessage()
    {
        //Debug.Log("This is the base class message.");

        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public string Message
    {
        get => message;
        protected set => message = value;
    }
}
