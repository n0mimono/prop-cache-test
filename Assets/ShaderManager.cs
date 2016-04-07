using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShaderManager : MonoBehaviour {
    public bool useCache;
    public bool useConstant;

    private int idColor = 1;
    public  int IdColor {
        get {
            if (idColor < 0) idColor = Shader.PropertyToID ("_Color");
            return idColor;
        }
    }

    private static ShaderManager instance;
    public static ShaderManager Instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject (typeof(ShaderManager).ToString());
                instance = go.AddComponent<ShaderManager> ();

                instance.prop2id = new Dictionary<string, int> ();
            }
            return instance;
        }
    }

    private Dictionary<string,int> prop2id;

    public int PropertyToID(string name) {
        if (!prop2id.ContainsKey (name)) { 
            prop2id.Add (name, Shader.PropertyToID (name));
        }
        return prop2id [name];
    }

}

public static class ShaderManagerExtension {
    public static void ApplyColor(this MaterialPropertyBlock prop, string name, Color color) {
        if (ShaderManager.Instance.useCache) {
            prop.SetColor (ShaderManager.Instance.PropertyToID (name), color);
        } else if (ShaderManager.Instance.useConstant) {
            prop.SetColor (ShaderManager.Instance.IdColor, color);
        } else {
            prop.SetColor (name, color);
        }
    }
}
