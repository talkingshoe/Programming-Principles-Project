using UnityEngine;

//INHERITANCE
public class Cube : BaseShape
{
    private void Awake()
    {
        Message = "This is a cube!";
    }

    //POLYMORPHISM
    public override void DisplayMessage()
    {
        base.DisplayMessage();
        //Debug.Log(Message);
        SetColor(Color.green);
    }
}
