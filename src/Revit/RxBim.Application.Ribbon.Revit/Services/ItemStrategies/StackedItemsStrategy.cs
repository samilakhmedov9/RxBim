﻿namespace RxBim.Application.Ribbon.Services.ItemStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;
    using Autodesk.Revit.UI;
    using Di;

    /// <summary>
    /// Implementation of <see cref="IItemStrategy"/> for stacked items.
    /// </summary>
    public class StackedItemsStrategy : ItemStrategyBase<StackedItems>
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly IRibbonPanelItemService _ribbonPanelItemService;
        private List<IItemStrategy>? _strategies;

        /// <inheritdoc />
        public StackedItemsStrategy(IServiceLocator serviceLocator, IRibbonPanelItemService ribbonPanelItemService)
        {
            _serviceLocator = serviceLocator;
            _ribbonPanelItemService = ribbonPanelItemService;
        }

        private IEnumerable<IItemStrategy> Strategies =>
            _strategies ??= _serviceLocator.GetServicesAssignableTo<IItemStrategy>().ToList();

        /// <inheritdoc />
        protected override void AddItem(string tabName, RibbonPanel ribbonPanel, StackedItems stackedItems)
        {
            var button1 = GetStackedItem(stackedItems.Items[0]);
            var button2 = GetStackedItem(stackedItems.Items[1]);

            IList<RibbonItem> addedItems;
            switch (stackedItems.Items.Count)
            {
                case 2:
                    addedItems = ribbonPanel.AddStackedItems(button1, button2);
                    break;
                case 3:
                    var button3 = GetStackedItem(stackedItems.Items[2]);
                    addedItems = ribbonPanel.AddStackedItems(button1, button2, button3);
                    break;
                default:
                    throw new InvalidOperationException("The stack size can only be 2 or 3!");
            }

            for (var i = 0; i < stackedItems.Items.Count; i++)
            {
                if (stackedItems.Items[i] is PullDownButton buttonConfig &&
                    addedItems[i] is PulldownButton addedButton)
                {
                    _ribbonPanelItemService.CreateButtonsForPullDown(buttonConfig, addedButton);
                }
            }
        }

        /// <inheritdoc />
        protected override RibbonItemData GetItemForStack(StackedItems itemConfig)
        {
            return _ribbonPanelItemService.CannotBeStackedStub(itemConfig);
        }

        private RibbonItemData GetStackedItem(IRibbonPanelItem firstItem)
        {
            var strategy = GetStrategy(firstItem);
            return (RibbonItemData)strategy.GetItemForStack(firstItem);
        }

        private IItemStrategy GetStrategy(IRibbonPanelItem firstItem)
        {
            var strategy = Strategies.FirstOrDefault(x => x.IsApplicable(firstItem));
            if (strategy is null)
                throw new InvalidOperationException($"Can't found strategy for: {firstItem.GetType().FullName}");
            return strategy;
        }
    }
}