using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneBehaviour : MonoBehaviour {

	[SerializeField] private GameObject Object;

	public Joystick joystick;
	public Camera cam;
	public Transform plane;
	public GameObject brokenPlane, canvas;
	public Transform leftPoint, rightPoint, forwardPoint;
	Rigidbody2D rb;
	public float speed , rotateSpeed = 50f;
	Vector3 mousePosition;
	bool isGameOver;
	public bool timeIsRunning = true;
	public TMP_Text timeText;
	public float timeRemaining = 0;
	private float GameobjectRotation2;
	private float horijoyStick;
	private float vertjoyStick;
	[SerializeField] private GoogleAdMobController gameAds;

	// public AudioSource audioSource;
	AudioManager audioManager;
	Vector2 GameobjectRotation;
	[Range(0f, 1f)] public float smoothness;
    public bool noActiveJoy =  false;

    public bool startPlane =  true;


	private void Awake() {
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}
	

	// Use this for initialization
	void Start () {

		// PlayerPrefs.SetInt("gameOver", selectedOption);

	    timeIsRunning = true;

		if(cam == null) cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
        gameAds.RequestAndLoadInterstitialAd();
		// gameAds.RequestAndLoadRewardedAd();
		// gameAds.RequestAndLoadRewardedInterstitialAd();
		
		// audioManager.PlaySFX(audioManager.planeSound);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Debug.Log("jhjhjh");
		// Debug.Log(timeIsRunning);
		if (timeIsRunning) {
            if (timeRemaining >= 0 )
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
	

		if(!isGameOver){

			
			movePlane();
		}
		
	}

	void movePlane(){
		if (joystick.Vertical != 0 )
		{
            rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);		
			horijoyStick = joystick.Horizontal;
			vertjoyStick = joystick.Vertical;

			noActiveJoy = true;
		} 
		else if(noActiveJoy == false && startPlane == true) {
				rb.velocity = transform.right * speed;
		} 
	}


	// void rotatePlane(float x){	
	// 	    		Debug.Log(x);

	// 		// if (Object == null) {
	// 		// 	StartCoroutine(canvasStuff());
	// 		// } else {
	// 		// 	GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
	// 		// }
				

	// 	float angle;
	// 	Vector2 direction = new Vector2(0,0);


	// 	if(x < 0) direction = (Vector2) leftPoint.position - rb.position;
	// 	if(x > 0) direction = (Vector2) rightPoint.position - rb.position;
		
	// 	// direction.Normalize();
	// 	angle = Vector3.Cross(direction, transform.up).z;
	// 	// if(x != 0) rb.angularVelocity = -rotateSpeed * angle;
	// 	// else rb.angularVelocity = 0;
	// 	angle = Mathf.Atan2(forwardPoint.position.y - rb.transform.position.y, forwardPoint.position.x - rb.transform.position.x) * Mathf.Rad2Deg;
	// 	Debug.Log("angle");
	// 	Debug.Log(angle);
	// 	Debug.Log("angle");

	// 	// rb.transform.rotation = Quaternion.Euler(new Vector3(0,0, angle));

	// }

	 void Update()
    {
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }

        
    }

	public void gameOver(Transform missile){
		// audioSource.Stop();
		GetComponentInChildren<SpriteRenderer>().enabled = false;
		isGameOver = true;
		timeIsRunning = false;

		rb.velocity = new Vector2(0,0);
		cam.gameObject.GetComponent<CameraBehaviour>().gameOver = true;
		GameObject planeTemp = Instantiate(brokenPlane, transform.position, transform.rotation);
		for(int i =0; i < planeTemp.transform.childCount; i++){
			Rigidbody2D rbTemp = planeTemp.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
			rbTemp.AddForce(((Vector2) missile.position - rbTemp.position) * -5f,ForceMode2D.Impulse);
		}
		StartCoroutine(canvasStuff());
		GameOverData(1);
	}

	IEnumerator canvasStuff(){
		yield return new WaitForSeconds(1f);
		canvas.SetActive(true);
		for(int i = 0; i <= 10; i++){
			float k = (float) i /10;
			canvas.transform.localScale = new Vector3(k,k,k);
			yield return new WaitForSeconds(.01f);
		}
		// 
       
        // Do something  
        Destroy(gameObject);
	}

	void DisplayTime (float timeToDisplay) {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt (timeToDisplay % 60);
        timeText.text = string.Format ("{00:00} : {01:00}",minutes , seconds);
    }
	void GameOverData (int gameOver) {
		var gameOverValue = PlayerPrefs.GetInt("gameOver");
		if (gameOverValue == 0)
		{
			PlayerPrefs.SetInt("gameOver", 1);

		} else if (gameOverValue == 1) {
			
			PlayerPrefs.SetInt("gameOver", 2);

		} else if (gameOverValue == 2) {
			PlayerPrefs.SetInt("gameOver", 0);
		 	gameAds.ShowInterstitialAd();

		}
    }

	// public void RewardAddGetCoins () {
	// 	gameAds.ShowRewardedAd();
	// 	gameAds.ShowRewardedInterstitialAd();
	// 	// var currentCoinsValue = PlayerPrefs.GetInt("currentCoins");
	// 	// PlayerPrefs.SetInt("currentCoins", currentCoinsValue + 10);

    // }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;


