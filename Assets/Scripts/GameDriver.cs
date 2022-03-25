using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour
{

    [SerializeField] GameObject[] Cs;
    [SerializeField] GameObject Cchanger;
    [SerializeField] GameObject LifeSpawnner;
    [SerializeField] GameObject RefSlider;
    [SerializeField] Transform BallPos;
    [SerializeField] GameObject aCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawnner()
    {
        Destroy(aCircle);

        int index = Random.Range(0, 5);
        aCircle = Instantiate(Cs[index]);
        aCircle.transform.position = new Vector3(0, BallPos.position.y + 5, 0);

        int r = Random.Range(0, 7);
        if(r==0)
        {
            GameObject ls = Instantiate(LifeSpawnner);
            ls.transform.position = new Vector3(0, BallPos.position.y + 7, 0);
        }
        GameObject aCC;
        aCC = Instantiate(Cchanger);
        aCC.transform.position = new Vector3(0, BallPos.position.y + 10, 0);
        RefSlider.transform.position = new Vector3(0, BallPos.position.y, 0);

    }
}
