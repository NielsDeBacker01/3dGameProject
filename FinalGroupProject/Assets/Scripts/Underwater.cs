using UnityEngine;
 using System.Collections;
 
 public class Underwater    : MonoBehaviour {
 public float waterHeight;
 
 private bool isUnderwater;
 private Color normalColor;
 private Color underwaterColor;
 
 // Use this for initialization
 void Start () {
 normalColor = new Color (0.5f, 0.5f, 0.5f, 0.5f);
 underwaterColor = new Color (0.15f, 0.31f, 0.40f, 0.5f);
 RenderSettings.fog = true;
 }
 
 // Update is called once per frame
 void Update () {
 if ((transform.position.y < waterHeight) != isUnderwater) {
 isUnderwater = transform.position.y < waterHeight;
 if (isUnderwater) SetUnderwater ();
 if (!isUnderwater) SetNormal ();
 }
 }
 
 void SetNormal () {
 RenderSettings.fogColor = normalColor;
 RenderSettings.fogDensity = 0.01f;
 
 }
 
 void SetUnderwater () {
 RenderSettings.fogColor = underwaterColor;
 RenderSettings.fogDensity = 0.0075f;
 
 }

 }