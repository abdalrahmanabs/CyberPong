using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    
    Vector3 direction; public Vector2 startingPos;
    Rigidbody rb;
    private bool stopped=true;
    public float minDirection=0.5f;
    Material _ballMaterial;

    
    void Start()
    {
        _ballMaterial=GetComponent<Material>();
        startingPos=transform.position;
        rb = GetComponent<Rigidbody>();
        Stop();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(stopped)return;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime) ;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                direction.z = -direction.z;
                break;
            case "Racket":
                Vector3 newDirection = (transform.position - other.transform.position).normalized;
                newDirection.x = Mathf.Sign(newDirection.x)*Mathf.Max(Mathf.Abs(newDirection.x),minDirection);
                newDirection.z = Mathf.Sign(newDirection.z)*Mathf.Max(Mathf.Abs(newDirection.z),minDirection);
                direction=newDirection;
                _ballMaterial.SetColor("_EmissionColor", other.gameObject.GetComponent<Material>().GetColor("_EmissionColor"));
                break;
        }
    }

    private void RandomStartDirection()
    {
        float signx= Mathf.Sign(Random.Range(-1f,1f));
        float signz= Mathf.Sign(Random.Range(-1f,1f));
        direction=new Vector3(0.5f*signx,0,0.5f*signz);

    }
    public void Stop(){stopped=true;}


    public void Go(){
        stopped=false;
        RandomStartDirection();
        }
}
