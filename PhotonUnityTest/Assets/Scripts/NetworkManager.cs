using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public Camera standbyCamera;
    public GameObject canvas;

    public bool offlineMode;

    private Text connectionStatus;
    private SpawnSpot[] spawnSpots;
    private GameObject myPlayer;

    #region Init_And_Update
    // Use this for initialization
	void Start () {
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();

        connectionStatus = canvas.transform.GetChild(0).GetComponent<Text>();
        connectionStatus.text = canvas.transform.GetChild(0).GetComponent<Text>().text;

        Connect();
	}
	
	// Update is called once per frame
	void Update () {
        if (connectionStatus.text != PhotonNetwork.connectionStateDetailed.ToString())
        {
            connectionStatus.text = PhotonNetwork.connectionStateDetailed.ToString();
        }
	}
    #endregion

    #region NetworkSetup
    void Connect()
    {
        if (offlineMode)
        {
            PhotonNetwork.offlineMode = true;
            OnJoinedLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings("0.0.1");
        }
    }

    void SpawnMyPlayer()
    {
        if (spawnSpots == null)
        {
            Debug.LogError("No spawn spots found.");
            return;
        }
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];


        // Access player prefab from resource folder and instantiate on all connected clients.
        myPlayer = PhotonNetwork.Instantiate("PlayerController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);

        // Enable my player components
        myPlayer.transform.GetComponentInChildren<Camera>().enabled = true;
        myPlayer.transform.GetComponentInChildren<AudioListener>().enabled = true;
        myPlayer.transform.GetComponent<CharacterController>().enabled = true; 
        myPlayer.transform.GetComponent<PlayerShooting>().enabled = true;
        ((MonoBehaviour)myPlayer.GetComponent("FirstPersonController")).enabled = true;

        // Disable menu camera & components
        foreach(Transform child in canvas.transform)
        {
            if(child.tag != "Crosshair")
            {
                child.gameObject.SetActive(false);
            }
        }
        standbyCamera.enabled = false;
        standbyCamera.gameObject.GetComponent<AudioListener>().enabled = false;
    }
    #endregion

    #region PhotonEvents
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Failed to join random room. Creating one...");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined room.");
        SpawnMyPlayer();
    }
    #endregion
}
