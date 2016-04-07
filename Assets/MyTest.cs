using UnityEngine;
using System.Collections;

public class MyTest : MonoBehaviour {
    public Renderer myRenderer;
    public float colorSpeed;
    public float colorCycle;

    private MaterialPropertyBlock properties;
    private Color tgtColor;
    private Color curColor;

    IEnumerator Start() {
        properties = new MaterialPropertyBlock ();
        yield return null;

        this.StartUpdate (MyUpdate);

        while (true) {
            tgtColor = new Color (Random.value, Random.value, Random.value);
            yield return new WaitForSeconds (colorCycle);
        }
    }

    private void MyUpdate() {
        curColor = Color.Lerp (curColor, tgtColor, Time.deltaTime * colorSpeed);

        properties.ApplyColor ("_Color", curColor);

        myRenderer.SetPropertyBlock (properties);
    }

}
