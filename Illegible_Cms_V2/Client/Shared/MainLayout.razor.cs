using MudBlazor;

namespace Illegible_Cms_V2.Client.Shared;
public partial class MainLayout
{
    // default theme
    private MudTheme _currentTheme = new MudTheme
    {
        Palette = new Palette()
        {
            Black = "#27272f",
            Background = "#32333d",
            BackgroundGrey = "#27272f",
            Surface = "#373740",
            TextPrimary = "#ffffffb3",
            TextSecondary = "rgba(255,255,255, 0.50)",
            AppbarBackground = "#27272f",
            AppbarText = "#ffffffb3",
            DrawerBackground = "#27272f",
            DrawerText = "#ffffffb3",
            DrawerIcon = "#ffffffb3"
        }
    };
    private bool _sidebarOpen = true;
    private void ToggleTheme(MudTheme changedTheme) => _currentTheme = changedTheme;
    private void ToggleSidebar() => _sidebarOpen = !_sidebarOpen;

    public bool _rtl { get; set; }
    private void ToggleRTL(bool rtl) => _rtl = rtl;

}