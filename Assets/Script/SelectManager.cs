using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Material hightlightedMaterial;
    [SerializeField] private Material defaultMaterial;
    
    private Transform _selection;

    private void OnMouseDown()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (_selection != null) {

            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "movecube") {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {

                    selectionRenderer.material = hightlightedMaterial;
                }
                _selection = selection;
            }
        

        }
    }
}
