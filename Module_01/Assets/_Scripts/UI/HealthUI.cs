using UnityEngine;
using UnityEngine.UI; // for Slider
#if TMP_PRESENT
using TMPro;
#endif

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private HealthComponent target;
    [SerializeField] private Slider bar;

    [Header("TEXT Fields")]
    [SerializeField] private UnityEngine.UI.Text legacyLabel;
    [SerializeField] private UnityEngine.UI.Text playerLabel;
#if TMP_PRESENT
    [SerializeField] private TextMeshProUGUI tmpLabel;
#endif

    void Start()
    {
        if (!player)
        {
            player = GetComponentInParent<CharacterController>()?.gameObject;
        }

        if (player && playerLabel)
            {
                playerLabel.text = player.name;
                Debug.Log($"[HealthUI] Player name set to: {player.name}");
            }
    }

    private void OnEnable()
    {
        if (target == null) return;
        target.OnHealthChanged += HandleChanged;
    }

    private void OnDisable()
    {
        if (target == null) return;
        target.OnHealthChanged -= HandleChanged;
    }

    private void HandleChanged(int current, int max)
    {
        if (bar != null) { bar.minValue = 0; bar.maxValue = max; bar.value = current; }
        if (legacyLabel != null) legacyLabel.text = $"{current}/{max}";
#if TMP_PRESENT
        if (tmpLabel != null) tmpLabel.text = $"{current}/{max}";
#endif
    }
}