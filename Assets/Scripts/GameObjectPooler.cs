using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using Zenject;

public abstract class GameObjectPooler <T> : MonoBehaviour where T : Component
{
   [SerializeField]
   public T prefab;
   
   
   protected Queue<T> objects = new Queue<T>();
   public static GameObjectPooler<T> Instance { get; private set; }

   private void Awake()
   {
      Instance = this;
   }

   public T GetFromPull()
   {
      if(objects.Count ==0) AddToPull(1);
      var newObject = objects.Dequeue();
      newObject.gameObject.SetActive(true);
      return newObject;
   }

   protected virtual void AddToPull(int count)
   {
   }

      public void ReturnToPull(T requiredObject)
   {
      requiredObject.gameObject.SetActive(false);
      objects.Enqueue(requiredObject);
   }
}  