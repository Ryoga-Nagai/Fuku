using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; // SteamVRの機能を利用するので、using文を追加

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;          // コントローラ入力元
    public SteamVR_Behaviour_Pose controllerPose;   // コントローラの位置情報
    public SteamVR_Action_Boolean grabAction;       // コントローラの「つかむ」アクション

    private GameObject collidingObject;             // コライダーが接触しているオブジェクトを保存(接触しているコライダーが存在するか)
    private GameObject objectInHand;                // 現在オブジェクトを掴んでいるか

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }        
    }

    // コライダーが接触したとき
    public void OnTriggerEnter(Collider other)
    {
        SetCollideingObject(other);
    }
    // コライダーが触れているとき
    public void OnTriggerStay(Collider other)
    {
        SetCollideingObject(other);
    }
    // コライダーがはずれたとき
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void SetCollideingObject(Collider col)
    {
        // すでに何かをつかんでいる場合、もしくは対象にRigidBodyコンポーネントが存在しない場合
        // 処理しない
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        // コライダーが接触したオブジェクトを保存
        collidingObject = col.gameObject;
    }

    // オブジェクトを掴む
    // FixedJointコンポーネントをコントローラオブジェクトに追加し、
    // つかんでいるオブジェクトのRigidBodyを接続することで
    // つかむという動作を実現している
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // FixedJointコンポーネントを動的に追加する
    // 勝手に外れないように、breakForceとbreakTorqueに大きな値を入れている
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;

        return fx;
    }

    // オブジェクトを放す
    // 追加したFixedjointを破棄し、
    // 放したときのコントローラのVelocityをオブジェクトにコピーすることで
    // 「投げる」という挙動を再現している
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
    }
}