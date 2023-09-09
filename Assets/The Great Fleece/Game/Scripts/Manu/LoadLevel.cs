using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //reference progress bar
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync()); //call corotine to lofd the main scene
    }

IEnumerator LoadLevelAsync()
    {
        yield return null;
        //create an async operation = loadSceenAsync("Main")
        AsyncOperation operation = SceneManager.LoadSceneAsync("LoadingScreen");

       //while operation isn't finished
       while (operation.isDone == false)
        {
            progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
       //progress bar fill amount == operation progress
       //yield waitforendoffframe
    }
}
