using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //movimiento en x
    float MoveX;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        inputActions.Player.MoveX.performed += ctx => MoveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += ctx => MoveX = 0f; 
    }

    void Shoot()
    {
        print("PUUUUUM");
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

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
