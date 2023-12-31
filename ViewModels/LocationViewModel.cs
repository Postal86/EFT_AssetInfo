﻿using Caliburn.Micro;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Models;
using MahApps.Metro.IconPacks;


namespace ETFHelper_WPF.ViewModels;

public class LocationViewModel : PropertyChangedBase, IMenuItem
{
    #region კონსტანტები

    private const string ImageUrlBase = "https://raw.githubusercontent.com/ZeQuyk/EFTHelper/main/src/Images";

    #endregion

    #region კონსტრუქტორი

    public LocationViewModel(Locations location)
    {
        var locationName = location.ToString();
        Name = locationName.ToSentence();
        ImagePath = $"{ImageUrlBase}/{locationName.ToLower()}.jpg";
        Icon = BuildIcon(location);
    }

    #endregion


    #region თვისებები

    public string? Name { get; set; }   

    public string? ImagePath { get; set; }

    public string? Label => Name.Substring(0, 1);

    public string? Title => Name;

    public object? Icon { get; set; }

    public System.Action? OnClick => null;

    #endregion


    #region მეთოდები

    private static PackIconBase BuildIcon(Locations location)
    {
        PackIconBase? icon = location switch
        {
            Locations.Customs => new PackIconMaterial() { Kind = PackIconMaterialKind.PoliceBadgeOutline },
            Locations.Factory => new PackIconMaterialLight() { Kind = PackIconMaterialLightKind.Factory },
            Locations.Interchange => new PackIconUnicons() { Kind = PackIconUniconsKind.ShoppingCart },
            Locations.Lighthouse => new PackIconRPGAwesome() { Kind = PackIconRPGAwesomeKind.Lighthouse },
            Locations.Reserve => new PackIconBoxIcons() { Kind = PackIconBoxIconsKind.RegularTrain },
            Locations.Shoreline => new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.HotelSolid },
            Locations.TheLab => new PackIconUnicons { Kind = PackIconUniconsKind.Flask },
            Locations.Woods => new PackIconMaterial() { Kind = PackIconMaterialKind.Forest },
            Locations.StreetsOfTarkov => new PackIconMaterial() { Kind = PackIconMaterialKind.Road },
            _ => null,
        };

        if (icon != null)
        {
            icon.Width = 24;
            icon.Height = 24;
        }

        return icon;
    }

    #endregion
}
