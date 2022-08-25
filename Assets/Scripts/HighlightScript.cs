using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
    //I found this code on a webpage resource thing and I don't really understand how it works,
    //But it allows you to put in all materials on an object and highlight it

    [SerializeField]
    private List<Renderer> renderers;

    private Color color = Color.white;

    private List<Material> materials;
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", color);
            }
        }
        else
        {
            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}
