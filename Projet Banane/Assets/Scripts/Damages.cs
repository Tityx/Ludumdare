using UnityEngine;
using System.Collections;

public class Damages : MonoBehaviour {

    string owner;
    int damages;
    int timer;
    bool damageTaken;

    void Start()
    {
        damageTaken = false;
    }

    public void setDamages(int _damages)
    {
        this.damages = _damages;
    }

    public void setOwner(string _owner)
    {
        this.owner = _owner;
    }

    // Update is called once per frame
    void Update ()
    {
        if(this.damages <= 10)
        {
            this.GetComponent<ParticleSystem>().startColor = Color.cyan;
        }
        else if(this.damages > 10 && this.damages <=15)
        {
            this.GetComponent<ParticleSystem>().startColor = Color.yellow;
        }
        else
        {
            this.GetComponent<ParticleSystem>().startColor = Color.red;
        }


        timer++;
        if(timer == 20)
        {
           Destroy(this.gameObject);
        }
	}


    void OnCollisionEnter(Collision collision)
    {
       
        
        Debug.Log("TOUCHE !");
        if (collision.gameObject.tag == "Fighter" && collision.gameObject.name != owner && !damageTaken)
        {
            if (this.damages < 15)
            {
                this.transform.Find("hit").GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                this.transform.Find("superHit").GetComponent<AudioSource>().enabled = true;
            }
            this.transform.GetComponent<BoxCollider>().enabled = false;
            damageTaken = true;
            collision.gameObject.GetComponent<Character>().takeDamages(this.damages);
        }
    }
}
