


public class PlayButton : ButtonHelper
{
    public override void OnClicked()
    {
        print("OnCliked :" + gameObject.name);
        // 跳转GameScene
        // MenuManager

        RemoveListener();
    }
}