using MudBlazor;

namespace Illegible_Cms_V2.Client.Shared;
public partial class MainLayout
{
    #region default theme setting

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
        },
        Typography = new Typography()
        {
            H4 = new H4()
            {
                FontFamily = new[] { "Helvetica", "Arial", "sans-serif" },
                FontSize = "1.25rem",
                FontWeight = 500,
                LineHeight = 1.6,
                LetterSpacing = ".0075em"
            }
        }
    };

    #endregion


    #region Main Layout ations

    private bool _sidebarOpen = true;
    private void ToggleTheme(MudTheme changedTheme) => _currentTheme = changedTheme;
    private void ToggleSidebar() => _sidebarOpen = !_sidebarOpen;

    public bool _rtl { get; set; }
    private void ToggleRTL(bool rtl) => _rtl = rtl;

    #endregion

}