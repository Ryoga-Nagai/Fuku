using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayerChanger : MonoBehaviour
{

    public GameObject VRM;// = GameObject.Find ("ExternalReceiver");
    private GameObject Face,Hair,FaceTrans;
    //private GameObject Camera = GameObject.Find("Test");
    private bool LayerChanged = false;

    public void Update()
    {
        if(VRM.transform.Find("LoadedModelParent") && !LayerChanged){
            
        //モデルが読み込まれたときに一度だけ呼ばれる

        //===========================================================
        //用途1:
        //ExternalReceiverで得たVRMのパーツのうち、顔と前髪を非表示にする
        // ゲームオブジェクトのレイヤーを変更することで対応
        //10番レイヤは外から見えるけどVR視点で見えないようにする処理　モデルの内部が見えないようにする処理

        Face = VRM.transform.Find("LoadedModelParent/VRM/Face").gameObject;
        Face.layer = 10;
        Hair = VRM.transform.Find("LoadedModelParent/VRM/Hair").gameObject;
        Hair.layer = 10;
        LayerChanged = true;

        //===========================================================
        //用途2:
        //ExternalReceiverで得たVRMの目の位置を基準に、[CameraRigの位置を変化させる]
        //とりま顔の位置を取得

        //Transform FaceTrans = Face.transform;
        //Vector3 pos = FaceTrans.position;

        //Hair = VRM.transform.Find("").gameObject;

        //this.gameObject.transform.parent = Face.transform;


        }else if(!VRM.transform.Find("LoadedModelParent"))LayerChanged = false;
        //モデルを読み込みなおしたときにも対応できるようにする(OnDestroyの方がいいのか？？)
    }
}