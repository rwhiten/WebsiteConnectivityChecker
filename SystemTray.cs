using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using WebsiteConnectivityChecker.Properties;

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MIT License
 *
 * Copyright (c) 2015 Reginald Whiten http://www.RWhiten.com/
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * ***** END LICENSE BLOCK *****
 */

namespace WebsiteConnectivityChecker
{
    public class SystemTray : ApplicationContext
    {
        private int                 _timerCheckInterval;
        private NotifyIcon          _systemTrayIcon;
        private AboutForm           _aboutForm;
        private SettingsForm        _settingsForm;
        private System.Timers.Timer _timerToCheckStatus;

        /// <summary>
        /// The class Constructor.
        /// </summary>
        public SystemTray()
        {
            InitializeContext();
            GetNetworkStatus();

            // Check network status when IP address or Network Adapter
            // status changes
            NetworkChange.NetworkAvailabilityChanged +=
                                                NetworkChange_NetworkAvailabilityChanged;
        }

        private enum AddressCheckMethod 
        { 
            Ping, 
            WebPageRequest 
        }

        private enum SysTrayStatus 
        { 
            Up, 
            Almost, 
            Down 
        }

        /// <summary>
        /// On exit, clean up / close forms and remove any lingering system tray icon
        /// </summary>
        protected override void ExitThreadCore()
        {
            if (_aboutForm != null)
            {
                _aboutForm.Close();
            }

            if (_settingsForm != null)
            {
                _settingsForm.Close();
            }

            _systemTrayIcon.Visible = false; 
            base.ExitThreadCore();
        }

        /// <summary>
        /// Create a timer with a set interval. Used to help periodically check the
        /// network status.
        /// </summary>
        private void AddressCheckTimer()
        {
            _timerToCheckStatus          = new System.Timers.Timer();
            _timerToCheckStatus.Elapsed  += TimerToCheckStatus_Elapsed;
            _timerToCheckStatus.Interval = _timerCheckInterval;
            _timerToCheckStatus.Start();
        }

        /// <summary>
        /// Method triggered when interval time is elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerToCheckStatus_Elapsed(
            object sender, 
            System.Timers.ElapsedEventArgs e)
        {
            GetNetworkStatus();
        }

