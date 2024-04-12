# Custom IAP System Implementation

This Unity project demonstrates a custom implementation of in-app purchases (IAPs) using Unity's purchasing API. The project includes scripts and UI elements for purchasing virtual items within a game, such as coins, unlockable items, and subscriptions.

## Overview

The custom IAP system is designed to provide developers with more control and flexibility over their in-app purchase implementation compared to Unity's codeless IAP system. The `StoreManager` script manages the purchasing process, while the `StoreUIManager` script handles UI elements and player interaction.

## Features

- **Custom Purchase Handling**: Implements custom logic for handling purchase events and updating player inventory based on purchased items.
- **Product Configuration**: Dynamically configures in-app products and their types (e.g., consumable, non-consumable, subscription) based on defined product IDs.
- **Flexible Integration**: Allows developers to integrate custom UI elements and logic to provide a tailored in-app purchase experience for players.

## Usage

To use the custom IAP system in your Unity project:

1. **Import Scripts**: Import the `StoreManager.cs` and `StoreUIManager.cs` scripts into your Unity project.
2. **Configure In-App Products**: Define your in-app product IDs and types (e.g., consumable, non-consumable, subscription) in the `InAppProducts` list of the `StoreManager` script.
3. **Set Up UI Elements**: Assign UI elements such as text fields, buttons, and images to the corresponding variables in the `StoreUIManager` script.
4. **Customize Purchase Logic**: Customize the `BuyProduct` and `PurchaseSuccess` methods in the `StoreManager` script to handle purchase events and update player inventory as needed.
5. **Test and Deploy**: Test the custom IAP functionality within the Unity Editor using Unity's testing tools. Once satisfied, build and deploy your project to your target platform.

## Dependencies

- Unity Engine (version 2021.3.25f)
