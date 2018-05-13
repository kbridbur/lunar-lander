using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour {

	void Start(){
		WinText.SetActive (false);
		LoseText.SetActive (false);
	}

	void WinGame(){
		WinText.SetActive (true);
		Time.timeScale = 0;
	}

	void LoseGame(){
		LoseText.SetActive (true);
		Time.timeScale = 0;
	}

	void SetLevel(int l){
		level = l;
	}

	public GameObject Lander;
	public GameObject GameManager;
	public int level = 1;
	public GameObject WinText;
	public GameObject LoseText;
}
