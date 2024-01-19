using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    public Transform PlayerPosition;
    public float X, Y;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }
    private void Awake()
    {
        X = transform.position.x;
        Y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        X = PlayerPosition.position.x;
        Y = PlayerPosition.position.y;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Save [X]", X);
        PlayerPrefs.SetFloat("Save [Y]", Y);
    }
    private void Load()
    {
        if(PlayerPrefs.HasKey("Save [X]"))
        {
            X = PlayerPrefs.GetFloat("Save [X]");
        }
        if (PlayerPrefs.HasKey("Save [Y]"))
        {
            X = PlayerPrefs.GetFloat("Save [Y]");
        }
        PlayerPosition.transform.position = new Vector3(X, Y);


    }
}