// public class PlaneBehaviour : MonoBehaviour {

// 	public Camera cam;
// 	public Transform plane;
// 	public GameObject brokenPlane, canvas;
// 	public Transform leftPoint, rightPoint, forwardPoint;
// 	Rigidbody2D rb;
// 	public float speed = 5f, rotateSpeed = 50f;
// 	Vector3 mousePosition;
// 	bool isGameOver;


	
// 	public Joystick joystick;
// 	public bool timeIsRunning = true;
// 	public TMP_Text timeText;
// 	public float timeRemaining = 0;
// 	private float GameobjectRotation2;
// 	private float horijoyStick;
// 	private float vertjoyStick;

// 	// public AudioSource audioSource;
// 	AudioManager audioManager;
// 	Vector2 GameobjectRotation;
// 	[Range(0f, 1f)] public float smoothness;
//     public bool noActiveJoy =  false;


// 	// Use this for initialization
// 	void Start () {
// 		if(cam == null) cam = Camera.main;
// 		rb = GetComponent<Rigidbody2D>();
// 	}
	
// 	// Update is called once per frame
// 	void FixedUpdate () {
// 		if(!isGameOver){
// 			movePlane();
// 			rotatePlane(Input.GetAxis("Horizontal"));
// 		}
// 	}

// 	void movePlane(){
// 		rb.velocity = transform.up * speed;
// 	}

// 	void rotatePlane(float x){	
// 		float angle;
// 		Vector2 direction = new Vector2(0,0);

// 		if(x < 0) direction = (Vector2) leftPoint.position - rb.position;
// 		if(x > 0) direction = (Vector2) rightPoint.position - rb.position;
		
// 		direction.Normalize();
// 		angle = Vector3.Cross(direction, transform.up).z;
// 		if(x != 0) rb.angularVelocity = -rotateSpeed * angle;
// 		else rb . angularVelocity = 0;
// 		angle = Mathf.Atan2(forwardPoint.position.y - plane.transform.position.y, forwardPoint.position.x - plane.transform.position.x) * Mathf.Rad2Deg;
// 		plane.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
// 	}

// 	public void gameOver(Transform missile){
// 		GetComponentInChildren<SpriteRenderer>().enabled = false;
// 		isGameOver = true;
// 		rb.velocity = new Vector2(0,0);
// 		cam.gameObject.GetComponent<CameraBehaviour>().gameOver = true;
// 		GameObject planeTemp = Instantiate(brokenPlane, transform.position, transform.rotation);
// 		for(int i =0; i < planeTemp.transform.childCount; i++){
// 			Rigidbody2D rbTemp = planeTemp.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
// 			rbTemp.AddForce(((Vector2) missile.position - rbTemp.position) * -5f,ForceMode2D.Impulse);
// 		}
// 		StartCoroutine(canvasStuff());
// 	}

// 	IEnumerator canvasStuff(){
// 		yield return new WaitForSeconds(1f);
// 		canvas.SetActive(true);
// 		for(int i = 0; i <= 10; i++){
// 			float k = (float) i /10;
// 			canvas.transform.localScale = new Vector3(k,k,k);
// 			yield return new WaitForSeconds(.01f);
// 		}
// 		Destroy(gameObject);
// 	}
// }
