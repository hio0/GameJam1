using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitted
{
    int hp {  get; set; }

    void Hitted(int damage);
}
