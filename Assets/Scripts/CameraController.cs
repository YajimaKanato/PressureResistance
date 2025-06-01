using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Zoom Rate")]
    [Tooltip("ƒY[ƒ€”ä—¦‚ğİ’è‚µ‚Ä‚­‚¾‚³‚¢")]
    [Range(5.0f, 6.0f)]
    [SerializeField]
    float zoomRate = 5.5f;

    private Camera cam;

    private void Start()
    {

        cam = GetComponent<Camera>();
    }

    public void ZoomIn()
    {

        cam.fieldOfView -= zoomRate;
    }

    public void ZoomOut()
    {
        cam.fieldOfView += zoomRate;
    }
}
