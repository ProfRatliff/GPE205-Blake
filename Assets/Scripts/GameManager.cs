using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The GameManager.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// The singleton instance of the GameManager.
    /// </summary>
    public static GameManager instance;

    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    #endregion Variables

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer();
    }

    /// <summary>
    /// The function to spawn the player and link the pawn to the controller.
    /// </summary>
    public void SpawnPlayer()
    {
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
    }
}
