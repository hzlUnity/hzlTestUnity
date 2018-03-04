using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HZLFrameWork{
	#region ui状态改变事件
	public delegate void StateChangeEvent(Object ui,EnumObjectState NewState,EnumObjectState CurrentState);
	#endregion
	#region 全局枚举对象
	/// <summary>
	/// Enum object state.
	/// </summary>
	public enum EnumObjectState
	{
		None,
		Initial,
		Loading,
		Ready,
		Disabled,
		Closing,
	}
	#endregion

	public enum EnumUIType{
		None =-1,
		TestOne=0,
		TestTwo=1,

	}
	public class Defines{
		public Defines(){

		}
	}

}
