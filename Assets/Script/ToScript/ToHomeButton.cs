using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHomeButton : MonoBehaviour
{
         public void OnClick() {
    Debug.Log("Button click!");
    SceneManager.LoadScene("Home");
         }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
