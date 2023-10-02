using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public Animator menu, idiomas;



    public void EntraMenu(){
        menu.SetBool("Entra", true);
    }
    public void SaleMenu(){
        menu.SetBool("Entra", false);
        menu.SetBool("Sale", true);
    }

    public void SaleIdioma(){
        idiomas.SetBool("Sale", true);
    }
}
