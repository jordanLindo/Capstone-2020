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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Interaction logic for ListActiveEvents.xaml
    /// 
    /// Name: Steve Coonrod
    /// Date: 3\08\2020
    /// Checked By:
    /// 
    /// This is the page for displaying the list of Active Events in the DB
    /// 
    /// Updated By:     
    /// Date Updated: 
    /// 
    /// </summary>
    public partial class ListApprovedEvents : Page
    {
        private IPUEventManager _eventManager = null;//For using event manager methods
        private EventMgmt _eventMgmt = null;//For allowing the updating of the EventMgmt page's _selectedEvent

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// A no-argumnet constructor. For some reason it is necessary for the programs initialization
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        public ListApprovedEvents()
        {
            _eventManager = new PUEventManager();
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The constructor for this page.
        /// Takes as parameters the current Event Manager and EventMgmt page
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="eventMgmt"></param>
        public ListApprovedEvents(IPUEventManager eventManager, EventMgmt eventMgmt)
        {
            _eventManager = eventManager;
            _eventMgmt = eventMgmt;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// This is a handler for the datagrid, to hide unwanted fields
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgEventList_Approved_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgEventList_Approved.Columns.RemoveAt(11);
            dgEventList_Approved.Columns.RemoveAt(10);
            dgEventList_Approved.Columns.RemoveAt(2);
            dgEventList_Approved.Columns.RemoveAt(1);
            dgEventList_Approved.Columns.RemoveAt(0);
            dgEventList_Approved.Columns[1].Header = "Type";
            dgEventList_Approved.Columns[2].Header = "Date and Time";
            dgEventList_Approved.Columns[dgEventList_Approved.Columns.Count - 1].Width =
                new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// This is an event handler for when the datagrid is loaded
        /// Retrieves its item source from the DB through the event manager
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgEventList_Approved_Loaded(object sender, RoutedEventArgs e)
        {
            List<PUEvent> eventList = new List<PUEvent>();
            try
            {
                if (dgEventList_Approved.ItemsSource == null)
                {

                    eventList = _eventManager.GetEventsByStatus("Approved");
                    eventList.AddRange(_eventManager.GetEventsByStatus("Active"));
                    dgEventList_Approved.ItemsSource = eventList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message);
            }

        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// This is the event handler for the datagrids selection_changed event
        /// This sets the EventMgmt page's _selectedEvent value to the datagrids selected item
        /// Then toggles the buttons that rely on an event being selected
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgEventList_Approved_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _eventMgmt._selectedEvent = null;
            _eventMgmt._selectedEvent = (PUEvent)dgEventList_Approved.SelectedItem;
            _eventMgmt.ToggleEventButtons();
        }
    }
}
