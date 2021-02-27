using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

	void Start()
	{
		
	}

	


    public void LoadNextlevel(int indexLevel)
	{
        StartCoroutine(LoadLevel(indexLevel));
	}


    IEnumerator LoadLevel(int levelIndex)
	{
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
