using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MeshRenderer renderer;
    [SerializeField] MeshFilter filter;
    [HideInInspector] public string heldItem = "";
    [Header("Prefabs")]
    public Rigidbody Straw;
    public Rigidbody Wood;
    public Rigidbody Stone;
    public Rigidbody Iron;

    public void SetItem(string iname, MeshRenderer r, MeshFilter f)
    {
        if (heldItem == "")
        {
            renderer.sharedMaterials = r.sharedMaterials;
            filter.sharedMesh = f.sharedMesh;
            heldItem = iname;
        }
    }

    public void Clear()
    {
        renderer.sharedMaterials = new Material[] { };
        filter.sharedMesh = null;
        heldItem = "";
    }

    public void Pop()
    {
        Rigidbody template;
        Debug.Log("Popping " + heldItem);
        template = heldItem.Equals("Straw") ? Straw : heldItem.Equals("Wood") ? Wood : heldItem.Equals("Stone") ? Stone : heldItem.Equals("Iron") ? Iron : null;
        if (template)
        {
            Instantiate(template, transform.position, transform.rotation).AddForce(transform.forward * 5f, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Pop failed");
        }

        Clear();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 5f, Space.Self);
    }
}
