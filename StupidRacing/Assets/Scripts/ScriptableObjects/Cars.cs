using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/CarChoices")]
public class Cars : ScriptableObject
{
    public List<Car> carChoices;
}

[System.Serializable]
public class Car {
    public string name;

    public Sprite image;

    public float speed;
    //public float drift;

}

