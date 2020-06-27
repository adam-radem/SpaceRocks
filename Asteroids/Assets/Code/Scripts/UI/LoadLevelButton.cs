using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
	[SerializeField] string levelName = default;

	public void LoadLevel()
	{
		SceneManager.LoadScene(levelName);
	}
}
