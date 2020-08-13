using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpsticleSpawner : MonoBehaviour
{
    public Object[] spawnOpsticles;
    public float spawnDistance = 100f;
    public float leftPos = -2f;
    public float centerPos = 0f;
    public float rightPos = 2f;

    public float spawnDelayInSec = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnOpsticle", this.spawnDelayInSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void SpawnOpsticle()
    {
        int max_ops_spawn = Random.Range(0f, 1f) > 0.6 ? 2 : 1;


        var spawnPos = new List<float>();
        spawnPos.Add(this.leftPos);
        spawnPos.Add(this.centerPos);
        spawnPos.Add(this.rightPos);

        for (int i = 0; i < max_ops_spawn; i++)
        {
            int spwnObjIdx = Random.Range(0, (this.spawnOpsticles.Length - 1));
            var obj = this.spawnOpsticles[spwnObjIdx];

            int spwnPosIdx = Random.Range(0, (spawnPos.Count));
            var pos = spawnPos[spwnPosIdx];
            spawnPos.RemoveAt(spwnPosIdx);



            var sobj = Instantiate(obj, new Vector3(pos, 0, this.transform.position.z + this.spawnDistance), new Quaternion(0, 180f, 0, 0)) as GameObject;

            sobj.GetComponent<OpsticleVehicle>().Spawner = this;
        }





        Invoke("SpawnOpsticle", this.spawnDelayInSec);
    }
}
