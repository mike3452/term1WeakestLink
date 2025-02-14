using UnityEngine;

public class Target : MonoBehaviour
{
    public int HP;

    void Start()
    {
        // Initialize target with a random position
        transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}