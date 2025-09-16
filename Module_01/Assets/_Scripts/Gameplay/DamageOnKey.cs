using UnityEngine;
using UnityEngine.InputSystem;

public class DamageOnKey : MonoBehaviour
{
    [SerializeField] private HealthComponent target;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private Key key = Key.K;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Keyboard.current[key].wasPressedThisFrame)

        {
            target?.Damage(damageAmount);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}