using UnityEngine;
using UnityEngine.UI;

public class Healthbarboss : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 12;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 12;
    }
}
