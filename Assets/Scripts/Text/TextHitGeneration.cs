using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHitGeneration : MonoBehaviour
{
    public TextHit localTextHit;
    public Range rangeXDefault = new Range();
    public Range rangeYDefault = new Range();

    public void CreateTextHit(TextHit textHit, string content, Transform parent,
        float size, Color color, Range rangeX, Range rangeY, float lifeTime)
    {

        Vector3 desfase = new Vector2(Random.Range(rangeX.min, rangeX.max), Random.Range(rangeY.min, rangeY.max));
        TextHit newTextHit = Instantiate(textHit, parent.position + desfase, Quaternion.identity, parent);
        newTextHit.LifeTime = lifeTime;
        newTextHit.textMesh.color = color;
        newTextHit.textMesh.characterSize = size;
        newTextHit.textMesh.text = content;

    }

    public void CreateTextHit(TextHit textHit, float content, Transform parent,
        float size, Color color, Range rangeX, Range rangeY, float lifeTime)
    {
        string stringContent = content.ToString();
        CreateTextHit(textHit, stringContent, parent, size, color, rangeX, rangeY, lifeTime);
    }

    public void CreateTextHit(TextHit textHit, string content, Transform parent,
        float size, Color color, float lifeTime)
    {
        CreateTextHit(textHit, content, parent, size, color, rangeXDefault, rangeYDefault, lifeTime);
    }

    public void CreateTextHit(TextHit textHit, float content, Transform parent,
        float size, Color color, float lifeTime)
    {
        string stringContent = content.ToString();
        CreateTextHit(textHit, stringContent, parent, size, color, rangeXDefault, rangeYDefault, lifeTime);
    }

    public void CreateTextHit(string content, Transform parent, float size, float lifeTime)
    {
        CreateTextHit(localTextHit, content, parent, size, localTextHit.color, rangeXDefault, rangeYDefault, lifeTime);
    }

}
