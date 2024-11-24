using Unity.VisualScripting;
using UnityEngine;

//INHERITANCE
public class Sphere : BaseShape
{
    private void Awake()
    {
        Message = "This is a sphere!";
    }

    //POLYMORPHISM
    public override void DisplayMessage()
    {
        base.DisplayMessage();
        //Debug.Log(Message);
        SetColor(Color.cyan);
    }
}
