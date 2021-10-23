using Ait.IPCalculator.Core.Entities;
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
            // your code here ...
 
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
        }

        
    }
}
