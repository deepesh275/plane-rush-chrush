using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // public GameObject ItemPrefab;
    // public float Radius = 1;

    [SerializeField] GameObject[] friutPrefab;

    [SerializeField] float secondSpawn = 2f;

    [SerializeField] float minTras;

    [SerializeField] float maxTras;

    // public Transform mainCam;
    // public Transform middleBG;
    // public Transform sideBG;
    // public Transform background;

    public float length = 22.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    // Update is called once per frame
    IEnumerator FruitSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            // print("transform.position.y");
            // print(background.position.y);

            // print("transform.position.y");

            var Position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(friutPrefab[Random.Range(0, friutPrefab.Length)],Position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
    // void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.Space)) SpawnObjectAtRandom();
    // }

    void Update()
    {
        // Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
        // Instantiate(friutPrefab, randomSpawnPosition, Quaternion.identity);
        // if (mainCam.position.x > middleBG.position.x)
        //     sideBG.position = middleBG.position + Vector3.right * length;

        // if(mainCam.position.x < middleBG.position.x)
        //     sideBG.position = middleBG.position + Vector3.left * length;

        // if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        // {
        //     Transform z = middleBG;
        //     middleBG = sideBG;
        //     sideBG = z;
        // }

    }

    // private void SpawnObjectAtRandom() {
    //     Vector3 randomPos = Random.insideUnitCircle * Radius;

    //     Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    // }
}
