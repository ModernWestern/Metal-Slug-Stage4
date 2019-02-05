using UnityEngine;

public struct GameInputs
{
    public static bool Forward { get { return Input.GetKey(KeyCode.RightArrow); } }
    public static bool Forward_Jump { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A); } }
    public static bool Forward_Shoot { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.S); } }
    public static bool Forward_Jump_Shoot { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S); } }
    public static bool Forward_Jump_Shoot_Down { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow); } }
    public static bool Forward_Duck { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow); } }
    public static bool Forward_Duck_Shoot { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S); } }
    public static bool Forward_DropGrenade { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.W); } }
    public static bool Forward_Jump_DropGrenade { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W); } }
    public static bool Forward_Duck_DropGrenade { get { return Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.W); } }

    public static bool Back { get { return Input.GetKey(KeyCode.LeftArrow); } }
    public static bool Back_Jump { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A); } }
    public static bool Back_Shoot { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.S); } }
    public static bool Back_Jump_Shoot { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S); } }
    public static bool Back_Jump_Shoot_Down { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow); } }
    public static bool Back_Duck { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow); } }
    public static bool Back_Duck_Shoot { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S); } }
    public static bool Back_DropGrenade { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.W); } }
    public static bool Back_Jump_DropGrenade { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W); } }
    public static bool Back_Duck_DropGrenade { get { return Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.W); } }

    public static bool SingleShoot { get { return Input.GetKeyDown(KeyCode.S); } }

    public static bool Up { get { return Input.GetKey(KeyCode.UpArrow); } }
    public static bool Down { get { return Input.GetKey(KeyCode.DownArrow); } }

    public static bool Jump { get { return Input.GetKeyDown(KeyCode.A); } }
    public static bool Jump_Shoot { get { return Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S); } }
    public static bool Duck { get { return Input.GetKey(KeyCode.DownArrow); } }
    public static bool Duck_Shoot { get { return Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S); } }

    public static bool Stab { get { return Input.GetKeyDown(KeyCode.S); } }
}