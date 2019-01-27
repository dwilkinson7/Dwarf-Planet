using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBench : MonoBehaviour
{
    [Header("Holograms")]
    public Hologram hologram1, hologram2;
    [Header("Craftables")]
    public Rigidbody torch;
    public Rigidbody woodPlat, stonePlat, ironPlat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            // Collision with a block
            if (hologram1.heldItem == "")
            {
                hologram1.SetItem(collision.gameObject.tag,
                    collision.collider.GetComponent<MeshRenderer>(),
                    collision.collider.GetComponent<MeshFilter>());
                Destroy(collision.gameObject);
            }
            else
            {
                hologram2.SetItem(collision.gameObject.tag,
                    collision.collider.GetComponent<MeshRenderer>(),
                    collision.collider.GetComponent<MeshFilter>());
                Destroy(collision.gameObject);

                TryCraft();
            }
        }
    }

    void TryCraft()
    {
        // Check if the recipe is valid
        if (Match("Straw", "Wood"))
            Craft(torch);
        else
        {
            // else, pop the holograms
            hologram1.Pop();
            hologram2.Pop();
        }
    }

    private void Craft(Rigidbody result)
    {
        if (!result)
        {
            Debug.LogError("Craftable not found: " + hologram1.heldItem + hologram2.heldItem);
            return;
        }

        hologram1.Clear();
        hologram2.Clear();
        Instantiate(result, transform.position + 2 * transform.up, transform.rotation).AddForce(transform.up, ForceMode.Impulse);
    }

    private bool Match(string v1, string v2)
    {
        return (hologram1.heldItem.Equals(v1) && hologram2.heldItem.Equals(v2))
            || (hologram1.heldItem.Equals(v2) && hologram2.heldItem.Equals(v1));
    }
}
