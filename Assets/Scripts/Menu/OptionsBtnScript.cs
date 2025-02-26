using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBtnScript : MonoBehaviour
{
    public void Options()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}
