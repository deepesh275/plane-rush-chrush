using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
	public Joystick joystick;
	[SerializeField] private GameObject Object;
	Vector2 GameobjectRotation;
	// public Transform plane;
	private float GameobjectRotation2;
	private float GameobjectRotation3;
	// public Transform plane;
	public GameObject canvas;

	public bool FacingRight = true;

	void Update()
	{

		
		//Gets the input from the jostick
		
		GameobjectRotation = new Vector3(joystick.Horizontal, joystick.Vertical, 0);

		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight)
		{
			//Rotates the object if the player is facing right
			if (Object == null) {
				StartCoroutine(canvasStuff());
			} else {
				GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
				Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
			}
			// GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
			// Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
			
			
		}
		else
		{
			//Rotates the object if the player is facing left
			if (Object == null) {
				StartCoroutine(canvasStuff());
			} else {
				GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
				Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
			}
			// GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
			// Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
			
		}
		if (GameobjectRotation3 < 0 && FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
		else if (GameobjectRotation3 > 0 && !FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
	}
	private void Flip()
	{
		// Flips the player.
		if (Object == null) {

			// StartCoroutine(canvasStuff());
		} else {
			// FacingRight = !FacingRight;

			// transform.Rotate(0, 45, 0);
		}
		
	}

	IEnumerator canvasStuff(){
		yield return new WaitForSeconds(1f);
		canvas.SetActive(true);
		for(int i = 0; i <= 10; i++){
			float k = (float) i /10;
			canvas.transform.localScale = new Vector3(k,k,k);
			yield return new WaitForSeconds(.01f);
		}
        Destroy(gameObject);
    
	}
}
