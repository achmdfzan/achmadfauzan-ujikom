using UnityEngine;

public class PizzaController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private AudioSource eatAudio;
    private Rigidbody rb;

    private void Start()
    {
        eatAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            eatAudio.Play();
            other.GetComponent<AnimalController>().FeedAnimal();
        }

        if (!other.CompareTag("Player") && !other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
