using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ActiveDesactiveButton(int attributePoint)
    {
        gameObject.SetActive(attributePoint > 0);
    }
}
