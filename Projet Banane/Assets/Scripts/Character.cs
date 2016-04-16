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
    private bool touched;
    protected bool activeBlock;
    protected bool dead;
    private Vector3 moveDirection;


    //Variables pour le squelette
    protected Transform hips;
    protected Transform leftUpLeg;
    protected Transform leftLeg;
    protected Transform rightUpLeg;
    protected Transform rightLeg;
    protected Transform spine;
    protected Transform head;
    protected Transform rightArm;
    protected Transform rightForeArm;
    protected Transform leftArm;
    protected Transform leftForeArm;
    protected Transform[] body;


    // Use this for initialization
    void Start ()
    {
        lives = 100;
        block = 1000;
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
        touched = false;
        activeBlock = false;
        dead = false;


        //Assignation du Ragdoll

       body = new Transform[11];
        hips = transform.Find("Armature").Find("Hips").transform;
        spine = transform.Find("Armature").Find("Hips").Find("Spine");
        body[0] = hips;
        leftUpLeg = hips.Find("LeftUpLeg");
        body[1] = leftUpLeg;
        leftLeg = leftUpLeg.Find("LeftLeg");
        body[2] = leftLeg;
        rightUpLeg = hips.Find("RightUpLeg");
        body[3] = rightUpLeg;
        rightLeg = rightUpLeg.Find("RightLeg");
        body[4] = rightLeg;
        body[5] = spine;
        head = spine.Find("Spine1").Find("Spine2").Find("Neck").Find("Head");
        body[6] = head;
        rightArm = spine.Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm");
        body[7] = rightArm;
        rightForeArm = rightArm.Find("RightForeArm");
        body[8] = rightForeArm;
        leftArm = spine.Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm");
        body[9] = leftArm;
        leftForeArm = leftArm.Find("LeftForeArm");
        body[10] = leftForeArm;

        //Desactivation du Ragdoll au début pour que le perso ne s'ecrase pas

        for (int i = 0; i < body.Length; i++)
        {
            body[i].GetComponent<Rigidbody>().mass = 400.0f;
            body[i].GetComponent<Rigidbody>().isKinematic = true;

        }

    }
	
	// Update is called once per frame
	void Update ()
    {

        moveDirection = new Vector3(0, 0, 0);
      

        if(!dead)
        {

            if (block < 100 && !isBlocking)
            {
                block = block + 1;
            }

            if (this.gameObject.name == "J1")
            {
                J1();
            }
            else
            {
                J2();
            }

            if (!isBlocking && !stunned && !run && !back && !hit && !loadingSuperHit && !superHit && !runHit && !BackHit && !touched && !activeBlock)
            {
                this.transform.GetComponent<Animation>().CrossFade("Iddle.001");
            }
            else
            {
                if (run && !BackHit && !runHit)
                {
                    this.transform.GetComponent<Animation>().CrossFade("Front");
                }
                if (back)
                {
                    this.transform.GetComponent<Animation>().CrossFade("Back");
                }
                if (isBlocking)
                {
                    this.block = block - 5;
                    this.transform.GetComponent<Animation>().CrossFade("Block");
                }
                if (stunned)
                {
                    goBack();
                    this.transform.GetComponent<Animation>().CrossFade("Stunned");
                }
                if (hit)
                {
                    switch (combo)
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
                if (loadingSuperHit)
                {
                    this.transform.GetComponent<Animation>().CrossFade("LoadSuperHit");
                }
                if (superHit)
                {
                    this.transform.GetComponent<Animation>().CrossFade("SuperHit");
                }
                if (touched)
                {
                    this.transform.GetComponent<Animation>().CrossFade("Touched");
                }
                if (stunned)
                {
                    this.transform.GetComponent<Animation>().CrossFade("Stunned");
                }
                if (activeBlock)
                {
                    isBlocking = false;
                    this.transform.GetComponent<Animation>().CrossFade("ActiveBlock");
                }

                if (runHit)
                {
                    this.transform.GetComponent<Animation>().CrossFade("RunHit");
                }

                if (BackHit)
                {
                    this.transform.GetComponent<Animation>().CrossFade("BackHit");
                }
            }

            moveDirection.y = -1;
            controller.Move(moveDirection);
        }
        else
        {
           // this.transform.GetComponent<Character>().enabled = false;
            this.transform.GetComponent<CharacterController>().enabled = false;
        }


	   
	}

    public void impact(int damages)
    {

        Transform spawnImpact;
        spawnImpact = transform.Find("ImpactZone");

                GameObject clone = Instantiate(Resources.Load("Prefabs/Impact"), spawnImpact.transform.position, spawnImpact.transform.rotation) as GameObject;
                clone.GetComponent<Damages>().setDamages(damages);
                clone.gameObject.GetComponent<Damages>().setOwner(this.gameObject.name);
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
            moveDirection.z = 0.1f;
            //this.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0.1f));
        }
        else
        {
            moveDirection.z = -0.1f;
            //this.GetComponent<CharacterController>().Move(new Vector3(0, 0, -0.1f));
        }
            
    }

    public void goFront()
    {
        run = true;
        if(this.gameObject.name == "J1")
        {
            moveDirection.z = -0.1f;
          // this.GetComponent<CharacterController>().Move(new Vector3(0, 0, -0.1f));
        }
        else
        {
            moveDirection.z = 0.1f;
           // this.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0.1f));
        }
        
    }

    public void strike()
    {

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

    public void allFalse()
    {
        
        run = false;
        back = false;
        hit = false;
        loadingSuperHit = false;
        superHit = false;
        runHit = false;
        BackHit = false;
        isBlocking = false;
        stunned = false;
        touched = false;
        activeBlock = false;

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

        if (Input.GetKey(KeyCode.Z) && block > 0)
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

        if (Input.GetKey(KeyCode.UpArrow) && block > 10)
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

    public void hardStun()
    {
        allFalse();
        stunned = true;
    }

    public void takeDamages(int damages)
    {
        allFalse();
        if(!isBlocking)
        {
            if (damages >= 15)
            {
                hardStun();
            }
            else
            {
                touched = true;
            }
            
            this.lives = lives - damages;

            if(this.lives <= 0)
            {
                this.lives = 0;
                die();
            }
        }
        else
        {
            this.block = block - damages;
            if (damages >= 15)
            {
                hardStun();
            }
            else
            {
                isBlocking = false;
                activeBlock = true;
            }
            
        }
    }

    public void die()
    {
        
        this.transform.GetComponent<Animation>().enabled = false;
        //   this.GetComponent<CharacterController>().enabled = false;
        dead = true;

        for (int i = 0; i < body.Length - 1; i++)
        {

            body[i].GetComponent<Rigidbody>().isKinematic = false;
            body[i].GetComponent<Rigidbody>().useGravity = true;
          /*  if (body[i].GetComponent<CharacterJoint>() != null)
            {

                body[i].GetComponent<CharacterJoint>().gameObject.SetActive(true);
            }*/
        }
    }
}
