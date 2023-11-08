using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputfield : MonoBehaviour {
	public Text playerName;////(1)
		public Text a;
		public static string aaa;
		//public InputField c;
		public static Text ss;
		void Update (){
				
				playerName.text=""+a.text;
				aaa = a.text;

		}
		public void level(){
		//Application.LoadLevelAsync ("UGUI");
		SceneManager.LoadScene("2");
		}





}