using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float damageInterval = 1f; // Interval waktu untuk damage berkelanjutan
    private bool isDamaging = false;

    // Detect when the player first touches the collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDamaging)
        {
            StartCoroutine(DealContinuousDamage(collision.gameObject));
        }
    }

    // Detect when the player leaves the collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(DealContinuousDamage(collision.gameObject));
            isDamaging = false;
        }
    }

    // Coroutine for dealing continuous damage
    private IEnumerator DealContinuousDamage(GameObject player)
    {
        isDamaging = true;
        Health playerHealth = player.GetComponent<Health>();

        while (isDamaging)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
