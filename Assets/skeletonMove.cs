using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class skeletonMove : MonoBehaviour{
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject cube;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        Vector3 cubePos = GameObject.Find("Cube").transform.position;
        agent.SetDestination(cubePos);

        if(agent.hasPath){
            anim.SetBool("walk", true);
        }

        //if(Vector3.Distance()){

        //}
        
        //if(Input.GetKeyDown(KeyCode.Keypad1)){ //attack

        //    anim.SetBool("attack", true);

        //} else if (Input.GetKeyDown(KeyCode.Keypad2)){

        //    anim.SetBool("walk", true);

        //} else if(Input.GetKeyDown(KeyCode.Keypad3)){
        //    anim.SetBool("die", true);
        //}

    }

    private void OnTriggerEnter(Collider other){

        //Debug.Log(other.name);

        if(other.name == "stick"){

            anim.SetBool("die", true);
            agent.isStopped = true;
            
        }
    }
}
