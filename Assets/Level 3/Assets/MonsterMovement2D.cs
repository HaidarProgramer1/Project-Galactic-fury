using UnityEngine;

public class MonsterMovement2D : MonoBehaviour
{
    public float speed = 2f;
    public float leftBound = -5f;  // Batas kiri gerakan
    public float rightBound = 5f;  // Batas kanan gerakan

    private Vector2 direction;

    void Start()
    {
        // Set arah gerakan awal
        direction = Vector2.right;
    }

    void Update()
    {
        // Monster bergerak berdasarkan kecepatan dan arah
        transform.Translate(direction * speed * Time.deltaTime);

        // Ubah arah jika mencapai batas
        if (transform.position.x >= rightBound)
        {
            direction = Vector2.left;
        }
        else if (transform.position.x <= leftBound)
        {
            direction = Vector2.right;
        }
    }

    void OnDrawGizmos()
    {
        // Gambar batas gerakan di editor
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(leftBound, transform.position.y, transform.position.z), new Vector3(rightBound, transform.position.y, transform.position.z));
    }
}
