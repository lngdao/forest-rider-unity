using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : GameElement
{
    private Transform parent;

    public void HandleOnPlayerEnter(GameObject gameObject)
    {
        string tag = gameObject.tag;
        Destroy(gameObject);

        Game.controller.audio.PlayAudio("Item");
        if (tag == "Heart")
        {
            Game.controller.ui.HandleAddHeathPlayer();
        } else
        {
            Game.controller.ui.HandleAddScoreGame(5);
        }

    }

    public void InitParent(Transform parent)
    {
        this.parent = parent;
    }

    public void SpawnItem(Transform transform, float zStart, float zEnd)
    {
        Item[] items = Game.model.item.items; 
        GameObject item = Instantiate(items[Random.Range(0, items.Length)].prefab, parent);
        
        item.transform.position = new Vector3(Random.Range(-3.1f, 3.1f), 1.5f, Random.Range(zStart, zEnd));
        item.transform.localPosition = new Vector3(Random.Range(-3.1f, 3.1f), item.transform.localPosition.y, Random.Range(zStart, zEnd));
    }
}
