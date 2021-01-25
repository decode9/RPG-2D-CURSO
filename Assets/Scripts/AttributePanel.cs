using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttributePanel : MonoBehaviour
{

    public static AttributePanel instance;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public TextMeshProUGUI txtLevel;
    public TextMeshProUGUI txtExp;
    public TextMeshProUGUI txtVelocity;
    public TextMeshProUGUI txtHealth;
    public TextMeshProUGUI txtAttack;
    public TextMeshProUGUI txtMagic;
    public TextMeshProUGUI txtAttributesPoints;

    public void UpdateTextAttributes(Attributes attribute, Health health, ExperienceLevel experienceLevel)
    {
        txtLevel.text = experienceLevel.level.ToString();
        txtExp.text = experienceLevel.experience.ToString();
        txtHealth.text = health.myHealth.ToString();
        txtAttack.text = attribute.ataque.ToString();
        txtVelocity.text = attribute.velocity.ToString();
        txtMagic.text = attribute.magic.ToString();
        txtAttributesPoints.text = experienceLevel.attributesPoints.ToString();
    }
}
