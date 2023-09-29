using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "gameState", menuName = "State/MyGameState")]
public class GameState : ScriptableObject
{
    public static bool isImmune;

    [SerializeField]
    public static double score;

    [SerializeField]
    public static TextMeshProUGUI TEXT_score;

    public static int browniePoints;
    public static bool recievedPowerup;

    [SerializeField]
    public static bool toggleMovement;

}
