using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public PlayerId id;
    public string displayName;

    public Cars cars;
    public Guns guns;

    [Header("UI")]
    public TextMeshProUGUI nameView;
    public Image carView;
    public Image gunView;

    //Values
    [HideInInspector]
    public bool isReady;

    private int carIndex;
    private int gunIndex;

    // Start is called before the first frame update
    void Start()
    {
        nameView.text = displayName;
        //dont destroy on load, static get for the two players
        DisplayCar();
        DisplayGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Car
    public void Click_NextCar()
    {
        carIndex = (carIndex + 1) % cars.carChoices.Count;
        DisplayCar();
    }

    public void Click_PreviousCar()
    {
        /*carIndex = (carIndex - 1) % cars.carChoices.Count;
        if (carIndex < 0) carIndex = -carIndex;
        DisplayCar();*/
    }

    private void DisplayCar()
    {
        Car carChoice = cars.carChoices[carIndex];
        carView.sprite = carChoice.image;
    }

    //Gun 
    public void Click_NextGun()
    {
        gunIndex = (gunIndex + 1) % guns.gunChoices.Count;
        DisplayGun();
    }

    public void Click_PreviousGun()
    {
        /*gunIndex = (gunIndex - 1) % guns.gunChoices.Count;
        if (gunIndex < 0) gunIndex *= -1;
        DisplayGun();*/
    }

    private void DisplayGun()
    {
        Gun gun = guns.gunChoices[gunIndex];
        //gun.ResizeImage(gunView.gameObject.GetComponent<RectTransform>());
        gunView.sprite = gun.image;
    }

    public void Click_Confirm()
    {
        isReady = true;
        Save();
    }

    private void Save()
    {
        string gun = id.ToString() + "_gun";
        string car = id.ToString() + "_car";
        string name = id.ToString() + "_name";
        PlayerPrefs.SetInt(gun, gunIndex);
        PlayerPrefs.SetInt(car, carIndex);
        PlayerPrefs.SetString(name, displayName);
    }
}

public enum PlayerId
{
    Player1, Player2
}
