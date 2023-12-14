using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject pizzaProjectile;
    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private float moveSpeed = 5f;

    private float moveInput;

    private Animator anim;
    private bool canMove = true;
    private AudioSource throwAudio;
    private Rigidbody rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        throwAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!canMove) return;

        moveInput = Input.GetAxis("Horizontal");

        anim.SetFloat("Move", moveInput);

        if (Input.GetButtonDown("Fire"))
        {
            SpawnProjectile();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = rb.position + Vector3.right * (moveInput * moveSpeed *  Time.deltaTime);

        rb.MovePosition(movementVector);
    }

    private void SpawnProjectile()
    {
        anim.SetTrigger("Throw");
        Instantiate(pizzaProjectile, projectileSpawnPosition.position, pizzaProjectile.transform.rotation);
        throwAudio.Play();
    }
}
