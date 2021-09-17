using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    public float speed = 5.0f;

    public enum DriftDirection
    {
        LEFT = -1,
        RIGHT=1
    }
    public DriftDirection driftDirection = DriftDirection.LEFT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < -80 || transform.position.x >80)
        {
            Destroy(gameObject);
        }
                transform.Translate(Vector3.left * Time.deltaTime * speed * (float)driftDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject child = collision.gameObject;
            child.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        GameObject child = collision.gameObject;
        child.transform.SetParent(null);
    }
}
