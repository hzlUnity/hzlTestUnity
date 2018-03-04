using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HZLFrameWork;
namespace HZLFrameWork{
	public abstract class BaseUI : MonoBehaviour {
		#region Cache gameObject & transform 
		/// <summary>
		/// The cache game object.
		/// </summary>
		private GameObject _CacheGameObject;
		public GameObject CacheGameObject{
			get{
				if(_CacheGameObject == null){
					_CacheGameObject = this.gameObject;
				}
				return CacheGameObject;
			}
		}
		/// <summary>
		/// The cache transform.
		/// </summary>

		private Transform _CacheTransform;
		public Transform CacheTransform{
			get{
				if(_CacheTransform == null){
					_CacheTransform = this.transform;
				}
				return _CacheTransform;
			}
		}

		#endregion
		#region EnumObjectState & UI Type
		public event StateChangeEvent OnStateChanged;
		protected EnumObjectState _state = EnumObjectState.None;
		public EnumObjectState State{
			protected get{
				return this._state;
			}
			set{
				EnumObjectState preState = this._state;
				this._state = value;
				if (OnStateChanged != null) {
					OnStateChanged (this,this._state,preState);
				}
				
			}
		}
		public abstract EnumUIType GetUIType();
		#endregion
		void Awake(){
			OnAwake ();

		}
		// Use this for initialization
		void Start () {
			OnStart ();
		}

		// Update is called once per frame
		void Update () {
			if(this._state == EnumObjectState.Ready)
				OnUpdate (Time.deltaTime);
		}
		void Release(){
			this.State = EnumObjectState.Closing;
			GameObject.Destroy (this.CacheGameObject);
			OnRelease ();
				
		}
		public virtual void OnRelease(){
			this.State = EnumObjectState.None;
			//关闭音乐
			this.OnPlayCloseUIAudio();
		}
		public virtual void OnPlayCloseUIAudio(){
		}
		public virtual void OnPlayOpenUIAudio(){
		}

		void OnDestory(){
			this.State = EnumObjectState.None;
		}
		//处理一些通用的功能
		protected virtual void OnStart(){}
		protected virtual void OnUpdate(float deltaTime){}
		protected virtual void OnAwake(){
			this.State = EnumObjectState.Loading;
			OnPlayOpenUIAudio ();
		}
		public void SetUIWhenOpening(params object[] uiParams){
			SetUI (uiParams);
		}
		protected virtual void SetUI(params object[] uiParams){
			this.State = EnumObjectState.Loading;
		}
		private IEnumerator LoadDataAsyn(){
			yield return new WaitForSeconds (0);
			if(this.State == EnumObjectState.Loading){
				this.OnLoadData ();
				this.State = EnumObjectState.Ready;
			}
		}
		protected virtual void OnLoadData(){
		}
	}
}
