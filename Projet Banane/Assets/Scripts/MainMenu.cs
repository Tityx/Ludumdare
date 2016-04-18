using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	

    void Start()
    {
        hideInstructions();
    }

    public void hideInstructions()
    {
        transform.Find("infos").gameObject.SetActive(false);
    }

    public void showInstructions()
    {
        transform.Find("infos").gameObject.SetActive(true);
    }

    public void launchGame()
    {
        Application.LoadLevel("tests Titix");
    }


}
