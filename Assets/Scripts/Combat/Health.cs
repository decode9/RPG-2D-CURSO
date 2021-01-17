using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public int initialHealth;
    private int actualHealth;
    public UnityEvent OnDie;
    public int healthProperty {get {
        return actualHealth;
    } set{
        if(value >= 0 && value <= initialHealth) actualHealth = value;
        if(value <= 0) OnDie.Invoke();
        if(value > initialHealth) actualHealth = initialHealth;        
    }}
    // Start is called before the first frame update
    void Start()
    {
        healthProperty = initialHealth;
    }
    public void modifyHealth(int amount){
        healthProperty += amount;
    }

    private void DestroyGameObject(){
        Destroy(gameObject);
    }
}
