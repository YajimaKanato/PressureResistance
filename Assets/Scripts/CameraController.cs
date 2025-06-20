using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Zoom Rate")]
    [Tooltip("ズーム比率を設定してください")]
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
        cam.fieldOfView += zoomRate / 2;
    }
}
