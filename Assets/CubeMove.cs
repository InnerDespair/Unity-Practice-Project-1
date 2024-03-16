using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeMove : MonoBehaviour{

    public GameObject pauseText;
    public TMP_Text countdownText;
    public TMP_Text scoreCounter;
    public TMP_Text winMessage;
    public GameObject sphere;
    public int score = 0;
    private float timer = 0f;
    private bool countdownActive = false;

    private void OnTriggerEnter(Collider other){
        //Debug.Log(score);

        float newX = Random.Range(-31, 11);
        float newZ = Random.Range(-26, 17);

        score += 1;
        scoreCounter.text = "Score: " + score;

        sphere.transform.position = new Vector3(newX, 2, newZ);

    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
        float speed = 20f;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float vertMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(horizMove, 0, vertMove);


        if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1){

            Time.timeScale = 0;
            pauseText.SetActive(true);
            Debug.Log("game paused");
            
        } else if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0){

            Time.timeScale = 1;
            pauseText.SetActive(false);
            Debug.Log("game unpaused");
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            countdownActive = true;
        }

        if(countdownActive){
            if(timer < 3){
                timer += Time.deltaTime;
                countdownText.text = "Shutting down in: " + (int)(4 - timer); 
            } else{
                //Application.Quit(); //for full app
                UnityEditor.EditorApplication.isPlaying = false; //for unity editor
            }
        }

        if(score >= 20){
            winMessage.text = "You Win!";
            countdownActive = true;
        }

    }

}
