using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Extensions
{
    public static class NavigationManagerExtensions
    {        
        public static string GetCurrentPageUrl(this NavigationManager navigationManager) =>
            $"/{navigationManager.Uri.Replace(navigationManager.BaseUri, "").TrimStart('/')}";

        public static void GoToInnerPage(this NavigationManager navigationManager, string innerPageUrl)
        {
            navigationManager.NavigateTo(innerPageUrl, new NavigationOptions
            {
                HistoryEntryState = navigationManager.GetCurrentPageUrl()
            });
        }

        public static void GoBack(this NavigationManager navigationManager, string? fallbackUrl = "/home")
        {
            var previousPageUrl = navigationManager.HistoryEntryState ?? fallbackUrl;
            navigationManager.NavigateTo(previousPageUrl, new NavigationOptions
            {
                HistoryEntryState = null,
                ReplaceHistoryEntry = true
            });
        }
    }
}
