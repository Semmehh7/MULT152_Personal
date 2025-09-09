using UnityEngine;

public class DamageOnKey : MonoBehaviour
{
    [SerializeField] private HealthComponent target;
    [SerializeField] private int damageAmount = 10;
    //[SerializeField] private KeyCode key = KeyCode.K;
    [SerializeField] private Key key = Key.K;
}

    void Update()
    {

        //if (Input.GetKeyDown(key)) target?.Damage(damageAmount);

        if (Keyboard.current[key].wasPressedThisFrame)

        {
            target?.Damage(damageAmount);
        }
    }
}