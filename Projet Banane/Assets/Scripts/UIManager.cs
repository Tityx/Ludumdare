using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private int livesJ1;
    private int livesJ2;
    private bool fighting;
    private string winner;

	// Use this for initialization
	void Start ()
    {
        transform.Find("GameOver").gameObject.SetActive(false);
        fighting = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(fighting)
        {
            this.livesJ1 = GameObject.Find("J1").transform.GetComponent<Character>().getLives();
            this.livesJ2 = GameObject.Find("J2").transform.GetComponent<Character>().getLives();


            if(livesJ1 <= 0 || livesJ2 <=0)
            {
                if(livesJ1 < livesJ2)
                {
                    this.winner = "Le Ninja";
                }
                else
                {
                    this.winner = "Le Shaolin";
                }


                gameOver();
            }

            transform.Find("Vies J1").GetComponent<RectTransform>().sizeDelta = new Vector2(this.livesJ1, 200);
            transform.Find("Vies J2").GetComponent<RectTransform>().sizeDelta = new Vector2(this.livesJ2, 200);

            if (this.livesJ2 <= 0 || this.livesJ1 <= 0)
            {
                transform.Find("EndSong").GetComponent<AudioSource>().enabled = true;
                GameObject.Find("J1").transform.GetComponent<ParticleSystem>().enableEmission = false;
                GameObject.Find("J2").transform.GetComponent<ParticleSystem>().enableEmission = false;
                GameObject.Find("J1").transform.GetComponent<AudioSource>().Stop();
                GameObject.Find("J2").transform.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public void gameOver()
    {
        fighting = false;
        transform.Find("Vies J1").gameObject.SetActive(false);
        transform.Find("Vies J2").gameObject.SetActive(false);
        StartCoroutine(waitAndDisplay());
    }

    public void quit()
    {
        Application.Quit();
    }

    public void rematch()
    {
        Application.LoadLevel("tests Titix");
        
    }

    public void retourMenu()
    {
        Application.LoadLevel("Menu Principal");
    }

    IEnumerator waitAndDisplay()
    {
        yield return new WaitForSeconds(3.5f);
        transform.Find("GameOver").gameObject.SetActive(true);
        transform.Find("GameOver").FindChild("Vainqueur").GetComponent<Text>().text = winner + " remporte le combat !";     

    }


    
}
