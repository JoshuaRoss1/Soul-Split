using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene("PrototypeLevel1");
        }
    }
}
