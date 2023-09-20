using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoins : MonoBehaviour
{

    // [SerializeField] GameObject shield;
    public int value;

    // [SerializeField] GameObject[] friutPrefab;

    // [SerializeField] float secondSpawn = 0.5f;

    // [SerializeField] float minTras;

    // [SerializeField] float maxTras;
    // public GameObject ItemPrefab;
    // public float Radius = 1;
    // Start is called before the first frame update

    AudioManager audioManager;
	// public AudioSource audioSource;

	// Use this for initialization

	private void Awake() {
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}
    void Start()
    {
        // StartCoroutine(friutSpawn());
    }

    // Update is called once per frame

    // IEnumerator FruitSpawn()
    // {
    //     while(true)
    //     {
    //         var wanted = Random.Range(minTras, maxTras);
    //         var Position = new Vector3(wanted, transform.position.y);
    //         GameObject gameObject = Instantiate(friutPrefab[Random.Range(0, friutPrefab.Length)],Position, Quaternion.identity);
    //         yield return new WaitForSecond(secondSpawn);
    //         Destroy(gameObject, 5f);
    //     }
    // }
    void Update()
    {
        // if(gameObject.CompareTag("plane")) SpawnObjectAtRandom();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("plane")) {
	        audioManager.PlaySFX(audioManager.coin);
           
			// audioManager.StopPlaySound(true);
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }

    // private void SpawnObjectAtRandom() {
    //     Vector3 randomPos = Random.insideUnitCircle * Radius;

    //     Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    // }
}
