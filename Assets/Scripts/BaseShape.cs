using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    //ENCAPSULATION
    [SerializeField] private string message;

    private static TextMeshProUGUI messageText;

    private void Start()
    {
        if (messageText == null)
        {
            messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        }
    }

    //ABSTRACTION
    public virtual void DisplayMessage()
    {
        //Debug.Log("This is the base class message.");

        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    //ABSTRACTION
    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    //ENCAPSULATION
    public string Message
    {
        get => message;
        protected set => message = value;
    }
}
