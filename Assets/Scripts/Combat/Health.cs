using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int healthBase;
    public int myHealth { get { return healthBase + healthModificator; } }
    private int actualHealth;
    public Image healthBar;
    public int healthModificator;
    public UnityEvent OnDie;
    public int healthProperty
    {
        get
        {
            return actualHealth;
        }
        set
        {
            if (value >= 0 && value <= myHealth) actualHealth = value;
            if (value <= 0) OnDie.Invoke();
            if (value > myHealth) actualHealth = myHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthProperty = healthBase;
    }

    public void modifyHealth(int amount)
    {
        healthProperty += amount;
        UpdateHealthBar();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void UpdateHealthBar()
    {
        if (healthBar) healthBar.fillAmount = (float) actualHealth / myHealth;
    }

    public void ModifyBaseHealth(int amount)
    {
        healthBase += amount;
        UpdateHealthBar();
    }
}
