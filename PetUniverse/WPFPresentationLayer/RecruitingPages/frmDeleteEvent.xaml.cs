﻿using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
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
using System.Windows.Shapes;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// 
    /// NAME: Steve Coonrod
    /// DATE: 2020-03-04
    /// CHECKED BY: 
    /// 
    /// This is the code behind the DeleteEvent.xaml
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public partial class frmDeleteEvent : Window
    {
        private IPUEventManager _eventManager = null;
        private PUEvent _event = null;

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This is the constructor for the Delete Event form
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="puEvent"></param>
        public frmDeleteEvent(IPUEventManager eventManager, PUEvent puEvent)
        {
            _eventManager = eventManager;
            _event = puEvent;
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This is the Cancel Button click event handler
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This is the Delete Button click event handler
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Logic to delete the event
            try
            {
                bool successfulDelete = _eventManager.DeleteEvent(_event.EventID);
                if (successfulDelete == true)
                {
                    MessageBox.Show(_event.EventName + " was deleted.");
                    this.DialogResult = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This is the load event handler for the form
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Still needs to load the events picture
            lblBannerPath.Content = _event.BannerPath;
            lblEventName.Content = _event.EventName;
            lblEventTime.Content = _event.EventDateTime;
            lblLocation.Content = _event.Address + "\n" + _event.City + ", " + _event.State + " " + _event.Zipcode;
            imgEvent.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory
                    + "\\Images\\" + _event.BannerPath, UriKind.RelativeOrAbsolute));
        }
    }
}
