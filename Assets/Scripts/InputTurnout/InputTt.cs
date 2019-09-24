using UnityEngine;

namespace InputTurnout {
    public static class InputTt {
	    //
	    //Supplier
	    //
	    private static IInputSupplier inputSupplier;
	    private static IInputSupplier emptySupplier;

	    public static IInputSupplier Input(object key) {
		    if (inputSupplier == null) {
			    WarnWrite("InputWrapper is null.I'll do initialization");
			    SupplierInitialize();
		    }
		    
		    if (key != current) {
			    return emptySupplier;
		    }

		    if (!isActive) {
			    return emptySupplier;
		    }
		    
		    return inputSupplier;
	    }

	    /// <summary>
	    /// Supplierが空の場合に行われる初期化
	    /// </summary>
	    private static void SupplierInitialize(){
		    SetSupplier(new WrapUnityStandardInputEntity(),new WrapUnityStandardInputEmpty());
	    }

	    /// <summary>
	    /// Supplierをセットします
	    /// </summary>
	    /// <param name="entity">実Supplier</param>
	    /// <param name="empty">空Supplier</param>
	    public static void SetSupplier(IInputSupplier entity,IInputSupplier empty){
		    LogWrite("------set Input Supplier------");
		    inputSupplier = entity;
		    emptySupplier = empty;
	    }

	    //
	    //Receiver
	    //
		private static object current;
		private static object before;

		/// <summary>
		/// そのインスタンスが現在の出力先かどうか返します
		/// </summary>
		/// <param name="key">チェックするインスタンス</param>
		/// <returns></returns>
	    public static bool IsCurrent(object key) {
		    return current == key;
	    }
	    
		/// <summary>
		/// 出力先インスタンスを変更します
		/// </summary>
		/// <param name="receiver">変更するインスタンス</param>
	    public static void ChangeReceiver(object receiver){
		    if (freeze){
			    WarnWrite("can't be changed because i'm freeze");
			    return;
		    }
		    if (receiver == current){
			    return;
		    }
		    before = current;
		    current = receiver;
		    LogWrite("------change receiver to "+receiver+"------");
	    }

		/// <summary>
		/// 出力先をアンドゥします
		/// </summary>
	    public static void UndoReceiver(){
		    if (freeze){
			    WarnWrite("can't be changed because i'm freeze");
			    return;
		    }
		    if (before == null){
			    ErrorWrite("can't Undo bc I haven't before receiver");
			    ReceiverClear();
			    return;
		    }
		    LogWrite("InputTT run undo..... ");
		    ChangeReceiver(before);
	    }

		/// <summary>
		/// 出力先を空にします
		/// </summary>
	    public static void ReceiverClear(){
		    if (freeze){
			    WarnWrite("can't be changed because i'm freeze");
			    return;
		    }
		    before = current;
		    current = null;
		    LogWrite("------clear receiver------");
	    }

	    
		//
	    //Systems
	    //
		private static bool isActive = true;
		/// <summary>
		/// 出力を行うかどうか
		/// </summary>
		public static bool IsActive{
			get{
				return isActive;
			}
			set{
				if (freeze){
					ErrorWrite("Input is freeze now, current key is "+freezeKey);
					return;
				}
				LogWrite("change InputTt's active to "+value);
				isActive = value;
			}
		}

		private static bool freeze=false;
		private static System.Object freezeKey=null;
	
		/// <summary>
		/// クラスをキーに全ての変更をロックします
		/// </summary>
		/// <param name="trigger">キーとするインスタンス</param>
		public static void Freeze(System.Object trigger){
			if (freezeKey == null){
				freeze = true;
				freezeKey = trigger;
			} else{
				ErrorWrite("Input freeze now. current key is "+freezeKey);
			}
		}

		/// <summary>
		/// ロックを解除します
		/// </summary>
		/// <param name="trigger">キーとして使用しているインスタンス</param>
		public static void UnFreeze(System.Object trigger){
			if (!freeze){
				ErrorWrite("Input isn't freeze now");
				return;
			}
			
			if (freezeKey != null){
				if (System.Object.ReferenceEquals(freezeKey, trigger)){
					freeze = false;
					freezeKey = null;
				} else{
					ErrorWrite(trigger + "isn't current key");
				}
			}
		}

		
		//
		//Logs
		//
		/// <summary>
		/// ログを出力するかどうか
		/// </summary>
		public static bool LogActive{ get; set; } = true;
		
		private static void LogWrite(string mess){
			if (!LogActive) return;
			Debug.Log(mess);
		}

		private static void WarnWrite(string mess){
			if (!LogActive) return;
			Debug.LogWarning(mess);
		}

		private static void ErrorWrite(string mess){
			if (!LogActive) return;
			Debug.LogError(mess);
		}
    }
}