﻿using ETFHelper_WPF.Services;
using ETFHelper_WPF.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System.Reflection;

namespace ETFHelper_WPF.Models
{
    public class SettingMenuItem : IMenuItem
    {
        private FlyoutService? _flyoutService;
        private SettingsViewModel? _settingsViewModel;

        public SettingMenuItem(
            FlyoutService? flyoutService, SettingsViewModel? settingsViewModel)
        {
            _flyoutService = flyoutService;
            _settingsViewModel = settingsViewModel;
            Label = "Settings";
            Title = "Settings";
            Icon = new PackIconMicrons() { Kind = PackIconMicronsKind.Cog, Height = 40, Width = 40 };
        }

        public string Label { get; set; }

        public string Title { get; set; }   

        public object Icon { get; set; }


        public System.Action? OnClick => () => _flyoutService.Show(Title, _settingsViewModel, Position.Right);
    }
}
