using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D Rg2d;
    public float jump_force;
    public float speed;
    private bool can_jump;
    public int Life = 100;
    private int multiply;
    private Animator anim;
    private float TTD;
    public GameObject weapon;
    public BoxCollider2D col;
    public LayerMask LM;
    public GameObject Gun;
    public GameObject Scar;
    void Start()
    {
        //col = gameObject.GetComponent<BoxCollider2D>();
        TTD = 3;
        //Cursor.visible = false;
        Rg2d = this.gameObject.GetComponentInChildren<Rigidbody2D>();
        can_jump = false;
        multiply = 1;
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            anim.SetBool("died", true);
            PhotonNetwork.Destroy(weapon);
            if ((TTD -= Time.deltaTime) <= 0)
            {
                PhotonNetwork.Disconnect();
                SceneManager.LoadScene("Dead");
                SceneManager.UnloadScene(SceneManager.GetActiveScene());
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
        else
        {
            /*if(Camera.main.transform.position.x>-30 && Camera.main.transform.position.y>=-3.6f)
                Camera.main.transform.position = new Vector3(transform.position.x, 0, 0);
            else
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 3.595003f, 0);*/

            if (transform.position.y > 4.7f || transform.position.y < -3.8f)
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
            else
                Camera.main.transform.position = new Vector3(transform.position.x, 0, 0);

            if (can_jump == false)
                anim.SetInteger("speed", 0);

            /*if (transform.position.x < -11.2)
                Rg2d.AddForce(new Vector3(1,0,0));

            if(transform.position.x > 11.15f)
                Rg2d.AddForce(new Vector3(-1, 0, 0));*/

            if (Input.GetKeyDown(KeyCode.Escape))
                Cursor.visible = true;

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("speed", -1);
                this.transform.Translate(-speed, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("speed", 1);
                this.transform.Translate(speed, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space) && can_jump)
            {
                can_jump = false;
                Rg2d.AddForce(Vector3.up * jump_force);
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Space))
                anim.SetInteger("speed", 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
            can_jump = true;
        if (collision.gameObject.tag == "Can'tJump")
            can_jump = false;

        if (collision.gameObject.tag == "Projectile")
        {
            Life -= collision.gameObject.GetComponent<forwoard>().damage;
            PhotonNetwork.Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Upgrade")
        {
            Scar.active = true;
            Gun.active = false;
            PhotonNetwork.Destroy(collision.gameObject);
            //gameObject.GetComponentInChildren<Shoot>().projectile = "ProjectileAdvanced";

        }

        if (collision.gameObject.tag == "HealUpgrade")
        {
            PhotonNetwork.Destroy(collision.gameObject);
            Life += 25;

        }

        if (collision.gameObject.tag == "JumpUpgrade")
        {
            PhotonNetwork.Destroy(collision.gameObject);
            jump_force += 50;

        }

        if (collision.gameObject.tag == "SpeedUpgrade")
        {
            PhotonNetwork.Destroy(collision.gameObject);
            speed += 0.001f;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Platform")
            can_jump = false;*/
    }
	
	private bool IsGrounded()
    {
        return Physics.CheckBox(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), quaternion.Euler(0,0,0), LM);
    }
}
