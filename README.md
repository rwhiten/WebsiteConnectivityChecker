# Website Connectivity Checker
Simple system tray website connectivity checker

This system tray application checks for websites or IP addresses added to its settings list. Once it has confirmed that a website is up, it will continue to check every 10 minutes. If there is a network change, such as changing IP address or connection, it will instantly recheck the addresses in the list. 

The icon for this program is color coded. Red means you are not connected to a network adapter (Network Interface Card). Yellow means you are connected to an adapter, but some or all of the addresses in your settings were unreachable. Green means everything is working fine and you are connected to all addresses.

## Checking Methods
This program allows you to check addresses by either an HTTP Web Request (HEAD) or by Ping. This enables you to also check for services or other addresses which may not actually be a web page. 

## Gateway Checking
If you want to make sure you are connected to a certain gateway or router you can also enter a gateway IP to be checked.
