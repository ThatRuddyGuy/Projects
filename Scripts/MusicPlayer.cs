using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;


    void Awake()
    {
        Debug.Log("Music Player Awake " + GetInstanceID());

        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate deleted: " + GetInstanceID());
        }
        else
        {
            instance = this;
        }

    }

	// Use this for initialization
	void Start () {
        Debug.Log("Music Player Start " + GetInstanceID());

        
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
