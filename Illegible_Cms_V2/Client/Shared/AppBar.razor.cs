﻿using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Illegible_Cms_V2.Client.Shared;
public partial class AppBar
{
    [Parameter]
    public EventCallback OnSidebarToggled { get; set; }
}