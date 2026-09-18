using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 36f;
        desplSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime);
    }
}