        /// <summary>
        /// Method triggered when there is a change with the network.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetworkChange_NetworkAvailabilityChanged(
            object sender, 
            NetworkAvailabilityEventArgs e)
        {
            GetNetworkStatus();
        }

        /// <summary>
        /// Gets the network status as it pertains to being able to connect to all web
        /// addresses set in the settings and gateway IP addresses. First checks if
        /// you are connected to a network adapter, then if you are connected to each
        /// web address / IP and finally if you specified a gateway to check against.
        /// </summary>
        private void GetNetworkStatus()
        {
            // Dispose of timer and prepare to
            // reset the timer at the end of the method.
            if (_timerToCheckStatus != null)
            {
                _timerToCheckStatus.Stop();
                _timerToCheckStatus.Dispose();
            }

            var networkCard = GetNetworkCard();

            if (networkCard != null)
            {
                if (Settings.Default.WebAddressList != null)
                {
                    IList<string> addressesNotAvailable = new List<string>();

                    for (int i = 0; i < Settings.Default.WebAddressList.Count; i++)
                    {
                        var webAddress     = Settings.Default.WebAddressList[i];
                        var checkingMethod = Settings.Default.CheckingMethodList[i];

                        bool isAddressAvailable = IsNetworkAddressAvailable(
                                                    webAddress,
                                                    checkingMethod);

                        if (!isAddressAvailable)
                        {
                            addressesNotAvailable.Add(webAddress);
                        }
                    }

                    if (addressesNotAvailable.Count > 0)
                    {
                        Settings.Default.AddressesUnavailableList = 
                                                new List<string>(addressesNotAvailable);
                        Settings.Default.Save();

                        SetIcon(SysTrayStatus.Almost);
                        SetMouseoverText("Some addresses are not available."
                                            + "\nCheck Settings");
                    }
                    else
                    {
                        SetIcon(SysTrayStatus.Up);
                        SetMouseoverText("All addresses are available");
                    }

                    // Since addresses are up or almost up
                    // only check every 10 minutes (600000 ms)
                    _timerCheckInterval = 600000;
                }

                // If a gateway is set, check to see if you are connected to it.
                if (!string.IsNullOrEmpty(Settings.Default.GatewayToCheck))
                {
                    var networkGatewayIP = networkCard.GetIPProperties()
                                                      .GatewayAddresses.FirstOrDefault()
                                                      .Address.ToString();
                    if (Settings.Default.GatewayToCheck != networkGatewayIP)
                    {
                        SetIcon(SysTrayStatus.Down);
                        SetMouseoverText("You are not connected to your set Gateway");

                        // Check every 30 seconds if not connected to gateway
                        _timerCheckInterval = 30000;
                    }
                }
            }
            else
            {
                SetIcon(SysTrayStatus.Down);
                SetMouseoverText("You are not connected to a network Adapter");

                // Not connected to a network adapter so keep checking
                // every 10 seconds (10000 ms)
                _timerCheckInterval = 10000;
            }

            // Reinitalize timer with updated interval
            AddressCheckTimer();
            
            // Close and reopen the settings form if it was already open
            ReopenSettingsForm();
        }

        /// <summary>
        /// Helper method with an easy to understand name that sets the text when 
        /// hovering over the system tray icon.
        /// </summary>
        /// <param name="text"></param>
        private void SetMouseoverText(string text)
        {
            _systemTrayIcon.Text = text;
        }

        /// <summary>
        /// Helper Method to set the system tray icon.
        /// </summary>
        /// <param name="sysTrayStatus">Status of the system tray icon</param>
        private void SetIcon(SysTrayStatus sysTrayStatus)
        {
            switch (sysTrayStatus)
            {
                case SysTrayStatus.Up:
                    _systemTrayIcon.Icon = Resources.Green;
                    break;

                case SysTrayStatus.Almost:
                    _systemTrayIcon.Icon = Resources.Yellow;
                    break;

                case SysTrayStatus.Down:
                    _systemTrayIcon.Icon = Resources.Red;
                    break;

                default:
                    _systemTrayIcon.Icon = Resources.Red;
                    break;
            }
        }

        /// <summary>
        /// Checks if a web address is available by trying to see if the HTTP HEAD
        /// request retuns a status code of OK.
        /// </summary>
        /// <param name="address">Web or IP address to be checked</param>
        /// <param name="checkingMethod">
        /// Checking method to use (Ping or Web Request)
        /// </param>
        /// <returns>
        /// Returns True if the call to the checking method (either ping or HTTP WebPage
        /// Request) return True. False Otherwise.
        /// </returns>
        private bool IsNetworkAddressAvailable(string address, int checkingMethod)
        {
            switch (checkingMethod)
            {
                case (int)AddressCheckMethod.Ping:
                    return IsPingAvailable(address);

                case (int)AddressCheckMethod.WebPageRequest:
                    return IsWebPageRequestAvailable(address);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if a web address is available by trying to see if the HTTP HEAD
        /// request retuns a status code of OK.
        /// </summary>
        /// <param name="address">Web Address to check</param>
        /// <returns>
        /// True if the address parameter is reachable and returns HTTP status code
        /// OK / 200. False otherwise.
        /// </returns>
        private bool IsWebPageRequestAvailable(string address)
        {
            if (address.IndexOf("http://") < 0)
            {
                address = "http://" + address;
            }

            HttpWebRequest  webPageRequest  = null;
            HttpWebResponse webPageResponse = null;

            try
            {
                webPageRequest = (HttpWebRequest)WebRequest.Create(address);

                webPageRequest.Credentials                  = CredentialCache
                                                              .DefaultCredentials;
                webPageRequest.Method                       = "HEAD";
                webPageRequest.AllowAutoRedirect            = true;
                webPageRequest.MaximumAutomaticRedirections = 2;
                webPageRequest.Timeout                      = 3000;

                webPageResponse = (HttpWebResponse)webPageRequest.GetResponse();
                if (webPageResponse == null
                    || webPageResponse.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }

                return true;
            }
            catch (WebException)
            {
                return false;
            }
            finally
            {
                if (webPageResponse != null)
                {
                    webPageResponse.Close();
                }
            }
        }

        /// <summary>
        /// Checks if a web address or ip is abled to be pinged.
        /// </summary>
        /// <param name="address">Web Address to check</param>
        /// <returns>
        /// True if the address parameter is able to be pinged. False otherwise.
        /// </returns>
        private bool IsPingAvailable(string address)
        {
            var ping = new System.Net.NetworkInformation.Ping();
            try
            {
                var result = ping.Send(address, 2000);
                if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the current network interface card in use.
        /// </summary>
        /// <returns>
        /// The network interface card in use.
        /// </returns>
        private NetworkInterface GetNetworkCard()
        {
            var networkCardList = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkCard in networkCardList)
            {
                var defaultGateway = networkCard.GetIPProperties().GatewayAddresses
                                                                  .FirstOrDefault();

                if (defaultGateway != null
                    && networkCard.OperationalStatus    == OperationalStatus.Up
                    && networkCard.NetworkInterfaceType != NetworkInterfaceType.Loopback
                    && networkCard.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    // First one found meeting the conditions is the main
                    // adapter used to connect.
                    return networkCard;
                }
            }

            return null;
        }

        /// <summary>
        /// Initializes the Web Connectivity Checker system tray
        /// get the current status.
        /// </summary>
        private void InitializeContext()
        {
            var rightClickMenuStrip = new ContextMenuStrip();
            var aboutMenuItem       = new ToolStripMenuItem("About");
            var settingsMenuItem    = new ToolStripMenuItem("Settings");
            var checkNowMenuItem    = new ToolStripMenuItem("Check Now");
            var exitMenuItem        = new ToolStripMenuItem("Exit");

            aboutMenuItem.Click    += AboutItem_Clicked;
            settingsMenuItem.Click += SettingsMenuItem_Click;
            checkNowMenuItem.Click += CheckNowMenuItem_Click;
            exitMenuItem.Click     += ExitItem_Click;

            rightClickMenuStrip.Items.Add(aboutMenuItem);
            rightClickMenuStrip.Items.Add(settingsMenuItem);
            rightClickMenuStrip.Items.Add(checkNowMenuItem);
            rightClickMenuStrip.Items.Add(exitMenuItem);

            _systemTrayIcon = new NotifyIcon()
            {
                ContextMenuStrip = rightClickMenuStrip,
                Icon             = Resources.Green,
                Text             = "Website  Connectivity Checker",
                Visible          = true
            };

            _timerCheckInterval = 10000;
        }

        /// <summary>
        /// When the "Check Now" menu item is clicked, runs GetNetworkStatus to
        /// get the current status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNowMenuItem_Click(object sender, EventArgs e)
        {
            GetNetworkStatus();
        }

        /// <summary>
        /// Closes and reopens the settings form. Used when checking the network status
        /// and the settings menu is open.
        /// </summary>
        private void ReopenSettingsForm()
        {
            if (_settingsForm != null)
            {
                _settingsForm.Close();
                _settingsForm            =  new SettingsForm();
                _settingsForm.FormClosed += SettingsForm_FormClosed;
                _settingsForm.Show();
            }
        }

        /// <summary>
        /// Shows the "Settings" windows form for Web Connectivity Checker when the 
        /// settings menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (_settingsForm == null)
            {
                _settingsForm            =  new SettingsForm();
                _settingsForm.FormClosed += SettingsForm_FormClosed;
                _settingsForm.Show();
            }
            else
            {
                _settingsForm.Activate();
            }
        }

        /// <summary>
        /// When the settings form window is closed, make sure the variable 
        /// is set to null and the object is collected by the garbage collector.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settingsForm = null;
        }

        /// <summary>
        /// Shows the "About" windows form for Web Connectivity Checker when the 
        /// about menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutItem_Clicked(object sender, EventArgs e)
        {
            if (_aboutForm == null)
            {
                _aboutForm            =  new AboutForm();
                _aboutForm.FormClosed += AboutForm_FormClosed;
                _aboutForm.Show();
            }
            else
            {
                _aboutForm.Activate();
            }
        }

        /// <summary>
        /// When the about form window is closed, make sure the variable is set to null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _aboutForm = null;
        }

        /// <summary>
        /// When the exit menu item is clicked, make a call to terminate the 
        /// ApplicationContext.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitItem_Click(object sender, EventArgs e)
        {
            ExitThread();
        }
    }
}