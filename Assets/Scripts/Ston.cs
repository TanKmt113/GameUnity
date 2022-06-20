using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ston : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    bool m_idGround;

    public bool IsGround { get => m_idGround ;}


    private void Awake(){
        m_rb =GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate (){

        if(m_rb){
            m_rb.velocity= Vector3.down * moveSpeed ;
        }

    }
    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player"))
        {
         
                m_idGround = true;
                Destroy(gameObject, 0.03f);

            AudioController.Ins.PlaySound(AudioController.Ins.landSound);

        }
    }



}
