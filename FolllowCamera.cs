using UnityEngine;

public class FolllowCamera : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] Vector3 offsets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTransform = GameObject.Find("Camara1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camTransform.position + offsets;
    }
}
