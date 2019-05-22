using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour{

	//we create an empty list for the gameObjects
	private GameObject[] carList;
  private int currentCar = 0;
  // Start is called before the first frame update
  void Start(){
		//count the child game objects from the cars transform
  	carList = new GameObject[transform.childCount];
  	//loop through the child items and put them in the carlist array
  	for(int i = 0; i <transform.childCount; i++){
  		carList[i] = transform.GetChild(i).gameObject;
  	}

  	//Deactivates all the game objects in the list
  	foreach(GameObject gameObject in carList){
  		gameObject.SetActive(false);
  	}
  	//activates the first one
  	if(carList[0]){
  		carList[0].SetActive(true);
  	}
      
  }

  public void toggleCars(string direction){
    carList[currentCar].SetActive(false);

    if(direction == "Right"){
      currentCar++;
      if(currentCar>carList.Length -1)
        currentCar = 0;
    }else if(direction == "Left"){
      currentCar--;
      if(currentCar < 0)
        currentCar = carList.Length -1;
    }

    carList[currentCar].SetActive(true);

    GameObject cloudSystem = Instantiate(Resources.Load("cloudParticle")) as GameObject;
    ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem> ();
    cloudPuff.Play();
    cloudPuff.transform.position = new Vector3(22f, -0.5f, 0f);
    Destroy(cloudSystem, 2f);
  }
}
















