using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngrediantAddedEventArgs> OnIngrediantAdded;

    public class OnIngrediantAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    private List<KitchenObjectSO> kitchenObjectSOList;

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Not a valid ingredient.
            return false;
        }

        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Already has this type.
            return false;
        }

        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngrediantAdded?.Invoke(this, new OnIngrediantAddedEventArgs 
            { 
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }       
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
