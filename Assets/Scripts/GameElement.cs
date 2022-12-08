using System;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public Game Game { get { return FindObjectOfType<Game>(); } }
}
