using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UpdateManager : MonoBehaviour {

    private static UpdateManager instance;
    public static UpdateManager Instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject (typeof(UpdateManager).ToString());
                instance = go.AddComponent<UpdateManager> ();

                instance.actions = new List<Action> ();
                instance.count = 0;
            }
            return instance;
        }
    }

    private List<Action> actions;
    private int count;

    void Update() {
        for (int i = 0; i < count; i++) {
            actions [i] ();
        }
    }

    public void Add(Action action) {
        actions.Add (action);
        count = actions.Count;
    }

}

public static class UpdateManagerExtension {

    public static void StartUpdate(this object obj, Action action) {
        UpdateManager.Instance.Add (action);
    }

}
