using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdController : MonoBehaviour
{

    public GameObject Bird;
    public GameObject PipePrefab;
    public float Gravity = 30;
    public float Jump = 10;
    public float PipeSpawnInterval = 2;
    public float PipesSpeed = 5;

    public float VerticalSpeed;
    private float PipeSpawnCountdown;
    private GameObject PipesHolder;
    private int PipeCount;

    // Start is called before the first frame update
    void Start()
    {
        PipesHolder = new GameObject("PipesHolder");
        PipesHolder.transform.parent = this.transform;

        //reset bird
        VerticalSpeed = 0;
        Bird.transform.position = Vector3.up * 5;


        //reset time
        PipeSpawnCountdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // STEP 1 - Movement
        VerticalSpeed += -Gravity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = 0;
            VerticalSpeed += Jump;
        }

        Bird.transform.position += Vector3.up * VerticalSpeed * Time.deltaTime;

        // Step 2 - Pipes
        PipeSpawnCountdown -= Time.deltaTime;

        if( PipeSpawnCountdown <= 0)
        {
            PipeSpawnCountdown = PipeSpawnInterval;

            // Create pipe
            GameObject pipe = Instantiate(PipePrefab);
            pipe.transform.parent = PipesHolder.transform;
            pipe.transform.name = (++PipeCount).ToString();


            pipe.transform.position += Vector3.right * 129;
            pipe.transform.position += Vector3.up * Mathf.Lerp(4, 30, Random.value);

        }
        // move pipes left
        PipesHolder.transform.position += Vector3.left * PipesSpeed * Time.deltaTime;

    }
}
