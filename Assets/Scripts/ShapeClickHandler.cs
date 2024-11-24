using UnityEngine;

public class ShapeClickHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                BaseShape shape = hit.collider.GetComponent<BaseShape>();
                if (shape != null)
                {
                    shape.DisplayMessage();
                }
            }
        }
    }
}
