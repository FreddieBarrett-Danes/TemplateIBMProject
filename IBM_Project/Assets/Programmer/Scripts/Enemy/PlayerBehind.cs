using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehind : MonoBehaviour
{
    private GameObject player;

    private PlayerController pC;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pC = player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerStay(Collider other)
    {

        if (other == player.GetComponent<SphereCollider>())
        {
            if (other != null)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 toOther = player.transform.position - transform.position;
                Debug.Log(Vector3.Dot(forward.normalized, toOther.normalized));
                if (Vector3.Dot(forward, toOther) < 0)
                {
                    pC.isBehindEnemy = true;
                    Debug.Log("Player Behind Enemy");
                }
                else
                {
                    pC.isBehindEnemy = false;
                    Debug.Log("Player In Front Enemy");
                }
            }
        }
    }
}
