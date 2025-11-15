using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Character targetCharacter;

    void Update()
    {
        if (targetCharacter != null)
        {
            slider.value = (float)targetCharacter.currentHealth / targetCharacter.maxHealth;
        }
    }
}
