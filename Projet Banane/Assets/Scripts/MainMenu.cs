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
        transform.Find("Logo").gameObject.SetActive(true);
        transform.Find("Instructions").gameObject.SetActive(true);
    }

    public void showInstructions()
    {
        transform.Find("Logo").gameObject.SetActive(false);
        transform.Find("infos").gameObject.SetActive(true);
        transform.Find("Instructions").gameObject.SetActive(false);
    }

    public void launchGame()
    {
        Application.LoadLevel("tests Titix");
    }


}
