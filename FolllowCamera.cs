using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] Vector3 offsets;

    void Start()
    {
        // Solo buscar si no fue asignada desde el Inspector
        if (camTransform == null)
        {
            GameObject camObj = GameObject.Find("Camara1");
            if (camObj != null)
                camTransform = camObj.transform;
            else
                Debug.LogError("No se encontró Camara1 en la escena");
        }
    }

    void LateUpdate()
    {
        if (camTransform == null) return;

        transform.position = camTransform.position + offsets;
    }
}
