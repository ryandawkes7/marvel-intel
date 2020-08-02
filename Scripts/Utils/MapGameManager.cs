using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MapGameManager : Singleton<MapGameManager>
{
   [SerializeField] private Player currentPlayer;

   public Player CurrentPlayer
   {
      get { return currentPlayer;  }
   }

   private void Awake()
   {
      Assert.IsNotNull(currentPlayer);
   }
}
