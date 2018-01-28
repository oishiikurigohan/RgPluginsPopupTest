using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Reactive.Bindings;

namespace RgPluginsPopupTest
{
    public partial class PopUp : PopupPage
    {
        public ReactiveProperty<bool> IsPopup { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsPage { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<string[]> Items { get; } = new ReactiveProperty<string[]>();
        public ReactiveProperty<string> ImageTitle { get; } = new ReactiveProperty<string>("栗きんとぅん");
        public ReactiveProperty<ImageSource> KumaSource { get; } = new ReactiveProperty<ImageSource>("asahi.png");
        public ReactiveCommand CloseCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BackCommand { get; } = new ReactiveCommand();

        public PopUp (bool isPopup, bool isPage)
		{
			InitializeComponent ();

            CloseCommand.Subscribe(() => PopupNavigation.PopAsync());
            BackCommand.Subscribe(() => App.Current.MainPage = new MainPage());
            Items.Value = new string[] { "001 -- ika", "002 -- tako", "003 -- wakame" };
            this.IsPopup.Value = isPopup;
            this.IsPage.Value = isPage;
        }

        // 普通のページとして表示されているとき、デバイスの「戻る」ボタンに対応
        protected override bool OnBackButtonPressed()
        {
            if(IsPage.Value) App.Current.MainPage = new MainPage();
            return true;
        }
    }
}