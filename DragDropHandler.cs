using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler , IPointerClickHandler{


	Transform inventory_parent = null;
	GameObject place_holder;
	public static GameObject drop_object;
	public static GameObject drag_object;
	public GameObject manager;


	public void OnBeginDrag(PointerEventData data)
	{
		place_holder = new GameObject ();
		place_holder.transform.SetParent (this.transform.parent);

		drag_object = data.pointerDrag.gameObject;

		LayoutElement le = place_holder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		place_holder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		inventory_parent = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);
	}

	public void OnDrag(PointerEventData data)
	{
		
		this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(data.position.x, data.position.y, 10));
	}

	public void OnEndDrag(PointerEventData data)
	{
		this.transform.SetParent(inventory_parent);
		this.transform.SetSiblingIndex (place_holder.transform.GetSiblingIndex ());
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		Destroy (place_holder);
	}


	public void OnPointerEnter(PointerEventData data)
	{
		drop_object = data.pointerEnter.gameObject;
	}

	public void OnPointerExit(PointerEventData data)
	{
		drop_object = null;
	}

	public void OnDrop(PointerEventData data)
	{
		//make the swap in the inventory manager
		if (drag_object != null && drop_object != null)
		{
			manager.GetComponent<InventoryManager> ().swapInventorySlots (drop_object.GetComponent<InventorySlot> ().getSlotId (), drag_object.GetComponent<InventorySlot> ().getSlotId ());
		
			//update the visual data for each slot involved
			drop_object.GetComponent<InventorySlot> ().updateSlot();
			drag_object.GetComponent<InventorySlot> ().updateSlot();

		}
		//nothing is dragging or dropping now
		drag_object = null;
		drop_object = null;
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			eventData.pointerPress.GetComponent<InventorySlot> ().equipItem ();
		}
	}
		
}
