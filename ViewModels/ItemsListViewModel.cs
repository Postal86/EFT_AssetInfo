using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models;
using ETFHelper_WPF.Models.Tarkov_Tools;
using ETFHelper_WPF.Services;
using MahApps.Metro.Controls;

namespace ETFHelper_WPF.ViewModels
{
    public class ItemsListViewModel : ScreenBase
    {
        #region ველები

        private readonly  TarkovToolsService? _talovToolsService;
        private readonly SettingsService? _settingsService;
        private bool _isBusy = false;
        private int _pageIndex = 0;
        private int _pageSize = 50;
        private bool _listenScroll = true;
        private string? _query;
        private readonly object pageLock = new();
        private List<ItemTypeViewModel> _itemTypes;
        private ItemTypeViewModel _selectedType;
        private ObservableCollection<ItemBaseViewModel> _displayedItems;
        private List<ItemBaseViewModel> _items;
        private ItemDetailViewModel _itemDetailViewModel;

        #endregion

        #region კონსტრუქტორი

        public ItemsListViewModel(
            TarkovToolsService tarkovToolsService,
            SettingsService settingsService)
        {
            _talovToolsService = tarkovToolsService;
            _settingsService = settingsService;
            ItemTypes = EnumHelper.GetEnumValues<ItemTypes>().Select(x => new ItemTypeViewModel(x)).ToList();
        }


        #endregion

        #region თვისებები

        public bool TopMost => _settingsService.TopMost;

        public List<ItemTypeViewModel> ItemTypes
        {
            get => _itemTypes;
            set
            {
                _itemTypes = value;
                NotifyOfPropertyChange();
            }
        }

