using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Leeten Main Scene");
    }

    public static void LoadGameOver()
    {
        Repository.RefreshRepository();
        SceneManager.LoadScene("GameOver");
    }
}
