using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : SingletonBase< SceneControll >
{
	enum State
	{
		FadeIn,
		FadeOut,

		Update,

		Max,
	}
	private StateMachine< State >stateMachine = null;

	private string nextSceneName = null;

	private FadeParam fadeParam = null;

	private bool isLoadScene = false;

	private SceneBase currentScene = null;

	[RuntimeInitializeOnLoadMethod]
	static new void  Initialize()
	{
		SystemMain.Instance.Initialize();
		_ = SceneControll.Instance;
	}

	public void Start()
	{
		// インスタンス作っとく
		

		FadeControll.Instance.Initialize();

		stateMachine = new StateMachine<State>();
		stateMachine.Initialize( (int)State.Max );

		stateMachine.AddState( State.FadeIn, UpdateFadeIn);
		stateMachine.AddState( State.FadeOut, UpdateFadeOut);
		stateMachine.AddState( State.Update, UpdateSub);
		
		SceneManager.sceneUnloaded += FinishUnLoad; 
		SceneManager.sceneLoaded　+= FinishLoad;
		
		ChangeScene("Scene1");
	}



	/// <summary>
	/// アップデート
	/// </summary>
	private void Update()
	{
		SystemMain.Instance.UpdateSub();
		FadeControll.Instance.UpdateSub();
		stateMachine?.UpdateSub();
	}



	/// <summary>
	/// シーン変更
	/// </summary>
	/// <param name="sceneName"></param>
	public void ChangeScene( string nextSceneName_, FadeParam fadeParam_ = null )
    {
		fadeParam = fadeParam_;
		if ( fadeParam == null )
		{
			fadeParam = FadeControll.FadeWhite;
		}
		nextSceneName = nextSceneName_;
    }

	/// <summary>
	/// フェードIn
	/// </summary>
	public void UpdateFadeIn()
	{
		switch ( stateMachine.Phase )
		{
		case 0:
			SceneManager.LoadScene( nextSceneName );
			stateMachine.StepPhase();
			break;
		case 1:
			if ( !isLoadScene )
			{
				stateMachine.StepPhase();
			}
			break;
		case 2:
			currentScene?.Initialize();
			FadeControll.Instance.PlayIn( fadeParam );
			stateMachine.StepPhase();
			break;

		case 3:
			if ( FadeControll.Instance.IsPlaying() )
			{
				stateMachine.ChangeState( State.Update );
			}
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// フェードアウト
	/// </summary>
	public void UpdateFadeOut()
	{
		switch ( stateMachine.Phase )
		{
		// フェード
		case 0:
			FadeControll.Instance.PlayOut( fadeParam );
			stateMachine.StepPhase();
			break;
		//フェード待ち
		case 1:
			if ( FadeControll.Instance.IsPlaying() )
			{
				stateMachine.StepPhase();
			}
			break;

		case 2:
			isLoadScene = true;

			currentScene?.Release();
			stateMachine.StepPhase();
			break;

		case 3:
			if ( !isLoadScene )
			{
				stateMachine.ChangeState( State.FadeIn );
			}
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// アップデート
	/// </summary>
	public override void UpdateSub()
	{
		currentScene?.UpdateSub();
	}

	/// <summary>
	/// シーン終了時
	/// </summary>
	/// <param name="scene"></param>
	private void FinishUnLoad( Scene scene )
	{
		Debug.Log( "アンロード" + scene.name );
	}

	/// <summary>
	/// シーン終了時
	/// </summary>
	/// <param name="scene"></param>
	private void FinishLoad( Scene nextScene, LoadSceneMode mode )
	{
		Debug.Log( "ロード" + nextScene.name );
		isLoadScene = false;
		currentScene = FindObjectOfType< SceneBase >();
	}
}
