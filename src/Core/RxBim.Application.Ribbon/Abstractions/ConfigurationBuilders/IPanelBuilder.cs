﻿namespace RxBim.Application.Ribbon
{
    using System;

    /// <summary>
    /// Defines a ribbon panel.
    /// </summary>
    public interface IPanelBuilder : IRibbonItemsContainerBuilder
    {
        /// <summary>
        /// Building panel
        /// </summary>
        Panel BuildingPanel { get; }

        /// <summary>
        /// Adds a new push button to the panel.
        /// </summary>
        /// <param name="name">Internal name of the button.</param>
        /// <param name="commandType">Class which implements IExternalCommand interface.
        ///     This command will be execute when user push the button.</param>
        /// <param name="builder">The button builder.</param>
        /// <returns>Panel where button were created.</returns>
        IPanelBuilder CommandButton(
            string name,
            Type commandType,
            Action<ICommnadButtonBuilder>? builder = null);

        /// <summary>
        /// Adds a new Stacked items on the panel.
        /// </summary>
        /// <param name="builder">The stacked items builder.</param>
        /// <returns>Panel where stacked items were created.</returns>
        IPanelBuilder StackedItems(Action<IStackedItemsBuilder> builder);

        /// <summary>
        /// Adds a new pull down button on the panel.
        /// </summary>
        /// <param name="name">Internal name of the button.</param>
        /// <param name="builder">A pull-down button builder.</param>
        /// <returns>Panel where button were created.</returns>
        IPanelBuilder PullDownButton(string name, Action<IPulldownButtonBuilder> builder);

        /// <summary>
        /// Adds a new separator to the panel.
        /// </summary>
        IPanelBuilder Separator();

        /// <summary>
        /// Adds a new switch for the sliding part of the panel.
        /// </summary>
        IPanelBuilder SlideOut();
    }
}