using UnityEngine;
namespace MyGame
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private Transform laserPoint;
        [SerializeField] private GameObject[] laser;
        [SerializeField] private AudioClip lasersound;


        private Animator anim;
        private PlayerMovement playerMovement;
        private float cooldownTimer = Mathf.Infinity;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return) && cooldownTimer > attackCooldown && playerMovement.canAttack())
                Attack();

            cooldownTimer += Time.deltaTime;
        }


        private void Attack()
        {
            SoundManager.instance.PlaySound(lasersound);
            anim.SetTrigger("attack");
            cooldownTimer = 0;

            int laserIndex = FindLaser();
            if (laserIndex != -1)
            {
                laser[laserIndex].transform.position = laserPoint.position;
                laser[laserIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
            }

        }

        private int FindLaser()
        {
            for (int i = 0; i < laser.Length; i++)
            {
                if (!laser[i].activeInHierarchy)
                {
                    return i;
                }
            }
            return -1; // No available laser found
        }
    }
}
