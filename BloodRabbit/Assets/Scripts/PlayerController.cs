using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float moveForce = 1.0f;

    private Rigidbody2D playerRigidbody2D;

    private Animator playerAnimator;

    private float moveHorizontal;
    private float moveVertical;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("VelocityX", playerRigidbody2D.velocity.x);
        playerAnimator.SetFloat("VelocityY", playerRigidbody2D.velocity.y);

        var movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidbody2D.AddForce(movement * moveForce * Time.deltaTime);
    }


}

