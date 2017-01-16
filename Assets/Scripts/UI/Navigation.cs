using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
	private EventSystem system;

	void Start()
	{
		system = EventSystem.current;
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			Selectable next = null;
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
			}
			else if(system.currentSelectedGameObject != null)
			{
				next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
				if(next == null)
					next = system.firstSelectedGameObject.GetComponent<Selectable>();
			}

			if(next != null)
			{
				InputField inputfield = next.GetComponent<InputField>();
				if(inputfield != null)
					inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

				system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
			}
		}
	}
}
