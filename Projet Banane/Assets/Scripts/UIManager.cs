using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    private int livesJ1;
    private int livesJ2;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.livesJ1 = GameObject.Find("J1").transform.GetComponent<Character>().getLives();
        this.livesJ2 = GameObject.Find("J2").transform.GetComponent<Character>().getLives();


        transform.Find("Vies J1").GetComponent<RectTransform>().sizeDelta = new Vector2(this.livesJ1, 200);
        transform.Find("Vies J2").GetComponent<RectTransform>().sizeDelta = new Vector2(this.livesJ2, 200);

        if(this.livesJ2 <= 0 || this.livesJ1 <=0)
        {
            transform.Find("EndSong").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("J1").transform.GetComponent<ParticleSystem>().enableEmission = false;
            GameObject.Find("J2").transform.GetComponent<ParticleSystem>().enableEmission = false;
            GameObject.Find("J1").transform.GetComponent<AudioSource>().Stop();
            GameObject.Find("J2").transform.GetComponent<AudioSource>().Stop();
        }


    }
}
