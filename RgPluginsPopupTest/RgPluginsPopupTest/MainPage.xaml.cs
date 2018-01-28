using Rg.Plugins.Popup.Services;
using Reactive.Bindings;
using Xamarin.Forms;

namespace RgPluginsPopupTest
{
	public partial class MainPage : ContentPage
	{
        public ReactiveCommand AlertCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActionSheetCommand { get; } = new ReactiveCommand();
        public ReactiveCommand PopupCommand { get; } = new ReactiveCommand();
        public ReactiveCommand TransitionCommand { get; } = new ReactiveCommand();

        public MainPage()
		{
			InitializeComponent();

            AlertCommand.Subscribe(() => DisplayAlert("タイトル", "メッセージ", "OK"));
            ActionSheetCommand.Subscribe(() => DisplayActionSheet("選択してね", "キャンセル", "削除", "編集", "コピー", "貼り付け"));
            PopupCommand.Subscribe(() => PopupNavigation.PushAsync(new PopUp(true, false)));
            TransitionCommand.Subscribe(() => App.Current.MainPage = new PopUp(false, true));
        }
    }
}
