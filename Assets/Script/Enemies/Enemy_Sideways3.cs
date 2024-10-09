using UnityEngine;

public class Enemy_Sideways3 : MonoBehaviour
{
    [SerializeField] private float movementDistance = 5.0f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float activationDistance = 5.0f; // Jarak aktivasi
    private Transform player;
    private float topEdge;
    private bool isActivated = false;

    private void Awake()
    {
        // Tentukan batas atas gerakan
        topEdge = transform.position.y + movementDistance;
        // Cari pemain di dalam game (dengan asumsi tag pemain adalah "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Cek jarak antara pemain dan objek
        if (Vector3.Distance(transform.position, player.position) <= activationDistance)
        {
            isActivated = true;
        }

        // Jika diaktifkan, gerakkan ke atas
        if (isActivated && transform.position.y < topEdge)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika bertabrakan dengan objek yang memiliki tag "Player", berikan kerusakan
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
