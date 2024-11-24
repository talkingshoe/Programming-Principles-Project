using Unity.VisualScripting;
using UnityEngine;

public class Sphere : BaseShape
{
    private void Awake()
    {
        Message = "This is a sphere!";
    }

    public override void DisplayMessage()
    {
        base.DisplayMessage();
        //Debug.Log(Message);
        SetColor(Color.cyan);
    }
}
