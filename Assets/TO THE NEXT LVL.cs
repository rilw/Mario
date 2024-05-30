using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TOTHENEXTLVL : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider collider)
    {
        if(collider.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene("lvl2");
        }
    }
}
