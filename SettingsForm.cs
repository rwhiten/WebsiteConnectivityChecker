using System;
using System.Collections.Generic;
using System.Net;
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
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// The class constructor.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// Initialize the settings form with user saved settings loaded.
        /// </summary>
        private void InitializeForm()
        {
            // Initialize settings if there are not any
            if (Settings.Default.WebAddressList == null
                || Settings.Default.CheckingMethodList == null)
            {
                Settings.Default.WebAddressList           = new List<string>();
                Settings.Default.CheckingMethodList       = new List<int>();
                Settings.Default.AddressesUnavailableList = new List<string>();
                Settings.Default.Save();
            }

            // Initialize web address list from saved settings
            if (Settings.Default.WebAddressList != null)
            {
                for (int i = 0; i < Settings.Default.WebAddressList.Count; i++)
                {
                    string address = Settings.Default.WebAddressList[i];

                    int unavailable = Settings.Default
                                            .AddressesUnavailableList.IndexOf(address);

                    string addressAvailable = unavailable < 0 ? "Yes" : "No";

                    string[] addressToAdd = { address, "Web Request", addressAvailable};

                    // 0 is for ping. If the checking method is ping
                    // change the addressToAdd variable to reflect it
                    if (Settings.Default.CheckingMethodList[i] == 0)
                    {
                        addressToAdd[1] = "Ping";
                    }

                    addressListView.Items.Add(new ListViewItem(addressToAdd));
                }
            }

            // Initialize the gateway address
            if (!string.IsNullOrEmpty(Settings.Default.GatewayToCheck))
            {
                gatewaySetLb.Text = Settings.Default.GatewayToCheck;
            }
            else
            {
                gatewaySetLb.Text = "Gateway IP not set";
            }
        }

        /// <summary>
        /// Empty Method. Required for table layout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Empty Method
        }

        /// <summary>
        /// Adds a web address to the list of web addresses to check.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAddressBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(webAddressTxtBox.Text))
            {
                // Add to form
                string[] addressToAdd = 
                { 
                    webAddressTxtBox.Text, 
                    "Web Request", 
                    "Not Checked Yet" 
                };

                if (isPingChkBox.Checked)
                {
                    addressToAdd[1] = "Ping";
                }

                addressListView.Items.Add(new ListViewItem(addressToAdd));

                // Save to user settings
                Settings.Default.WebAddressList.Add(addressToAdd[0]);

                if (addressToAdd[1] == "Web Request")
                {
                    Settings.Default.CheckingMethodList.Add(1);
                }
                else
                {
                    Settings.Default.CheckingMethodList.Add(0);
                }

                Settings.Default.Save();

            }
            else
            {
                MessageBox.Show("Please enter a web address or IP");
            }
        }

        /// <summary>
        /// Removes a web address from this list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rmvAddressBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedAddress in addressListView.SelectedItems)
            {
                addressListView.Items.Remove(selectedAddress);

                // Remove from settings
                int indexToRemove = Settings.Default.WebAddressList
                                                    .IndexOf(selectedAddress.Text);

                Settings.Default.WebAddressList.RemoveAt(indexToRemove);
                Settings.Default.CheckingMethodList.RemoveAt(indexToRemove);
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Set the gateway IP address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gatewaySetBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            bool isValidGateway = IPAddress.TryParse(gatewayTxtBox.Text, out ip);

            if (isValidGateway || string.IsNullOrEmpty(gatewayTxtBox.Text))
            {
                Settings.Default.GatewayToCheck = gatewayTxtBox.Text;
                Settings.Default.Save();

                if (!string.IsNullOrEmpty(Settings.Default.GatewayToCheck))
                {
                    gatewaySetLb.Text = Settings.Default.GatewayToCheck;
                }
                else
                {
                    gatewaySetLb.Text = "Gateway Not Set";
                }
            }
            else
            {
                MessageBox.Show("Invalid IP Address");
            }
        }
    }
}