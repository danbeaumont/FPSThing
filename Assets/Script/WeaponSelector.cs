using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    // define a custom class that we're using to associate a reference to a weapon along with whether or not we have collected it
    [System.Serializable]
    public class SelectableWeapon
    {
        public GameObject weaponGameObject;
        public bool collected = false;
    }

    public List<SelectableWeapon> weapons = new List<SelectableWeapon>();       // this is a list of the selectable weapons class. This is where our data is actually stored.

    // Update is called once per frame
    void Update()
    {
        // here we have one button per weapon, and select the weapon if the associated button is pressed. Alternatively, we could implement prev/next weapon buttons
        if (Input.GetButtonDown("SelectWeapon1"))
        {
            SelectWeapon(0);
        }
        else if (Input.GetButtonDown("SelectWeapon2"))
        {
            SelectWeapon(1);
        }
        else if (Input.GetButtonDown("SelectWeapon3"))
        {
            SelectWeapon(2);
        }
    }

    public void CollectWeapon(string collectedWeaponName)
    {
        // look at each weapon in our list of selectable weapons...
        for (int i = 0; i < weapons.Count; i++)
        {
            // and if we find a match in our list, set it's "collected" boolean to true...
            if (weapons[i] != null && weapons[i].weaponGameObject.name == collectedWeaponName)
            {
                weapons[i].collected = true;
                // ..also select it
                SelectWeapon(i);
            }
        }
    }

    public void SelectWeapon(int selectedIndex)             // select the weapon at a specified index of the list
    {
        // make sure the selection is valid - it must be in range and it must refer to a weapon we have collected
        if (selectedIndex < 0 ||
            selectedIndex >= weapons.Count ||
            weapons[selectedIndex] == null ||
            weapons[selectedIndex].collected == false)
        {
            return;
        }

        // activate the selected weapon, deactivate the others
        for (int index = 0; index < weapons.Count; index++)
        {
            if (weapons[index] != null)
            {
                weapons[index].weaponGameObject.SetActive(index == selectedIndex);
            }
        }
    }
}
