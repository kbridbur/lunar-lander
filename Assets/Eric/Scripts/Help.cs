using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {

    public Text helpTextObject;
    public string helpText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter ()
    {
        helpTextObject.text = helpText;
    }

    void OnMouseExit ()
    {
        helpTextObject.text = "";
    }
}
