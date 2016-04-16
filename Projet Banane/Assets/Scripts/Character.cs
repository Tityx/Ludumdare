using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private int lives;
    private int block;
    private bool isBlocking;
    private int combo;
    private bool stunned;
    private bool run;
    private bool back;
    private int level;
    private bool hit;
    private CharacterController controller;
    private bool loadingSuperHit;
    private bool canHit;
    private bool superHit;
    private bool runHit;
    private bool BackHit;


    // Use this for initialization
    void Start ()
    {
        lives = 100;
        block = 100;
        isBlocking = false;
        combo = 0;
        stunned = false;
        run = false;
        back = false;
        hit = false;
        loadingSuperHit = false;
        level = 1;
        controller = transform.GetComponent<CharacterController>();
        canHit = true;
        superHit = false;
        runHit = false;
        BackHit = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(this.gameObject.name == "J1")
        {
            J1();
        }
        else
        {
            J2();
        }

        

	    if(!isBlocking && !stunned && !run && !back &&!hit &&!loadingSuperHit &&!superHit &&!runHit && !BackHit)
        {
            this.transform.GetComponent<Animation>().CrossFade("Iddle.001");
        }
        else
        {
            if (run &&!BackHit &&!runHit)
            {
                this.transform.GetComponent<Animation>().CrossFade("Front");
            }
            if(back)
            {
                this.transform.GetComponent<Animation>().CrossFade("Back");
            }
            if(isBlocking)
            {
                this.transform.GetComponent<Animation>().CrossFade("Block");
            }
            if(stunned)
            {
                this.transform.GetComponent<Animation>().CrossFade("Stunned");
            }
            if(hit)
            {
                switch(combo)
                {
                    case 1:
                        this.transform.GetComponent<Animation>().CrossFade("Hit1");
                        break;
                    case 2:
                        this.transform.GetComponent<Animation>().CrossFade("Hit2");
                        break;
                    case 3:
                        this.transform.GetComponent<Animation>().CrossFade("Hit3");
                        break;
                    case 4:
                        this.transform.GetComponent<Animation>().CrossFade("Hit4");
                        break;
                    default:
                        break;
                }
            }
            if(loadingSuperHit)
            {
                this.transform.GetComponent<Animation>().CrossFade("LoadSuperHit");
            }
            if (superHit)
            {
                this.transform.GetComponent<Animation>().CrossFade("SuperHit");
            }


            if(runHit)
            {
                this.transform.GetComponent<Animation>().CrossFade("RunHit");
            }

            if(BackHit)
            {
                this.transform.GetComponent<Animation>().CrossFade("BackHit");
            }
        }
	}

    public void nextCombo()
    {
        canHit = true;
    }

    public void endCombo()
    {
        combo = 0;
        hit = false;
        canHit = true;
    }

    public void endSuperHit()
    {
        superHit = false;
        loadingSuperHit = false;
    }

    public void endMoveHit()
    {
        BackHit = false;
        runHit = false;
    }

    public void goBack()
    {
        back = true;
        if (this.gameObject.name == "J1")
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0.1f));
        }
        else
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, -0.1f));
        }
            
    }

    public void goFront()
    {
        run = true;
        if(this.gameObject.name == "J1")
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, -0.1f));
        }
        else
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0.1f));
        }
        
    }

    public void strike()
    {

        Debug.Log("Attack" + this.gameObject.name);

        if (run)
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, -0.75f));
            runHit = true;
        }
        else
        {
            runHit = false;
        }

        if (back)
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0.75f));
            BackHit = true;
        }
        else
        {
            BackHit = false;
        }

        if (!run)
        {
            combo++;
            hit = true;
            canHit = false;
        }
    }

    public void J1()
    {

        this.transform.LookAt(GameObject.Find("J2").transform);


        if(Input.GetKey(KeyCode.A) && !isBlocking)
        {
            goBack();
        }
        else
        {
            back = false;
        }

        if (Input.GetKey(KeyCode.E) && !isBlocking)
        {
            goFront();
        }
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }
        if (Input.GetKeyDown(KeyCode.T) && combo <=4 && canHit)
        {
            strike();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            loadingSuperHit = true;
        }
        else
        {
            if(loadingSuperHit)
            {
                superHit = true;
            }
            loadingSuperHit = false;
        }

        
        
    }

    public void J2()
    {

        this.transform.LookAt(GameObject.Find("J1").transform);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            goBack();
        }
        else
        {
            back = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            goFront();
        }
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            strike();
        }

        if (Input.GetKey(KeyCode.I))
        {
            loadingSuperHit = true;
        }
        else
        {
            if (loadingSuperHit)
            {
                superHit = true;
            }
            loadingSuperHit = false;
        }
            
        
    }

    public void attack()
    {

    }

    public void loadSuperAttack()
    {

    }

    public void move()
    {

    }

    public void die()
    {

    }
}
