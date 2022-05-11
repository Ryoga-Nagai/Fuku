using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringControl : MonoBehaviour
{
	//振動中心を決めるオブジェクト
	public GameObject centerObject;

	Rigidbody rb;　
	Transform centerObjectTransform;

	//単振動させる物体のRigidbodyと
	//振動中心に設定したオブジェクトのTransformを取得しておく
	void Awake() 
	{
		rb = GetComponent<Rigidbody>();
		centerObjectTransform = centerObject.transform;
	}

//弾性力(復元力)を定義している関数
	void AddSpringForce(Vector3 centerObject_position, float r)
	{
		var diff = centerObject_position - transform.position; //ばねの伸び=振動中心の位置(x0)-物体の位置(x)
		var force = diff * r; //弾性力(復元力) = k*(x0-x)
		rb.AddForce(force*2);//弾性力を加える
	}

	//0.02秒ごとに弾性力を更新していく
	void FixedUpdate() 
	{
		AddSpringForce(centerObjectTransform.position, 10f);
	}

}