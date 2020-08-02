using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject mysterio;
    public Animator m_animator;
    
    private void Start()
    {
        //Rotates player to face forward
        transform.Rotate(-90.0f, 180.0f, 0.0f);
        m_animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        m_animator.SetTrigger("flying");
        
        //Moves enemy up the screen
        transform.Translate(Vector3.forward * Time.deltaTime * 0.8f);

        if (transform.position.y >= 2)
        {
            Destroy(mysterio);
        }

    }
}
