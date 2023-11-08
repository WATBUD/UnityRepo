using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class butonclick : MonoBehaviour {
	public Text loadText;
	public Image loadImage;
	public GameObject loadScreen;
	public string loadscene;
	void Start(){
		//loadScreen.transform.localScale = new Vector3 (1, 1, 1);////(1)
		StartCoroutine (DisplayLoadingScreen(loadscene));////(2)

	}
	void Update(){


	}
	IEnumerator DisplayLoadingScreen (string level){////(1)
		AsyncOperation async = SceneManager.LoadSceneAsync(level);
		while (!async.isDone) {////(3)
			loadText.text = (async.progress * 100).ToString() + "%";////(4)
			//loadImage.transform.localScale = new Vector2(async.progress,loadImage.transform.localScale.y);
			yield return null;
		}
	}

}
