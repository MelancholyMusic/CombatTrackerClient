using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CTScene
{
	LOGIN = 0,
	CHARACTER_SELECT = 1,
}

public class LoadingManager : Singleton<LoadingManager>
{

	public void LoadScene(CTScene scene)
	{
		UIManager.Instance.Loading(true);
		SceneManager.LoadSceneAsync((int)scene);
	}
}
