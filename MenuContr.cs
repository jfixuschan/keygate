using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    public void Perehod()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
