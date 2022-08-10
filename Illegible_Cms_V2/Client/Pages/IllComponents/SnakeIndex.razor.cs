using Microsoft.AspNetCore.Components;

namespace Illegible_Cms_V2.Client.Pages.IllComponents;

public partial class SnakeIndex
{
    [Parameter]
    public string? TextItemOne { get; set; }

    [Parameter]
    public string? TextItemTwo { get; set; }

    [Parameter]
    public string? TextItemThree { get; set; }

    [Parameter]
    public string? TextItemFour { get; set; }
}
