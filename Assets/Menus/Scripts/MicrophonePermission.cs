using UnityEngine;
using UnityEngine.Android;

public class MicrophonePermission : MonoBehaviour
{
    private const string MicrophonePermissionName = "android.permission.RECORD_AUDIO";

    void Start()
    {
        // Verifica se a permissão já foi concedida
        if (!Permission.HasUserAuthorizedPermission(MicrophonePermissionName))
        {
            // Se não, solicita a permissão
            Permission.RequestUserPermission(MicrophonePermissionName);
        }
    }
}
