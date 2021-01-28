using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite openCofre;
    public Sprite closeCofre;
    private bool open;

    private Image image;

    private void Start() {
        image = GetComponent<Image>();
    }

    public void SwitchCofre()
    {
        open = (!open);
        image.sprite = (open) ? openCofre : closeCofre;
    }
}
