using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuPanel : MonoBehaviour
{
    public static MenuPanel instance { get; private set; }
    private CanvasGroup canvasGroup;
    private bool open = false;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OpenClosePanels()
    {

        if (open)
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            open = false;
            Time.timeScale = 1;
            return;
        }
        open = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        Time.timeScale = 0;
    }
}
