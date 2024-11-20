using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInBasket : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderer;
    void Start()
    {
        FruitBasket();
    }
    private void FruitBasket(){
     foreach(var img in spriteRenderer){
        if(img !=null){
            img.sprite=ButtonManager.Instance.listFruits[ButtonManager.Instance.LoadSelectedSprite()].imgFruit;
        }
     }
    }
}
