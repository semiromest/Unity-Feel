using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public class HammerManager : MonoBehaviour
{
    public ParticleSystem particleRandom;
    public MMF_Player hammerAnim;
    public GameObject phoneObject;
    public List<GameObject> burstObject = new List<GameObject>();
    public List<ParticleSystem> particleList = new List<ParticleSystem>();
    public int multiplierForce;
    public float distanceObject; //çekiç ile kýrýlacak objelerin arasýndaki mesafe
    public int touchCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < phoneObject.transform.childCount - 1; i++)
        {
            burstObject.Add(phoneObject.transform.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) //çekiç vurma animasyonu
        {
           Touch touch = Input.GetTouch(0);
            touchCount += 1;
            Debug.Log(touchCount/15);
            if (touch.phase == TouchPhase.Began)
            {
                RandomParticleGenerator();
                hammerAnim.PlayFeedbacks();
                particleRandom.Play();
                RandomForceGenerator();
           }

        }
        //if (Input.GetMouseButton(0))
        //{
        //    touchCount += 1; 
        //    Debug.Log(touchCount);
        //    RandomParticleGenerator();
        //    hammerAnim.PlayFeedbacks();
        //    particleRandom.Play();
        //    RandomForceGenerator();
        //}

    }
    public void RandomForceGenerator() //Rastgele Force'lar burada oluþturuldu
    {
        int listRandom1 = Random.Range(0, phoneObject.transform.childCount-1);
        int listRandom2 = Random.Range(0, phoneObject.transform.childCount-1);
        int listRandom3 = Random.Range(0, phoneObject.transform.childCount-1);

        float randomForce1 = Random.Range(-15, 15f);
        float randomForce2 = Random.Range(0, 0.7f);
        float randomForce3 = Random.Range(-15, 15f);
        if (Vector3.Distance(burstObject[listRandom1].transform.position,transform.position) < distanceObject )
        {
            burstObject[listRandom1].GetComponent<Rigidbody>().AddForce(randomForce1 * multiplierForce, randomForce2 * 200, randomForce3 * multiplierForce);
        }
        if (Vector3.Distance(burstObject[listRandom2].transform.position, transform.position) < distanceObject)
        {
            burstObject[listRandom2].GetComponent<Rigidbody>().AddForce(randomForce1 * multiplierForce, randomForce2 * 200, randomForce3 * multiplierForce);
        }
        if (Vector3.Distance(burstObject[listRandom3].transform.position, transform.position) < distanceObject)
        {
            burstObject[listRandom3].GetComponent<Rigidbody>().AddForce(randomForce1 * multiplierForce, randomForce2 * 200, randomForce3 * multiplierForce);
        }
        
        
    }
    public  void RandomParticleGenerator()
    {
        int randomParticleLenght = Random.Range(0, particleList.Count);
        particleRandom = particleList[randomParticleLenght];
    }
    public void ExitGameplayScene()
    {
       // GameManager.instance.UpdateGameState(GameManager.GameState.WinState);
       // GameplayController.instance.NextCustomer();
    }
}