﻿using Ait.IPCalculator.Core.Entities;
using Ait.IPCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Ait.IPCalculator.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ConvertService convertService;
        public List<SubnetMask> subnetMasks;
        string selectedSubnetMask;

        public MainWindow()
        {
            InitializeComponent();
            convertService = new ConvertService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubnetMaskService.InitialiseList();
            subnetMasks = SubnetMaskService.SubMasks;
            cmbSubnet.Items.Clear();

            //combobox opvullen bij het laden
            foreach(SubnetMask subnetMask in subnetMasks)
            {
                cmbSubnet.Items.Add(subnetMask);
            }
            cmbSubnet.SelectedIndex = 24;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();

            //Ip adres in een string array
            string ipDecimal = txtIP.Text;
            string[] separateIpDec = ipDecimal.Split('.');

            //Ip omzetten naar binaire notatie
            string resultstringIP = convertService.ForeachToBinary(separateIpDec);
            txtIPBit.Text = resultstringIP;

            //type netwerk bepalen
            string typeNetwork = convertService.CheckTypeOfNetworkadd(ipDecimal);
            txtNetworkType.Text = typeNetwork;

            //Classe van het adres bepalen:
            txtNetworkClass.Text = convertService.CheckClass(int.Parse(separateIpDec[0]));

            //string met subnetmask verdelen in twee delen tot aan prefix
            string[] separatedSubNetM = selectedSubnetMask.Split('/');

            //string  subnetmask noteren zonder 'dotted'-notatie
            string[] subnetmaskPart = separatedSubNetM[0].Split('.');

            //subnetmask omzetten naar binair
            string subnetmaskToBinary = convertService.ForeachToBinary(subnetmaskPart);
            txtSubnetBit.Text = subnetmaskToBinary;

            //Gekozen prefix bepalen:
            char[] delimiterChars = { '/', '(', ')' };
            string[] selectedprefixNumber = separatedSubNetM[1].Split(delimiterChars);
            int prefixNumber = int.Parse(selectedprefixNumber[1]);

            //Netwerkadres bepalen
            string firstPartNetwork = (txtIPBit.Text).Substring(0, prefixNumber);
            string secondPartNetwork = (txtSubnetBit.Text).Substring(prefixNumber, 32 - prefixNumber);
            txtNetworkAddressBit.Text = firstPartNetwork + secondPartNetwork;

            //Netwerknr van binair naar dotted decimal:
            string NWbit = txtNetworkAddressBit.Text;
            string convertednrToDD = convertService.BinaryNrDotted(NWbit);
            txtNetworkAddressDD.Text = convertednrToDD.ToString();

            //First host bepalen:
            string[] str = convertednrToDD.Split('.');
            string[] firstHostarr = convertService.ChangeToFirstHost(str);
            string joined = convertService.JoinArr(firstHostarr);
            txtFirstHostAddressDD.Text = joined.ToString();

            //First host naar binair omzetten:
            string firsthostDEC = txtFirstHostAddressDD.Text;
            string[] newarr = convertService.SplitString(firsthostDEC);
            string convertedFhost = convertService.ForeachToBinary(newarr);
            txtFirstHostAddressBit.Text = convertedFhost.ToString();

            //Broadcastaddress bepalen
            string getHost = txtFirstHostAddressBit.Text;

            //eerste deel van de string is bepaald door prefixnummer
            //eerste deel tot aan prefix mag zelfde blijven
            string firstPartfhost = getHost.Substring(0, prefixNumber);

            //tweede deel van de string begint van prefixnr tot het einde
            int diff = getHost.Length - prefixNumber;
            string secondPartfhost = getHost.Substring(prefixNumber, diff);
            //tweede deel van de string omzetten naar 1 bits
            string secondPrtBroadcast = convertService.ChangeAllToBinaryOne(secondPartfhost);
            txtBroadcastAddressBit.Text = firstPartfhost + secondPrtBroadcast;

            //broadcastaddress omzetten naar dotted decimal:
            string binaryToDotted = convertService.BinaryNrDotted(txtBroadcastAddressBit.Text);
            txtBroadcastAddressDD.Text = binaryToDotted;

            //Last host adres bepalen: broadcastnr-1 = last host nr
            string[] broadcastDDarr = convertService.SplitString(binaryToDotted);
            string[] broadcastToLastHostarr = convertService.ChangeBroadcastToLastHost(broadcastDDarr);
            string lastHostnr = convertService.JoinArr(broadcastToLastHostarr);
            txtLastHostAddressDD.Text = lastHostnr;

            //last host nr binair
            string[] splitLastHost = convertService.SplitString(lastHostnr);
            string binairLastHost = convertService.ForeachToBinary(splitLastHost);
            txtLastHostAddressBit.Text = binairLastHost;
        }
        private void ClearControls()
        {
            txtIPBit.Text = "";
            txtSubnetBit.Text = "";
            txtNetworkAddressBit.Text = "";
            txtNetworkAddressDD.Text = "";
            txtFirstHostAddressBit.Text = "";
            txtFirstHostAddressDD.Text = "";
            txtLastHostAddressBit.Text = "";
            txtLastHostAddressDD.Text = "";
            txtBroadcastAddressBit.Text = "";
            txtBroadcastAddressDD.Text = "";
            txtMaxNumberOfHosts.Text = "";
            txtNetworkClass.Text = "";
            txtNetworkType.Text = "";
        }

        private void cmbSubnet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
            selectedSubnetMask = cmbSubnet.SelectedItem.ToString();
        }

        
    }
}
