using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        
    }

    public void ZoomIn()
    {
        cam.ZoomIn();
    }

    public void ZoomOut()
    {
        cam.ZoomOut();
    }
}
