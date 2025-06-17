using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerState
{
    public Vector2 position;
    public int health;
    public List<string> inventory = new();
}

[Serializable]
public class ItemState
{
    public string id;
    public Vector2 position;
    public bool pickedUp;
}

[Serializable]
public class EnvironmentState
{
    public string id;
    public bool isActive;
}

[Serializable]
public class GameState
{
    public PlayerState player = new();
    public List<ItemState> items = new();
    public List<EnvironmentState> environment = new();
}
