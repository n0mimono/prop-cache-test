using UnityEngine;
using System.Collections;

public class MyTestManager : MonoBehaviour {
    public GameObject origin;
    public int n;
    public float radius;

    void Start() {
        for (int i = 0; i < n; i++) {
            GameObject obj = GameObject.Instantiate (origin);
            obj.name = origin.name + " " + i;

            obj.transform.SetParent (transform);
            obj.transform.position = Random.insideUnitSphere * radius;
        }
    }

}
