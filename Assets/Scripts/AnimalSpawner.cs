using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] animals;
    [SerializeField] private float spawningRange = 8f;
    [SerializeField] private float spawningCooldown = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnAnimal", spawningCooldown * 0.5f, spawningCooldown);
    }

    private void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, animals.Length);
        float randomXPostion = Random.Range(-spawningRange, spawningRange);

        Instantiate(animals[randomAnimal], new Vector3(randomXPostion, 0, transform.position.z), animals[randomAnimal].transform.rotation);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}
