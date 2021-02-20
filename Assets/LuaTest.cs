using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuaTest : MonoBehaviour {

    Tutorial.CustomLoader loader;

    void Start () {
        GameObject.Find("Canvas/ButtonBinary").GetComponent<Button>().onClick.AddListener(OnBinaryButtonClick);
        GameObject.Find("Canvas/ButtonText").GetComponent<Button>().onClick.AddListener(OnTextButtonClick);

        loader = GameObject.Find("Main Camera").GetComponent<Tutorial.CustomLoader>();
    }
	
	void OnBinaryButtonClick ()
    {
        Debug.Log("do require('luac')");
        loader.luaenv.DoString("require('luac')");
	}

    void OnTextButtonClick()
    {
        Debug.Log("do require('Main')");
        loader.luaenv.DoString("require('Main')");
    }
}

