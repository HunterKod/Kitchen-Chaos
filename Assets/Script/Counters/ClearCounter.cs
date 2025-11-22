using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object here.
            if (player.HasKitchenObject())
            {
                // Player is carrying a kitchen object.
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }

            else
            {
                // Player is not carrying a kitchen object.
            }
        }

        else
        {
            // There is a kitchen object here.
            if (player.HasKitchenObject())
            {
                // Player is carrying a kitchen object.
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a plate.
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }

                else
                {
                    // Player is not carrying the plate but somthing else.
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // There is a plate here.
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }

            else
            {
                // Player is not carrying a kitchen object.
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
