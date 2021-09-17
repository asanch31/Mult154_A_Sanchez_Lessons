using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPoint = null;
    private Dictionary<Item.VegetableType, int> ItemInvetory = new Dictionary<Item.VegetableType, int>();

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>(); 
        foreach(Item.VegetableType item in System.Enum.GetValues(typeof(Item.VegetableType)))
        {
            ItemInvetory.Add(item, 0);
        }
    }

    private void AddToInventory(Item item)
    {
        ItemInvetory[item.typeOfVeggie]++;
    }


    private void PrintInventory()
    {
        string output = "";
        foreach (KeyValuePair<Item.VegetableType, int> kvp in ItemInvetory)
        {
            output += string.Format("{0}: {1} ", kvp.Key, kvp.Value);
        }
        print(output);
    }
    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, vertMove);
    }


    private void FixedUpdate()
    {
        rbPlayer.AddForce(direction * speed, ForceMode.Force);
        if (transform.position.z >40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 40);
        }
        else if (transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
    }

    private void Respawn()
    {
        rbPlayer.MovePosition(spawnPoint.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.gameObject.GetComponent<Item>();
            AddToInventory(item);
            PrintInventory();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
   

}
