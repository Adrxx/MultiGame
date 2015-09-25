#pragma strict
var ConstantSpeed : float = .01f;

function Start () {

}

function Update () {
transform.position.x = transform.position.x + ConstantSpeed;

}