using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    bool isJump;
    public int itemCount;
    Rigidbody rigid;
    AudioSource audio;
    public GameManagerLogic manager;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump) {
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }

    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.centerOfMass = new Vector3(0,-1f,0);
        isJump = false;
        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        audio = GetComponent<AudioSource>();

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        rigid.AddForce(new Vector3(h,0,v),ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "floor")
            isJump = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item"){
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "point"){
            if(itemCount == manager.totalItemCount) {
                //Game Clear! && Next Stage
                if (manager.stage == 2)
                    manager.ShowGameCleatText();
                else
                    SceneManager.LoadScene(manager.stage+1);
            }
            else {
                //Restart Stage
                SceneManager.LoadScene(manager.stage);
            }
        }
    }

    

}
