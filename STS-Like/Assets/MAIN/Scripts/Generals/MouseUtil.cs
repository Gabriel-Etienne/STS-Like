using UnityEngine;

public class MouseUtil : MonoBehaviour
{
    private static Camera mainCamera = Camera.main;
    public static Vector3 GetMousePositionInWorldSpace(float zValue = 0f)
    {
        Plane dragPlane = new(mainCamera.transform.forward, new Vector3(0,0,zValue));
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        
        return Vector3.zero;
    }
}
