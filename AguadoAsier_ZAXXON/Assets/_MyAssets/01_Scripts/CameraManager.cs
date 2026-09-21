using UnityEngine;

public class CameraManager : MonoBehaviour
{
   [SerializeField] Transform playerTransform;

    //desplazamiento de la camara
    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetZ = -30f;
        offsetY = 4f; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0f, offsetY, offsetZ);

        transform.position = playerTransform.position + offset;
    }
}
