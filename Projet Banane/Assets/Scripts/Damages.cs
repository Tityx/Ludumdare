using UnityEngine;
using System.Collections;

public class Damages : MonoBehaviour {

    string owner;
    int damages;
    int timer;

	// Use this for initialization
	void Start ()
    {
	    
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
        timer++;
        if(timer == 10)
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Fighter" && collision.gameObject.name != owner)
        {
            collision.gameObject.GetComponent<Character>().takeDamages(this.damages);
        }
    }
}
