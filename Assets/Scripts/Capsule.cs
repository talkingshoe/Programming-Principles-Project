using UnityEngine;

public class Capsule : BaseShape
{
    private void Awake()
    {
        Message = "This is a capsule!";
    }

    public override void DisplayMessage()
    {
        base.DisplayMessage();
        //Debug.Log(Message);
        SetColor(Color.yellow);
    }
}
