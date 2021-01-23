using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class TextHit : MonoBehaviour
{
    public float LifeTime = 2f;
    public float elevationDistance = 2;
    public float initialVanishTime;
    private bool vanish;
    public TextMesh textMesh;
    public Color color;
    public string sortingLayer = "Text";
    // Start is called before the first frame update
    private float actualDistance = 0;
    private Vector3 movement = new Vector3(0, 0.1f);
    private float upAmount = 0.1f;
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = sortingLayer;
        textMesh = GetComponent<TextMesh>();
        movement = new Vector3(0, upAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (actualDistance < elevationDistance)
        {
            transform.localPosition += movement;
            actualDistance += upAmount;
            return;
        }
        if (!vanish)
        {
            vanish = true;
            StartCoroutine(Vanish());
        }
    }

    IEnumerator Vanish()
    {
        Color colorActual = textMesh.color;
        for (float alpha = 1; alpha > 0; alpha -= ((1 / LifeTime) * Time.deltaTime))
        {
            colorActual.a = alpha;
            textMesh.color = colorActual;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
