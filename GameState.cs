using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameState", menuName = "State/MyGameState")]
public class GameState : ScriptableObject
{
    public static bool isImmune;
    public static int score;
    public static int browniePoints;
}