        public ItemTypeViewModel SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => SelectedTypeName);
            }
        }

        public string SelectedTypeName => SelectedType.Title;
            
        public ObservableCollection<ItemBaseViewModel>  DisplayedItems
        {
            get => _displayedItems;
            set
            {
                if (value  != null)
                {
                    _displayedItems = value;
                    NotifyOfPropertyChange();
                }
            }
        }

        public bool IsBusy
        {
            get => _isBusy; 

            set
            {
                _isBusy = value;
                NotifyOfPropertyChange();
            }
        }

        public string  Query
        {
            get => _query;

            set
            {
                _query = string.IsNullOrEmpty(value) ? string.Empty : value;
                NotifyOfPropertyChange();
            }
        }

        public ItemDetailViewModel ItemDetailViewModel
        {
            get => _itemDetailViewModel;
            set
            {
                _itemDetailViewModel = value;
                NotifyOfPropertyChange();
            }
        }


        #endregion

        #region მეთოდები

        public override  async  void MenuSelectionChanged(IMenuItem  item)
        {
            var clickedType = item as ItemTypeViewModel;
            if (clickedType is not null)
            {
                SelectedType = clickedType;
            }

            await RefreshDisplayedItemsAsync(clearQuery: true);
        }


        public async void OnItemClicked(ItemBaseViewModel  itemClicked)
        {
            if (itemClicked is null ||  (ItemDetailViewModel is not null &&  itemClicked.Id == ItemDetailViewModel.Id))
            {
                return;
            }

            IsBusy = true;
            var itemById = await _talovToolsService.GetItemByIdAsync(itemClicked.Id);
            ItemDetailViewModel = new ItemDetailViewModel(itemById.Item);
            IoC.Get<FlyoutService>().Show(ItemDetailViewModel.ShortName, ItemDetailViewModel, Position.Right);
            IsBusy = false;
        }

        public void OnScroll(System.Windows.Controls.ScrollChangedEventArgs scrollEvent)
        {
            if(!_listenScroll)
            {
                _listenScroll = true;
                return;
            }

            var position = scrollEvent.VerticalOffset + scrollEvent.ViewportHeight;
            var heightThreshold = scrollEvent.ViewportHeight / 1.1;

            if (position >= heightThreshold)
            {
                if (Monitor.TryEnter(pageLock))
                {
                    try
                    {
                        DisplayNextPage();
                    }
                    finally
                    {
                        Monitor.Exit(pageLock);
                    }
                }

            }
        }

        public override HamburgerMenuInformation GetHamburgerMenuInformation()
        {
            return new HamburgerMenuInformation
            {
                Items = ItemTypes.Cast<IMenuItem>(),
                Header = "Item Types",
                SelectedItem = SelectedType,
           };

        }


        public async void Search(EventArgs args)
        {
            if (!string.IsNullOrEmpty(Query))
            {
                await RefreshDisplayedItemsAsync(false);
            }
        }

        private void DisplayNextPage()
        {
            if (DisplayedItems.Count >= _items.Count)
            {
                return;
            }

            var newItems = _items.Skip(_pageIndex * _pageSize).Take(_pageSize);
            foreach( var item in newItems)
            {
                DisplayedItems.Add(item);
            }

            _pageIndex++;
        }

        private void Clear(bool clearQuery)
        {
            DisplayedItems.Clear();
            _listenScroll = false;
            _pageIndex = 0;

            if (clearQuery)
            {
                Query = string.Empty;
            }
        }

        private Task RefreshDisplayedItemsAsync(bool clearQuery)
        {
            return RefreshDisplayedItems(clearQuery).ContinueWith((t) => IsBusy = false);
        }

        private Task RefreshDisplayedItemAsync(bool clearQuery)
        {
            return RefreshDisplayedItems(clearQuery).ContinueWith((t) => IsBusy = false);
        }

        private async Task RefreshDisplayedItems(bool clearQuery)
        {
            IsBusy = true;
            Clear(clearQuery);
            _items = await GetItemsAsync();
            DisplayNextPage();
        }

        private Task<List<ItemBaseViewModel>> GetItemsAsync()
        {
            return !string.IsNullOrEmpty(Query) ?
                GetItemsByQueryAsync() :
                GetItemsByTypeAsync();
        }

        private async Task<List<ItemBaseViewModel>> GetItemsByQueryAsync()
        {
            var itemsByNameResponse = await _talovToolsService.GetItemsByNameAsync<ItemBase>(Query);
            var items = itemsByNameResponse.ItemsByName;
            var itemViewModels = items.Select(x => new ItemBaseViewModel(x, OnItemClicked)).ToList();
            if (SelectedType.ItemType != Enums.ItemTypes.Any)
            {
                itemViewModels = RemoveItemsWithoutType(itemViewModels, SelectedType.ItemType);
            }

            return RemoveItemsWithDisabledTypes(itemViewModels);
        }

        private async  Task<List<ItemBaseViewModel>> GetItemsByTypeAsync()
        {
            var itemsByTypeResponse = await _talovToolsService.GetItemsByTypeAsync(SelectedType.ItemType);

            var items = itemsByTypeResponse.ItemsByType;

            return RemoveItemsWithDisabledTypes(items.Select(x => new ItemBaseViewModel(x, OnItemClicked)).ToList());
        }

        private List<ItemBaseViewModel>  RemoveItemsWithDisabledTypes(List<ItemBaseViewModel> items)
        {
            return RemoveItemsWithTypes(items, GetDisabledTypes());
        }

        private List<ItemBaseViewModel> RemoveItemsWithTypes(List<ItemBaseViewModel> items, List<ItemTypes> itemTypes)
        {
            return items.Except(items.Where(x => x.Types.Any(z => itemTypes.Contains(z)))).ToList();
        }

        private List<ItemBaseViewModel> RemoveItemsWithoutType(List<ItemBaseViewModel> items, ItemTypes itemType)
        {
            return items.Except(items.Where(x => !x.Types.Any(z => z == itemType))).ToList();
        }

        private List<ItemTypes> GetDisabledTypes()
        {
            return new List<ItemTypes>
        {
            Enums.ItemTypes.Disabled,
            Enums.ItemTypes.UnLootable,
            Enums.ItemTypes.Preset
        };
        }

        #endregion

    }
}
