using SUPERCharacter;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private float interactionDistance;

    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;

    [SerializeField] private KeyCode interactionKey;

    [SerializeField] private SUPERCharacterAIO playerController;

    private GameObject previousInteraction = null;

    void Update()
    {
        InteractionRay();

        if (playerController.inUI)
        {
            interactionUI.SetActive(false);
        }
    }

    void InteractionRay()
    {
        Ray ray = playerCam.ViewportPointToRay((Vector3.one / 2f));
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            Outline outline = hit.collider.GetComponent<Outline>();

            if (interactable != null)
            {
                if (outline == null)
                {
                    hit.collider.gameObject.AddComponent<Outline>();
                }
                else
                {
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = new Color32(255, 165, 0, 255);
                    outline.OutlineWidth = 5f;
                }

                previousInteraction = hit.collider.gameObject;

                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(interactionKey))
                {
                    print("player is interacting with " + hit.collider.gameObject.name);
                    interactable.Interact();
                }

            }

        }

        if (previousInteraction != null) previousInteraction.GetComponent<Outline>().enabled = hitSomething;
        interactionUI.SetActive(hitSomething);

    }

}
