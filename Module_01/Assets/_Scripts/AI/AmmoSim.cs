using UnityEngine;

public class AmmoSim : MonoBehaviour
{
    public AmmoUI ui;
    int cur=30, mag=30, res=90;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0) && cur>0){ cur--; ui.Set(cur,mag,res); }
        if (Input.GetKeyDown(KeyCode.R) && res>0){
            int need = mag-cur; int take = Mathf.Min(need, res); cur += take; res -= take; ui.Set(cur,mag,res);
        }
    }
}