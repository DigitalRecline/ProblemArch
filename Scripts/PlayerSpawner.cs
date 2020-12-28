using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    
    private GameObject _player;
   

    private void Start()
    {
       Instantiate(_playerPrefab);
    
    }

}
