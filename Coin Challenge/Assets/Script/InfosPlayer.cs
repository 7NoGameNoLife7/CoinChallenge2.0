using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfosPlayer : MonoBehaviour
{
    public static InfosPlayer Instance;
    public int score = 0;                                       
    public int life = 3;

    private void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        IHM.Instance.UpdateScore();             //appel de fonction 
        IHM.Instance.UpdateLife();
    }

    public void Addscore(int value)
    { 
        score += value;

        IHM.Instance.UpdateScore();
        IHM.Instance.UpdateLife();
    }

    public void UpdateLife(int value)
    {
        life += value;
        IHM.Instance.UpdateLife();
       /*if (life <= 0) 
        {
            IHM.Instance.DisplayGameOverMenu(true);
        }*/
    }
}
