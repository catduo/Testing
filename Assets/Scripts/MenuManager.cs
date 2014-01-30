using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour, IJoviosPlayerListener, IJoviosControllerListener{
	
	public static Jovios jovios;
	
	void Start(){
		jovios = Jovios.Create();
		jovios.AddPlayerListener(this);
	}
	
	void OnGUI(){
		GUI.Box(new Rect(0,0,100,50), jovios.GetGameName());
		if(GUI.Button(new Rect(0,50,100,50), "Start Server")){
			jovios.StartServer();
		}
	}
	
	bool IJoviosPlayerListener.PlayerConnected(JoviosPlayer p){
		Debug.Log (p.GetPlayerName());
		JoviosControllerStyle controllerStyle = new JoviosControllerStyle();
		controllerStyle.AddAbsoluteJoystick("left", "woot!", "testButton2");
		controllerStyle.AddButton2("right", new string[] {"Press the button1!"}, new string[] {"testButton1"});
		controllerStyle.AddArbitraryButton(new int[] {-2, 6, 4, 4}, "https://lh3.googleusercontent.com/tkd1HiDTviukc9Gs-z3kb7WtLLVthq9rlNYRxZ2psDupR5EvuwFEqnK1-37t5XnGfw61KQV2qrI", "response");
		//controllerStyle.SetTextInput("What is your quest?", "Submit");
		//controllerStyle.SetAccelerometerStyle(JoviosControllerAccelerometerStyle.Full);
		jovios.SetControls(p.GetUserID(), controllerStyle);
		jovios.AddControllerListener(this);
		return false;
	}
	bool IJoviosPlayerListener.PlayerUpdated(JoviosPlayer p){
		Debug.Log (p.GetPlayerName());
		return false;
	}
	bool IJoviosPlayerListener.PlayerDisconnected(JoviosPlayer p){
		Debug.Log (p.GetPlayerName());
		return false;
	}
	
	bool IJoviosControllerListener.ButtonEventReceived(JoviosButtonEvent e){
		Debug.Log (e.GetResponse() + e.GetAction());
		//Debug.Log (e.GetControllerStyle().GetQuestionPrompt());
		return false;
	}
}
