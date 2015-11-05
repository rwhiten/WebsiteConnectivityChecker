# Website Connectivity Checker
Simple system tray website connectivity checker

This system tray application checks for websites or IP addresses added to its settings list. Once it has confirmed that a website is up, it will continue to check every 10 minutes. If the network is down it will check every 10 seconds until reconnected. If there is a network change, such as changing IP address or connection, it will instantly recheck the addresses in the list. 

The icon for this program is color coded. Red means you are not connected to a network adapter (Network Interface Card). Yellow means you are connected to an adapter, but some or all of the addresses in your settings were unreachable. Green means everything is working fine and you are connected to all addresses.

## Checking Methods
This program allows you to check addresses by either an HTTP Web Request (HEAD) or by Ping. This enables you to also check for services or other addresses which may not actually be a web page. 

## Gateway Checking
If you want to make sure you are connected to a certain gateway or router you can also enter a gateway IP to be checked.

## How to use
This program is useful as a way of quickly knowing if all web addresses or services are up on a system without having to manually check. It is also helpful to those who may not be very computer savvy in letting them know if they have network issues with addresses they frequently visit or need to use.

Once compiled, launch Website Connectivity Checker. Right click on the system tray Icon to access the menu. Select the settings and add all addresses you would like. Thats it. The icon will change when there are connection problems to the addresses and hovering over the icon will display more information.

### Right Click Menu Options
1. About - Display author information
2. Settings - Form for specifying addresses and gateway to check
3. Check Now - Runs the actual checking of addresses on click
4. Exit - Exit the application
