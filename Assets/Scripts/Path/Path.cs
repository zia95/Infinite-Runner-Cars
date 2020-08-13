using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public string playerTag = "player";
    public Vector3 pathSpacing = new Vector3(0, 0, 100f);
    public GameObject nextPathPrefab;
    public GameObject LastPathTile { get; set; }
    //public Vector3 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(this.playerTag))
        {
            //Debug.Log($"entered new tile. spacing: {this.gameObject.transform.position }");

            var obj = Instantiate(this.nextPathPrefab, this.gameObject.transform.position + pathSpacing, new Quaternion(0, 0, 0, 0)) as GameObject;
            obj.transform.Rotate(-90, 0, 0);
            
            obj.GetComponent<Path>().LastPathTile = this.gameObject;

            if(this.LastPathTile != null)
                Destroy(this.LastPathTile.gameObject, 0f);
        }
    }
}
