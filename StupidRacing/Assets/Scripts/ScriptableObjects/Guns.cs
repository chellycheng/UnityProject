using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "MyAssets/GunChoices")]
public class Guns : ScriptableObject
{
    public List<Gun> gunChoices;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Gun
{
    public string name;
    public Sprite image;

    public float size = 1f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public float speed;
    public float damage;
    public float rechargeTime = 0.1f;

    /*public void ResizeImage(RectTransform image)
    {
        image.localScale = new Vector3(size, size, 1);
    }*/
}
