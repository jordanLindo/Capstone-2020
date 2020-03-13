﻿using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// 
    /// NAME: Steve Coonrod
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// The Fake Event Data to ensure the classes and methods work properly.
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class FakeEventAccessor : IEventAccessor
    {
        private List<PUEvent> puEvents = null;
        private List<Request> requests = null;
        private List<EventRequest> puEventRequests = null;
        private List<EventType> eventTypes = null;

        public FakeEventAccessor()
        {
            //A fake repository containing 4 events
            puEvents = new List<PUEvent>()
            {
                new PUEvent()
                {
                    EventID = 1000000,
                    CreatedByID = 1000000,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Billy's Animal Parade",
                    EventTypeID = "Fundraiser",
                    EventDateTime = DateTime.Parse("04/20/2020 05:15 PM"),
                    Address = "202 First Street",
                    City = "Cedar Rapids",
                    State = "IA",
                    Zipcode = "52402",
                    BannerPath = "billysParade.jpg",
                    Status = "Pending Approval",
                    Description = "Billy Little is hosting a childrens animal parade."
                },
                new PUEvent()
                {
                    EventID = 1000001,
                    CreatedByID = 1000010,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Fun at the Lake",
                    EventTypeID = "Adoption",
                    EventDateTime = DateTime.Parse("07/06/2020 06:30 PM"),
                    Address = "202 Fawn Lake Drive",
                    City = "Estes Park",
                    State = "CO",
                    Zipcode = "88233",
                    BannerPath = "FawnLake.jpg",
                    Status = "Pending Approval",
                    Description = "Come spend some time with our animals out at Fawn Lake Animal Shelter."
                },
                new PUEvent()
                {
                    EventID = 1000023,
                    CreatedByID = 1000142,
                    DateCreated = DateTime.Parse("01/24/2020 05:15 PM"),
                    EventName = "Animal Cruelty Awareness Rally",
                    EventTypeID = "Awareness",
                    EventDateTime = DateTime.Parse("10/31/2020 05:15 PM"),
                    Address = "1187 Arbor Lane",
                    City = "Millbrook",
                    State = "WI",
                    Zipcode = "67421",
                    BannerPath = "ACAR.jpg",
                    Status = "Pending Approval",
                    Description = "Animals are cruel and you need to know about it."
                },
                new PUEvent()
                {
                    EventID = 1000418,
                    CreatedByID = 1000055,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    EventName = "Lets All Monkey Around",
                    EventTypeID = "Fundraiser",
                    EventDateTime = DateTime.Parse("01/24/2020 05:15 PM"),
                    Address = "9391 Amazing Place",
                    City = "Coolsville",
                    State = "MI",
                    Zipcode = "11697",
                    BannerPath = "monkeys.jpg",
                    Status = "Approved",
                    Description = "Come join us at the Amazing Place and go bananas with our monkeys."
                },
            };

            //A fake repository containing 4 requests
            requests = new List<Request>()
            {
                new Request()
                {
                    RequestID = 1000000,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event"
                },
                new Request()
                {
                    RequestID = 1000001,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event"
                },
                new Request()
                {
                    RequestID = 1000002,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event"
                },
                new Request()
                {
                    RequestID = 1000003,
                    DateCreated = DateTime.Parse("01/24/2019 05:15 PM"),
                    RequestTypeID = "Event"
                },
            };

            // A fake repository of 4 event requests
            puEventRequests = new List<EventRequest>()
            {
                new EventRequest()
                {
                    EventID = 1000000,
                    RequestID = 1000000,
                    ReviewerID = 1000027,
                    DisapprovalReason = null,
                    DesiredVolunteers = 5,
                    Active = true
                },
                new EventRequest()
                {
                    EventID = 1000001,
                    RequestID = 1000001,
                    ReviewerID = 1000247,
                    DisapprovalReason = null,
                    DesiredVolunteers = 6,
                    Active = true
                },
                new EventRequest()
                {
                    EventID = 1000023,
                    RequestID = 1000002,
                    ReviewerID = 1000332,
                    DisapprovalReason = null,
                    DesiredVolunteers = 4,
                    Active = true
                },
                new EventRequest()
                {
                    EventID = 1000418,
                    RequestID = 1000003,
                    ReviewerID = 1001027,
                    DisapprovalReason = null,
                    DesiredVolunteers = 3,
                    Active = true
                }
            };

            eventTypes = new List<EventType>()
            {
                new EventType()
                {
                    EventTypeID = "Adoption",
                    Description = "An Adoption Event"
                },
                new EventType()
                {
                    EventTypeID = "Awareness",
                    Description = "An Awareness Event"
                },
                new EventType()
                {
                    EventTypeID = "Fundraiser",
                    Description = "A Fundraising Event"
                },
                new EventType()
                {
                    EventTypeID = "Recruiting",
                    Description = "A Recruiting Event"
                }
            };

        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod, Matt Deaton
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The method used to add a test event to the fake repository
        /// Returns 0 if failed
        /// Returns 1 if successful
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// 
        /// <param name="puEvent"></param>
        /// <returns> 1 </returns>
        public int InsertEvent(PUEvent puEvent)
        {
            int intToReturn = 0;//Actual method returns the scope_identity EventID
            if (puEvent.EventName.Length < 8 || puEvent.EventName.Length > 150)
            {
                throw new ApplicationException("The Event Name value was outside the acceptable range.");
            }
            else if (puEvent.EventDateTime < DateTime.Now.AddDays(14))
            {
                throw new ApplicationException("The event date is too close. Must be at least 14 days in the future.");
            }
            else if (puEvent.Address.Length > 200 || puEvent.Address.Length < 6)
            {
                throw new ApplicationException("The address value was not within the acceptable range.");
            }
            else if (puEvent.City.Length < 2 || puEvent.City.Length > 50)
            {
                throw new ApplicationException("The city value was not within acceptable range.");
            }
            else if (puEvent.Zipcode.Length < 5 || puEvent.Zipcode.Length > 11)
            {
                throw new ApplicationException("The zipcode is not within acceptable range.");
            }
            else if (puEvent.BannerPath.Length < 5 || puEvent.BannerPath.Length > 250)
            {
                throw new ApplicationException("The picture file name is not within acceptable range.");
            }
            else if (!puEvent.BannerPath.ToLower().Contains(".jpg") && !puEvent.BannerPath.ToLower().Contains(".png"))
            {
                throw new ApplicationException("The picture file name is missing the file extension.");
            }
            else if (puEvent.Description.Length < 2 || puEvent.Description.Length > 500)
            {
                throw new ApplicationException("The discription value is not within the acceptable range.");
            }
            else
            {
                puEvents.Add(puEvent);
                if (puEvents.Count == 5)
                {
                    intToReturn = 1;
                }

            }
            return intToReturn;
        }

        public int InsertEventRequest(EventRequest eventRequest)
        {
            int rowsEffected = 0;
            puEventRequests.Add(eventRequest);
            if (puEventRequests.Count == 5)
            {
                rowsEffected = 1;
            }

            return rowsEffected;
        }

        public int InsertRequest(Request request)
        {
            int requestID = 0;
            requests.Add(request);
            if (requests.Count == 5)
            {
                requestID = 1;
            }
            return requestID;
        }

        public List<EventType> SelectAllEventTypes()
        {
            var eventTypeList = (from e in eventTypes
                                 select e).ToList();

            return eventTypeList;
        }


        /// <summary>
        /// 
        /// /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The method used to select a test event from the fake repository by EventID
        /// Returns the event with the matching ID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public PUEvent SelectEventByID(int eventID)
        {
            var selectedEvent = (PUEvent)(from e in puEvents
                                          where e.EventID == eventID
                                          select e).SingleOrDefault();

            return selectedEvent;
        }

        /// <summary>
        /// 
        /// /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The method used to select all test events from the fake repository
        /// Returns 0 if failed
        /// Returns 1 if successful
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PUEvent> SelectEventsAll()
        {
            var selectedEvents = (from e in puEvents
                                  select e).ToList();
            return selectedEvents;
        }
    }
}