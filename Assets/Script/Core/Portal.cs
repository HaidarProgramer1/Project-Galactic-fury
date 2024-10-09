using UnityEngine;
using UnityEngine.SceneManagement; // Perlu ditambahkan untuk menggunakan SceneManager

public class Portal : MonoBehaviour
{
    [SerializeField] private string destinationScene; // Nama scene tujuan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Muat scene tujuan
            SceneManager.LoadScene(destinationScene);
        }
    }
}
