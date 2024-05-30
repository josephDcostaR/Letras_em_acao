using UnityEngine;
using UnityEngine.Android;

public class CameraPermission : MonoBehaviour
{
    private const string CameraPermissionName = "android.permission.CAMERA";

    void Start()
    {
        // Verifica se a permissão da câmera já foi concedida
        if (!Permission.HasUserAuthorizedPermission(CameraPermissionName))
        {
            // Se não, solicita a permissão da câmera
            Permission.RequestUserPermission(CameraPermissionName);
        }
    }
}
