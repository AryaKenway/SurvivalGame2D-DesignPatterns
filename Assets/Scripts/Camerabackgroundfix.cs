using UnityEngine;

public class CameraBackgroundFix : MonoBehaviour
{
    void Start()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.cyan; // Change this to any color
    }
}
