using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody2D rigid;
    float velocitym = 10f;
    public bool tocandoelsuelo;
    public float radius = 1.8f;
    public Transform objeto;
    float forcej = 1000f;
    public LayerMask Mask;
    Animator anim;
    SpriteRenderer spriteRenderer;
    float valuem;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid;
        rigid = GetComponent<Rigidbody2D>();


        tocandoelsuelo = Physics2D.OverlapCircle(objeto.position, radius, Mask);

        valuem = Input.GetAxis("Horizontal");
        anim.SetBool("Semueve", valuem != 0 ? true:false);

        anim.SetBool("Tocaelpiso", tocandoelsuelo);

        rigid.velocity = new Vector2(valuem * velocitym, rigid.velocity.y);
        //transform.Translate(new Vector3(valuem * velocitym, 0, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && tocandoelsuelo)
        {
            rigid.AddForce(new Vector3(0, forcej, 0));
        }

        anim.SetFloat("Subidaobajada", rigid.velocity.y);

        voltea();
    }

    private void voltea()
    {
        if (valuem > 0 && spriteRenderer.flipX == true || valuem < 0 && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(objeto.position, radius);
    }
}
