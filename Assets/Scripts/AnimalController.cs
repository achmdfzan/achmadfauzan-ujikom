using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private Image feedBarImage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int maxFeedAmount;
    [SerializeField] private int scoreGain;

    private AudioSource destroyAudio;
    private Rigidbody rb;
    private float feedAmount = 0f;

    private void Start()
    {
        destroyAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    public void FeedAnimal()
    {
        feedAmount++;
        feedBarImage.fillAmount = feedAmount / maxFeedAmount;

        if (feedAmount >= maxFeedAmount)
        {
            destroyAudio.Play();
            GameManager.Instance.AddScore(scoreGain);
            Destroy(gameObject);
        }
    }
}
