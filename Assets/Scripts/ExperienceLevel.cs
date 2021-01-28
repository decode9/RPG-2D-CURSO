using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(TextHitGeneration))]
public class ExperienceLevel : MonoBehaviour
{

    public AttributeButton[] attributeButtons;
    public Image experienceBar;

    private TextHitGeneration textHitGeneration;
    private Range rangeTextLevelUp = new Range() { min = 0, max = 0 };

    private int actualExp;
    private int nextLevelExp;
    public int level { get; private set; }
    private float motiveActualLevelExp;
    public int attributesPoints { get; private set; }
    public int experience
    {
        get
        {
            return actualExp;
        }
        set
        {
            actualExp += value;
            if (level > 1)
            {
                motiveActualLevelExp = (float)(experience - AcumulativeExperienceCurve(level)) / nextLevelExp;
                checkLevel();
            }
            else
            {
                motiveActualLevelExp = (float)(actualExp) / nextLevelExp;
                checkLevel();
            }
        }
    }

    private Attributes playerAttributes;
    private Health health;

    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
        textHitGeneration = GetComponent<TextHitGeneration>();
        playerAttributes = GetComponent<PlayerController>().playerAttributes;
        health = GetComponent<Health>();
        nextLevelExp = ExperienceCurve(level);
        UpdateExperienceBar();
    }

    private void checkLevel()
    {
        while (motiveActualLevelExp >= 1)
        {
            LevelUp();
        }
        AttributePanel.instance.UpdateTextAttributes(playerAttributes, health, this);
        UpdateExperienceBar();
    }

    private int ExperienceCurve(int level)
    {
        float experienceFunction = Mathf.Log(level, 3f) + 20;
        int exp = Mathf.CeilToInt(experienceFunction);
        return exp;
    }

    private int AcumulativeExperienceCurve(int level)
    {
        int exp = 0;
        for (int i = 1; i < level; i++)
        {
            exp += ExperienceCurve(i);
        }
        return exp;
    }

    private void LevelUp()
    {
        level++;
        NextLevelConfiguration();
        textHitGeneration.CreateTextHit(textHitGeneration.localTextHit, "Level Up!", transform, 0.4f, Color.green, rangeTextLevelUp, rangeTextLevelUp, 2f);
        motiveActualLevelExp = (float)(experience - AcumulativeExperienceCurve(level)) / nextLevelExp;
    }

    void NextLevelConfiguration()
    {
        attributesPoints += 2;
        nextLevelExp = ExperienceCurve(level);
        checkButtons();
    }

    void UpdateExperienceBar()
    {
        experienceBar.fillAmount = motiveActualLevelExp;
    }

    public void ReduceAttributesPoints()
    {
        attributesPoints--;
        checkButtons();
    }

    private void checkButtons()
    {
        AttributePanel.instance.UpdateTextAttributes(playerAttributes, health, this);
        foreach (AttributeButton button in attributeButtons)
        {
            button.ActiveDesactiveButton(attributesPoints);
        }
    }
}
